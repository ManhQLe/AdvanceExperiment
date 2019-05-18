using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace Experiment.Chaos
{
	class Exact: Experiment
	{
		public override void Run(string[] args)
		{
			BigInteger s = BigInteger.Parse(args[0]);
			int N = int.Parse(args[1]);
			var bk = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("0. {0}",s);
			Console.ForegroundColor = bk;
			for (int i = 0; i < N; i++) {
				s = ((s & 1) == 0) ? s >> 1 : 3 * s + 1;
				Console.WriteLine("{0}. {1}", i + 1, s);
			}
			
		}
	}
}
