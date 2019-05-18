using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using QWQNG;
namespace Experiment.Random
{
	class SpeedTest : Experiment
	{
		static IQNG gen = new QNG();
		static int MAXBYTES = 8192;
		public override void Run(string[] args)
		{
			try
			{
				int howMany = int.Parse(args[0]);

				Console.WriteLine("Clearing devices...");
				gen.Clear();
				Stopwatch watcher = new Stopwatch();
				int n  = howMany / MAXBYTES;
				
				watcher.Start();
				byte[] bytes;
				for (int i = 0; i < n; i++)
					bytes = gen.RandBytes[MAXBYTES] as byte[];
				int remain = howMany % MAXBYTES;
				if (remain > 0)
					bytes = gen.RandBytes[remain] as byte[];


				watcher.Stop();

				Console.WriteLine("Generate {0} bytes in {1}ms", howMany, watcher.Elapsed.TotalMilliseconds);
			}
			catch(Exception ex)
			{
				gen.Reset();
				throw ex;
			}
		}
	}
}
