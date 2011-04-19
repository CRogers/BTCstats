using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Recorder
{
	class MainClass
	{
		public static void Main (string[] args)
		{			
			foreach(double t in GetTemps())
				Console.WriteLine(t);
			
			foreach(double[] t in GetCurrentClocks())
				Console.WriteLine(t[0] + "   " + t[1]);
		}
		
		public static IEnumerable<double> GetTemps()
		{
			var text = ReadProcess("aticonfig", "--odgt --adapter=all");			
			var r = new Regex(@"Temperature - (?<temp>\d{1,3}\.\d{1,2})");
			
			foreach(Match m in r.Matches(text))
				yield return double.Parse(m.Groups["temp"].Value);
		}
		
		public static IEnumerable<double[]> GetCurrentClocks()
		{
			var text = ReadProcess("aticonfig", "--odgc --adapter=all");
			var cc = new Regex(@"Current Clocks : *(?<core>\d{2,4}) *(?<mem>\d{2,4})");
			
			foreach(Match m in cc.Matches(text))
				yield return new[]{ double.Parse(m.Groups["core"].Value), double.Parse(m.Groups["mem"].Value) };
		}
		
		public static string ReadProcess(string program, string args)
		{
			var p = new Process();
			p.StartInfo.FileName = program;
			p.StartInfo.Arguments = args;
			p.StartInfo.UseShellExecute = false;
			p.StartInfo.RedirectStandardOutput = true;
			p.Start();
			
			return p.StandardOutput.ReadToEnd();
		}
	}
}

