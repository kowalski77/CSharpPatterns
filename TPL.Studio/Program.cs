using System.Threading.Tasks.Dataflow;
using TPL.Studio.Dataflow;


//Why? Dataflow components are useful when you have multiple operations that must communicate with one another asynchronously or when you want to process data as it becomes available

// await ExampleOne.ReverseWordsAsync();

var exampleTwo = new ExampleTwo();
exampleTwo.CreateFile();

var buffer = exampleTwo.CreateBuffer();

var newEntry = new CompetitionEntry
{
    Email = "random@email.com",
    Answer = "a correct answer",
    Created = DateTime.UtcNow,
    IPAddress = "localhost"
};

await buffer.SendAsync(newEntry);

