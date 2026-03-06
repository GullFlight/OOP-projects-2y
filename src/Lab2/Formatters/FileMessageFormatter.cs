namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class FileMessageFormatter : IMessageFormatter
{
    private readonly string _fileName;

    public FileMessageFormatter(string writer)
    {
        _fileName = writer;
    }

    public void FormatTitle(string title)
    {
        File.WriteAllText(_fileName, $"Title: {title}\n");
    }

    public void FormatBody(string body)
    {
        {
            File.WriteAllText(_fileName, $"#Body: {body}\n");
        }
    }
}