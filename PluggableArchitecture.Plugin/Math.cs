namespace PluggableArchitecture.Plugin
{
	using PluggableArchitecture.Interface;

	internal class Math : IMath
	{
		public string Name
		{
			get
			{
				return "Math";
			}
		}

		public string Version
		{
			get
			{
				return "1.0.0.0";
			}
		}

		public int Compute(int arg1, int arg2)
		{
			return arg1 * arg2;
		}
	}
}