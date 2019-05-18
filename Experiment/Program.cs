using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace Experiment
{
	class Program
	{

		static void Main(string[] args)
		{
			Experiment exp = null;
			var bk = Console.ForegroundColor;
			do
			{				
				Console.Write("> ");
				var cmd = Console.ReadLine();
				try
				{
					args = SplitArguments(cmd);
					if (args[0] != "exit") {

						Type x = Type.GetType("Experiment." + args[0]);
						if (x == null)
							throw new Exception("Invalid command");
						exp = Activator.CreateInstance(x) as Experiment;
						Console.ForegroundColor = bk;
						exp.Run(args.Skip(1).ToArray());
					}
					else
						break;
				}
				catch (Exception ex)
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine(ex);
					Console.ForegroundColor = bk;
				}


			} while (true);

		}

		public static string[] SplitArguments(string commandLine)
		{
			var parmChars = commandLine.ToCharArray();
			var inSingleQuote = false;
			var inDoubleQuote = false;
			for (var index = 0; index < parmChars.Length; index++)
			{
				if (parmChars[index] == '"' && !inSingleQuote)
				{
					inDoubleQuote = !inDoubleQuote;
					parmChars[index] = '\n';
				}
				if (parmChars[index] == '\'' && !inDoubleQuote)
				{
					inSingleQuote = !inSingleQuote;
					parmChars[index] = '\n';
				}
				if (!inSingleQuote && !inDoubleQuote && parmChars[index] == ' ')
					parmChars[index] = '\n';
			}
			return (new string(parmChars)).Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
		}
	}
}
