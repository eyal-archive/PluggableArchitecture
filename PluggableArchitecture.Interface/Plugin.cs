namespace PluggableArchitecture.Interface
{
	using System;
	using System.IO;
	using System.Linq;
	using System.Reflection;

	public static class Plugin
	{
		public static T CreatePlugin<T>(string file)
		{
			T plugin = default(T);

			if (File.Exists(file))
			{
				Assembly asm = Assembly.LoadFile(file);

				if (asm != null)
				{
					foreach (var type in asm.GetTypes().Where(type => type.IsImplementationOf(typeof(IPluginBase))))
					{
						plugin = (T)Activator.CreateInstance(type);
					}
				}
			}

			return plugin;
		}

		private static bool IsImplementationOf(this Type type, Type @interface)
		{
			Type[] interfaces = type.GetInterfaces();

			return interfaces.Any(current => IsSubtypeOf(ref current, @interface));
		}

		private static bool IsSubtypeOf(ref Type a, Type b)
		{
			if (a == b)
			{
				return true;
			}

			if (a.IsGenericType)
			{
				a = a.GetGenericTypeDefinition();

				if (a == b)
				{
					return true;
				}
			}

			return false;
		}
	}
}