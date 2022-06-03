using System.Reflection;
public static class GetUserInputInstances
{
    public static IEnumerable<Type> subclasses { get; private set; }
    public static object Get(string className, Type parentType, params object[] paramArray)
    {
        var assembly = Assembly.GetExecutingAssembly();

        Type[] types = assembly.GetTypes();

        var type = types.First(t => t.Name == className);

        subclasses = types.Where(t => t.IsSubclassOf(parentType));

        return Activator.CreateInstance(type, args:paramArray);
    }
}