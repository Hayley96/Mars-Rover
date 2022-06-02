using System.Reflection;
public static class GetUserInputInstances
{
    public static object Get(string className, params object[] paramArray)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var type = assembly.GetTypes().First(t => t.Name == className);

        return Activator.CreateInstance(type, args:paramArray);
    }
}