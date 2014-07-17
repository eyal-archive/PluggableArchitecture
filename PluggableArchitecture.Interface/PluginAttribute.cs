namespace PluggableArchitecture.Interface
{
	using System;

	public enum PluginSections
	{
		Unknown,
		Math,
	}

	[AttributeUsage(AttributeTargets.Class)]
	public class PluginAttribute : Attribute
	{
		private readonly PluginSections _section;

		public PluginAttribute(PluginSections section)
		{
			_section = section;
		}

		public PluginSections Section
		{
			get { return _section; }
		}
	}
}
