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
			do
			{
				var cmd = Console.ReadLine();
				Console.Write(">");
				try
				{
					args = SplitArguments(cmd);
					if (args[0] != "exit") {

						Type x = Type.GetType(args[0]);

						exp = Activator.CreateInstance(x) as Experiment;
						exp.Run(args.Skip(1).ToArray());
					}
					else
						break;
				}
				catch (Exception ex)
				{
					var bk = Console.BackgroundColor;
					Console.BackgroundColor = ConsoleColor.Red;
					Console.WriteLine(ex);
					Console.BackgroundColor = bk;
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
