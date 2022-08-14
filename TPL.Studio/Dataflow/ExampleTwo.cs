using System.Threading.Tasks.Dataflow;

namespace TPL.Studio.Dataflow;

public class ExampleTwo
{
    private const string FilesFolder = "Files";

    private string FilePath => Path.Combine(FilesFolder, "entries.csv");

    public void CreateFile()
    {
        if (!File.Exists(FilePath))
        {
            Directory.CreateDirectory(FilesFolder);

            File.AppendAllLines(FilePath, new[] { $"Email,Answer,IPAddress,Created(UTC)" });
        }
    }

    internal BufferBlock<CompetitionEntry> CreateBuffer()
    {
        // The Consumer Block - this is the block that receives an entry and write to the file
        var fileWriter = new ActionBlock<CompetitionEntry>((entry) =>
        {
            // When the object is received, put the new csv line together
            var newCsvLine = $"{entry.Email},{entry.Answer},{entry.IPAddress},{entry.Created:s}";
            File.AppendAllLines(FilePath, new[] { newCsvLine });
        });

        // A simple buffer (one at a time), link this to the consumer above to create a "pipeline"
        var producer = new BufferBlock<CompetitionEntry>();
        producer.LinkTo(fileWriter);

        return producer;
    }
}
