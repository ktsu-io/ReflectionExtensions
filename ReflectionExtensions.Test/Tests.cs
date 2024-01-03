namespace ktsu.io.ReflectionExtensions.Test;

using System.Reflection;

public abstract class TestsBase
{
	public static void TestStatic()
	{
	}
}

[TestClass]
public class Tests : TestsBase
{
	[TestMethod]
	public void TestBase()
	{
		var type = typeof(Tests);
		string methodName = nameof(TestStatic);
		var bindingFlags = BindingFlags.Public | BindingFlags.Static;
		bool result = type.TryFindMethod(methodName, bindingFlags, out var methodInfo);
		Assert.IsTrue(result);
		Assert.IsNotNull(methodInfo);
	}

	[TestMethod]
	public void TestVirtualStatic()
	{
		var type = typeof(Tests);
		string methodName = nameof(TestStatic);
		var bindingFlags = BindingFlags.Public | BindingFlags.Static;
		bool result = type.TryFindMethod(methodName, bindingFlags, out var methodInfo);
		Assert.IsTrue(result);
		Assert.IsNotNull(methodInfo);
	}

	[TestMethod]
	public void TestNegative()
	{
		var type = typeof(Tests);
		string methodName = nameof(TestVirtualStatic);
		var bindingFlags = BindingFlags.Public | BindingFlags.Static;
		bool result = type.TryFindMethod(methodName, bindingFlags, out var methodInfo);
		Assert.IsFalse(result);
		Assert.IsNull(methodInfo);
	}
}
