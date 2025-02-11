namespace DataApp;

public class Program
{
    public static async Task Main(string[] args)
    {
        var manager = new DataManager(
            new DataFetcher(),
            new DataStorage()
        );
        var tasks = new List<Task>();

        // Helper method to consolidate data for a given ID
        void consolidateDataForId(int id)
        {
            tasks.Add(Task.Run(async () =>
                Console.WriteLine($"Consolidated dataID {id}. Result: {await manager.ConsolidateDataFromSourcesAsync(id)}")
            ));
        }

        // Add tasks to pool
        consolidateDataForId(27);
        for (int id = 0; id <= 10; id++)
        {
            consolidateDataForId(id);
        }

        // Wait for all tasks to complete
        await Task.WhenAll(tasks);
        Console.WriteLine("Completed");
    }
}
