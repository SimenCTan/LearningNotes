namespace TreeListRendering;

public class AccountItemInfo
{
    public string Name { get; set; } = default!;
    public string Alias { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    public string Domain { get; set; } = string.Empty;
    public string Website { get; set; } = string.Empty;
    public string AUM { get; set; } = string.Empty;
    public int Employees { get; set; }
    public string? AccountTypeId { get; set; }
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string Remark { get; set; } = string.Empty;

    /// <summary>
    /// creator name
    /// </summary>
    public string Creator { get; set; } = string.Empty;

    public DateTimeOffset CreatedOn { get; set; }

    public override string ToString()
    {
        return $"{Name} {Street} {City} {State} {Country} {PostalCode}";
    }
}
