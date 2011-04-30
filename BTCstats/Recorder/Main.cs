using System;

namespace Recorder
{
	class Program
	{
        public static void Main(string[] args)
        {
            foreach (double t in CardStats.GetTemps())
                Console.WriteLine(t);

            foreach (double[] t in CardStats.GetCurrentClocks())
                Console.WriteLine(t[0] + "   " + t[1]);
        }
	}
}

