namespace PluggableArchitecture.Host
{
	using System;

	using PluggableArchitecture.Interface;

	internal class Program
	{
		private static void Main(string[] args)
		{
			string filePath = Environment.CurrentDirectory + @"\PluggableArchitecture.Plugin.dll";

			IMath math = Plugin.CreatePlugin<IMath>(filePath);

			Console.WriteLine();

			if (math != null)
			{
				Console.Write(" Add the 1st number to compute: ");
				int arg1 = Convert.ToInt32(Console.ReadLine());

				Console.Write(" Add the 2nd number to compute: ");
				int arg2 = Convert.ToInt32(Console.ReadLine());

				Console.WriteLine();
				Console.WriteLine(" Results: " + math.Compute(arg1, arg2));
			}
			else
			{
				Console.WriteLine(" No plugins were found.");
			}

			Console.ReadKey(true);
		}
	}
}