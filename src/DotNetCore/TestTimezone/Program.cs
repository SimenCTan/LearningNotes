using System.Globalization;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine(GetPublishDate(20220622, "21:02").ToString("yyyyMMdd HH:mm"));
DateTime GetPublishDate(uint date, string hour)
{
    var publishDate = DateTime.ParseExact($"{date} {hour}", "yyyyMMdd HH:mm", CultureInfo.InvariantCulture);
    var zeroTimezone = new DateTimeOffset(publishDate, TimeSpan.FromHours(0));
    return zeroTimezone.ToUniversalTime().UtcDateTime;
}
