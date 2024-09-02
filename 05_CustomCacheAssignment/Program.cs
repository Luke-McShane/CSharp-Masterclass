IDataDownloader dataDownloader = new SlowDataDownloader();

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

public class SlowDataDownloader<TKey> : IDataDownloader
{
  var dict = new Dictionary<
  public TReturnType DownloadData<TKey, TReturnType>(TKey resourceId)
  {
    Thread.Sleep(1000);
    return $"Some data for {resourceId}";
  }
}
