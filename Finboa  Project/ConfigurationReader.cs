using System.Configuration;

public class ConfigurationReader
{
    public static string BaseUrl => ConfigurationManager.AppSettings["BaseUrl"];

}
