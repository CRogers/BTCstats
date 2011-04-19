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
			var p = new Process();
			p.StartInfo.FileName = "aticonfig";
			p.StartInfo.Arguments = "--odgt --adapter=all";
			p.StartInfo.UseShellExecute = false;
			p.StartInfo.RedirectStandardOutput = true;
			p.Start();
			
			string text = p.StandardOutput.ReadToEnd();
			
			var r = new Regex(@"Temperature - (?<temp>\d{1,3}\.\d{1,2})");
			
			foreach(Match m in r.Matches(text))
				yield return double.Parse(m.Groups["temp"].Value);
		}
	}
}

