using System.Net.Http.Headers;

IDataDownloader dataDownloader = new SlowDataDownloader<string, string>();

Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id3"));
Console.WriteLine(dataDownloader.DownloadData("id1"));
Console.WriteLine(dataDownloader.DownloadData("id2"));

Console.ReadKey();

public interface IDataDownloader
{
  TReturnType DownloadData<TKey, TReturnType>(TKey resourceId);
}

public class Cache<TKey, TData>
{
  private readonly Dictionary<TKey, TData> _dict = new();
  public TData FetchData(TKey key, TData data)
  {
    if (!_dict.ContainsKey(key)) _dict.Add(key, data);
    return _dict[key];
  }
}

public class SlowDataDownloader<TKey, TVal> : IDataDownloader
{
  public TVal DownloadData(TKey resourceId)
  {
    if (!_dict.ContainsKey(resourceId)) _dict.Add(resourceId, ");
    Thread.Sleep(1000);
  }

  public TReturnType DownloadData<TKey1, TReturnType>(TKey1 resourceId)
  {
    throw new NotImplementedException();
  }
}
