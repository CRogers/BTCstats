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
            return DeserializeJson<ApiData>("http://mining.bitcoin.cz/accounts/profile/json/" + apiKey);
        }

        public static PublicStats ReadPublicStats()
        {
            return DeserializeJson<PublicStats>("http://mining.bitcoin.cz/stats/json/");
        }

        private static T DeserializeJson<T>(string url)
        {
            var json = new WebClient().DownloadString(url);

            var serializer = new JsonExSerializer.Serializer(typeof(T));
            return (T)serializer.Deserialize(json);
        }
    }
}
