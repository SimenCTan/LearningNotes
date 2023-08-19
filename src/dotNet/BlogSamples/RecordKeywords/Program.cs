// See https://aka.ms/new-console-template for more information
var person = new Person("You", "Test");
var personOther = new Person("You", "Test");
Console.WriteLine(person.Equals(personOther));
Console.WriteLine(person.GetHashCode());
Console.WriteLine(person.ToString());

if (person is Person { FirstName: "You" }) // 使用属性模式匹配
{
    Console.WriteLine("Hello,Yod");
}
var (f, l) = person; // 使用解构操作
Console.WriteLine($"{f} {l}");

Person student = new Student(12, "You", "Test");
Console.WriteLine(student.Equals(person));

var point1 = new Point(1, 2);
var point2 = new Point(1, 2);
Console.WriteLine(point1.Equals(point2));
Console.WriteLine(point1.GetHashCode());
Console.WriteLine(point1.ToString());

public record Person(string FirstName,string LastName);

public record Student(int Number,string FirstName, string LastName) : Person(FirstName,LastName);

public record struct Point(int X,int Y);
