namespace DataApp;

public interface IDataStorage
{
    /// <summary>
    /// Stores data in a file.
    /// </summary>
    /// <param name="dataId"> ID of the file to store data in </param>
    /// <param name="data"> Data to store in the file </param>
    void StoreData(int dataId, string data);
}

internal class DataStorage : IDataStorage
{
    // Implementation locked - do not change
    public void StoreData(int dataId, string data)
    {
        File.AppendAllText($"\\\\NETDATASTORAGE\\{dataId}.dat", data);
    }
    // End of locked implementation
}