namespace ForbiddenLands.App.Options;

public class JsonFlatFileOptions
{
    public string Path { get; set; }
    public bool UseLowerCamelCase { get; set; }
    public string KeyProperty { get; set; }
    public bool ReloadBeforeGetCollection { get; set; }
    public string EncryptionKey { get; set; }
}
