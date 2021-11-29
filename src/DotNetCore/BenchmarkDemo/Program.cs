// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;

Console.WriteLine("Hello, World!");
var summary = BenchmarkRunner.Run<Md5VsSha256>();
