namespace DataApp;

/// <summary>
/// Defines possible result codes for IDataManager method calls.
/// </summary>
public enum DataManagerResult
{
    InvalidDataID = -1,
    EmptyDataID = -2,
    Success = 0
}

public interface IDataManager
{
    /// <summary>
    /// Consolidate the data from the DataFetcher sources into a centralized data store.
    /// </summary>
    /// <returns>
    /// <list type="bullet">
    /// <item><description> -1 if an invalid dataId (less than 0) is provided </description></item>
    /// <item><description> -2 if the data fetched from the supplied ID was null or whitespace </description></item>
    /// <item><description>  0 if we successfully consolidated </description></item>
    /// </list>
    /// </returns>
    Task<int> ConsolidateDataFromSourcesAsync(int dataId);
}

public class DataManager(IDataFetcher dataFetcher, IDataStorage dataStorage) : IDataManager
{
    public async Task<int> ConsolidateDataFromSourcesAsync(int dataId)
    {
        // Check for invalid data ID
        if (dataId < 0)
        {
            return (int)DataManagerResult.InvalidDataID;
        }

        // Fetch data and check for emptiness
        var data = await Task.Run(() => dataFetcher.FetchData(dataId));
        if (string.IsNullOrWhiteSpace(data))
        {
            return (int)DataManagerResult.EmptyDataID;
        }

        // Store the data if not empty
        await Task.Run(() => dataStorage.StoreData(dataId, data));
        return (int)DataManagerResult.Success;
    }
}
