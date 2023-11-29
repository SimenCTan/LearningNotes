namespace TreeListRendering;

public static class RawFileExtension
{
    public async static Task<string> ReadAccountsDataAsync()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("accounts_data.json");
        using (var reader = new StreamReader(stream))
        {
            return reader.ReadToEnd();
        }
    }
}
