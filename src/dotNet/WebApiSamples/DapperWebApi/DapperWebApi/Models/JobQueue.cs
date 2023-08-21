namespace DapperWebApi.Models;

public class JobQueue
{
    public int Id { get; set; }

    public int Stateid { get; set; }

    public string? Statename { get; set; }

    public string Invocationdata { get; set; } = string.Empty;

    public string Arguments { get; set; } = string.Empty;

    public DateTime Createdat { get; set; } = default!;

    public DateTime? Expireat { get; set; }

    public int Updatecount { get; set; }
}
