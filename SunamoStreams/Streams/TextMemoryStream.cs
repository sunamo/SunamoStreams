namespace SunamoStreams.Streams;

/// <summary>
/// Represents the text memory stream type.
/// </summary>
public class TextMemoryStream
{
    /// <summary>
    /// Gets or sets the line.
    /// </summary>
    public StringBuilder Line { get; set; } = new StringBuilder();
    private string? filePath = null;
    private string? initialPath = null;

    /// <summary>
    /// Text memory stream.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>The text memory stream result.</returns>
    public TextMemoryStream(string path)
    {
        initialPath = path;
    }

    /// <summary>
    /// Init.
    /// </summary>
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

    /// <summary>
    /// Save.
    /// </summary>
    public
    async Task
 Save()
    {
        await FileAsync.WriteAllTextAsync(filePath!, Line.ToString());
    }
}
