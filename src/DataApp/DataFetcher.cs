namespace DataApp;

public interface IDataFetcher
{
    /// <summary>
    /// Fetches data from a source.
    /// </summary>
    /// <param name="dataId"> ID of the file to fetch data from </param>
    /// <returns> Contents of the file matching the provided data ID </returns>
    string FetchData(int dataId);
}

internal class DataFetcher: IDataFetcher
{
    // Implementation locked - do not change
    public string FetchData(int dataId)
    {
        return File.ReadAllText($"\\\\NETDATASOURCES\\{dataId}.dat");
    }
    // End of locked implementation
}