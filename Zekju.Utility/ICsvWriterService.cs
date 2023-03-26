namespace Zekju.Utility;

public interface ICsvWriterService
{
    Task WriteToCsvAsync<T>(IEnumerable<T> records, string filePath);
}