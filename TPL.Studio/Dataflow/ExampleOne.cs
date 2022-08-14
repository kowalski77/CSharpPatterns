using System.Threading.Tasks.Dataflow;

namespace TPL.Studio.Dataflow;

//Source: https://hamidmosalla.com/2018/08/04/what-is-tpl-dataflow-in-net-and-when-should-we-use-it/
public class ExampleOne
{
    public static async Task ReverseWordsAsync()
    {
        var downloadString = GetResourceAsync();
        var createWordList = CreateWordListAsync();
        var filterWordList = GetFilteredWordsAsync();
        var findReversedWords = FindReverseWordsAsync();
        var printReversedWords = ReverseWordsInternalAsync();

        var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };

        downloadString.LinkTo(createWordList, linkOptions);
        createWordList.LinkTo(filterWordList, linkOptions);
        filterWordList.LinkTo(findReversedWords, linkOptions);
        findReversedWords.LinkTo(printReversedWords, linkOptions);

        // Process "The Iliad of Homer" by Homer.
        downloadString.Post("http://www.gutenberg.org/files/6130/6130-0.txt");

        // Mark the head of the pipeline as complete.
        downloadString.Complete();

        // Wait for the last block in the pipeline to process all messages.
        await printReversedWords.Completion;
    }

    // Prints the provided reversed words to the console.    
    private static ActionBlock<string> ReverseWordsInternalAsync()
    {
        return new ActionBlock<string>(reversedWord =>
        {
            Console.WriteLine("Found reversed words {0}/{1}",
               reversedWord, new string(reversedWord.Reverse().ToArray()));
        });
    }

    // Finds all words in the specified collection whose reverse also exists in the collection.
    private static TransformManyBlock<string[], string> FindReverseWordsAsync()
    {
        return new TransformManyBlock<string[], string>(words =>
        {
            Console.WriteLine("Finding reversed words...");

            var wordsSet = new HashSet<string>(words);

            return from word in words.AsParallel()
                   let reverse = new string(word.Reverse().ToArray())
                   where word != reverse && wordsSet.Contains(reverse)
                   select word;
        });
    }

    // Removes short words and duplicates.
    private static TransformBlock<string[], string[]> GetFilteredWordsAsync()
    {
        return new TransformBlock<string[], string[]>(words =>
        {
            Console.WriteLine("Filtering word list...");

            return words
               .Where(word => word.Length > 3)
               .Distinct()
               .ToArray();
        });
    }

    // Separates the specified text into an array of words.
    private static TransformBlock<string, string[]> CreateWordListAsync()
    {
        return new TransformBlock<string, string[]>(text =>
        {
            Console.WriteLine("Creating word list...");

            var tokens = text.Select(c => char.IsLetter(c) ? c : ' ').ToArray();
            text = new string(tokens);

            return text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        });
    }

    // Downloads the requested resource as a string.
    private static TransformBlock<string, string> GetResourceAsync()
    {
        return new TransformBlock<string, string>(async uri =>
        {
            Console.WriteLine("Downloading '{0}'...", uri);

            return await new HttpClient().GetStringAsync(uri);
        });
    }
}
