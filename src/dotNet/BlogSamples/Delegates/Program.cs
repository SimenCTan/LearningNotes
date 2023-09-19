// See https://aka.ms/new-console-template for more information
using Microsoft.VisualBasic;

var guidstr = Guid.NewGuid().ToString("N");
var timetick = DateTime.Now.Ticks;
var noID = GetIdStrNo("01");
Console.WriteLine($"{guidstr} length is {guidstr.Length} time tick is {timetick} length {timetick.ToString().Length} \n\r {noID} noid length {noID.Length}");
var animal = new Animal();
StaticDelegate staticDelegate = Console.WriteLine;
staticDelegate += PrintMultiDelegate;
InstanceDelegate instanceDelegate = animal.PrintLiveTime;
staticDelegate("Hello static delegate");
instanceDelegate(10);


AnimalFactory factory = () => new Dog();
AnimalConsumer consumer = (Animal animal) => Console.WriteLine(animal.GetType().Name);

Animal animalft = factory();
consumer(animalft);

Func<int, int, int> sum = (a, b) => a + b;
Action<int, int> print = (a, b) => Console.WriteLine(a + b);
Predicate<int> isEven = n => n % 2 == 0;

var r = ExecuteOperation(2, 3, static (a, b) => AddNum(a, b));
Console.WriteLine(r);

LongRunningMethond(i => Console.WriteLine($"progess {i}% complete"));

var publisher = new EventPublisher();
var subscriber = new EventSubscribe();

// 订阅事件
publisher.EventOccurred += subscriber.HandleEvent;

// 执行操作，触发事件
publisher.DoSomething();


static int AddNum (int a, int b) => a + b;
int ExecuteOperation(int a, int b, Func<int, int, int> operation)
{
    return operation(a, b);
}
static void PrintMultiDelegate(string message)
{
    Console.WriteLine($"Multi Delegate {message}");
}

static void LongRunningMethond(Action<int> reportProgress)
{
    for (var i=1; i <= 10; i++)
    {
        reportProgress(i * 10);
        Task.Delay(100);
    }
}

static string GetIdStrNo(string tableNo)
{
    Random random = new Random();
    var number = random.Next(1000, 9999);
    return $"{DateTime.Now:yyyyMMddHHmmssffff}{number}{tableNo}";
}


