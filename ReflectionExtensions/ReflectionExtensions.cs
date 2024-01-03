namespace ktsu.io.ReflectionExtensions;

using System.Reflection;

public static class ReflectionExtensions
{
	public static bool TryFindMethod(this Type type, string methodName, BindingFlags bindingFlags, out MethodInfo? methodInfo)
	{
		ArgumentNullException.ThrowIfNull(type);
		ArgumentException.ThrowIfNullOrEmpty(methodName);

		methodInfo = null;
		var methodOwner = type;
		while (methodInfo is null && methodOwner is not null)
		{
			methodInfo = methodOwner.GetMethod(methodName, bindingFlags);
			if (methodInfo is null)
			{
				methodOwner = methodOwner.BaseType;
			}
		}

		return methodInfo is not null;
	}
}
