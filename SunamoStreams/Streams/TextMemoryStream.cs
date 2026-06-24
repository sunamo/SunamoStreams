namespace SunamoStreams.Streams;

public class TextMemoryStream
{
    public StringBuilder Line { get; set; } = new StringBuilder();
    private string? filePath = null;
    private string? initialPath = null;

    public TextMemoryStream(string path)
    {
        initialPath = path;
    }

    public
    async Task
        Init()
    {
        filePath = initialPath;

        string content = string.Empty;
        if (File.Exists(filePath))
        {
            content =
                await FileAsync.ReadAllTextAsync(initialPath!, Encoding.UTF8);
        }

        Line.Append(content);
    }

    public
    async Task
 Save()
    {
        await FileAsync.WriteAllTextAsync(filePath!, Line.ToString());
    }
}
