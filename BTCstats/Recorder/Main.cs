using System;
using System.IO;

namespace Recorder
{
	class Program
	{
        public static void Main(string[] args)
        {
            string apiKey = File.ReadAllText("apiKey.txt");
            var scraper = new SlushScraper(apiKey);
            var data = scraper.ReadApiData();

            /*foreach (double t in CardStats.GetTemps())
                Console.WriteLine(t);

            foreach (double[] t in CardStats.GetCurrentClocks())
                Console.WriteLine(t[0] + "   " + t[1]);*/
        }
	}
}

