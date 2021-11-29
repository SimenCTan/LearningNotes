using System.IO;
using BenchmarkDotNet.Attributes;

public class FileStreamTest
{
    private byte[] _bytes = new byte[8000];

    [Benchmark]
    public async Task Write100MBAsync()
    {
        using FileStream fs = new("file.txt", FileMode.Create, FileAccess.Write, FileShare.None, 1 ,FileOptions.Asynchronous);
        for (var i = 0; i < 100000000 / 8000;i++)
            await fs.WriteAsync(_bytes);
    }
}
