using System.Net;

namespace Recorder
{
    public class SlushScraper
    {
        public string ApiKey { get; set; }

        public SlushScraper(string apiKey)
        {
            ApiKey = apiKey;
        }


        public ApiData ReadApiData()
        {
            return ReadApiData(ApiKey);
        }

        public static ApiData ReadApiData(string apiKey)
        {
            var wc = new WebClient();
            var json = wc.DownloadString("http://mining.bitcoin.cz/accounts/profile/json/" + apiKey);

            var serializer = new JsonExSerializer.Serializer(typeof (ApiData));
            return (ApiData)serializer.Deserialize(json);
        }
    }
}
