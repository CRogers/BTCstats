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
			GetTemps();
			
			foreach(double t in GetTemps())
				Console.WriteLine(t);
		}
		
		public static IEnumerable<double> GetTemps()
		{
			var text = ReadProcess("aticonfig", "--odgt --adapter=all");			
			var r = new Regex(@"Temperature - (?<temp>\d{1,3}\.\d{1,2})");
			
			foreach(Match m in r.Matches(text))
				yield return double.Parse(m.Groups["temp"].Value);
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

