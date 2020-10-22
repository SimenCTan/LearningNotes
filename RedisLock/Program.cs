using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace RedisLock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("redis lock start");
            var lockKey = "lock:eat";
            var timespan = TimeSpan.FromSeconds(5);
            Parallel.For(0, 5,  x =>
            {
                string person = $"person:{x}";
                var val = 0;
                bool isLocked =  AcquireLock(lockKey, person, timespan);
                while (!isLocked && val <= 5000)
                {
                    val += 250;
                    System.Threading.Thread.Sleep(250);
                    isLocked=AcquireLock(lockKey, person, timespan);
                }
                if (isLocked)
                {
                    Console.WriteLine($"{person} begin eat food(with lock) at {DateTimeOffset.Now.ToUnixTimeMilliseconds()}.");
                    if (new Random().NextDouble() < 0.6)
                    {
                        Console.WriteLine($"{person} release lock { ReleaseLock(lockKey, person)} at {DateTimeOffset.Now.ToUnixTimeMilliseconds()}");
                    }
                    else
                    {
                        Console.WriteLine($"{person} do not release lock ....");
                    }
                }
                else
                {
                    Console.WriteLine($"{person} begin eat food(without lock) at {DateTimeOffset.Now.ToUnixTimeMilliseconds()}.");
                }
            });
            Console.WriteLine("end");
            Console.Read();

        }

        private  static bool AcquireLock(string key, string value, TimeSpan expiration)
        {
            var flag = false;
            try
            {
                flag = ( GetRedisConnection()).Value.GetDatabase(1)
                    .StringSet(key, value, expiration, When.NotExists);
            }
            catch (RedisException redisEx)
            {
                Console.WriteLine($"acquire lock fail message:{redisEx.Message}");
            }
            return flag;
        }

        private  static bool ReleaseLock(string key,string value)
        {
            var flag = false;
            string lua_script = @"
            if (redis.call('GET', KEYS[1]) == ARGV[1]) then
                redis.call('DEL', KEYS[1])
                return true
            else
                return false
            end
            ";

            try
            {
                var excuteRes = (GetRedisConnection()).Value.GetDatabase(1)
                    .ScriptEvaluate(lua_script, new RedisKey[] { key }, new RedisValue[] { value });
                flag = (bool)excuteRes;
            }
            catch (RedisException redisEx)
            {
                Console.WriteLine($"Release lock fail message:{redisEx.Message}");
            }
            return flag;
        }

        private  static Lazy<ConnectionMultiplexer> GetRedisConnection()
        {
            var redisConnectionOptions = new ConfigurationOptions
            {
                ConnectTimeout = 5000,
                DefaultDatabase = 1,
                AbortOnConnectFail = false,
                Password = "*****"
            };
            redisConnectionOptions.EndPoints.Add("localhost", 6379);
            var connection =  ConnectionMultiplexer.Connect(redisConnectionOptions);
            return new Lazy<ConnectionMultiplexer>(connection);
        }
    }
}
