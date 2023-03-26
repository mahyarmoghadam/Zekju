using System.Globalization;
using CsvHelper;

namespace Zekju.Utility;

public class CsvWriterService : ICsvWriterService
{
    public async Task WriteToCsvAsync<T>(IEnumerable<T> records, string filePath)
    {
        await using var writer = new StreamWriter(filePath);
        await using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        await csv.WriteRecordsAsync(records);
    }
}