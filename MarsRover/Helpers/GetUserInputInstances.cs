using System.Reflection;
public static class GetUserInputInstances
{
    public static IEnumerable<Type>? Subclasses { get; private set; }
    private static readonly Assembly assembly = Assembly.GetExecutingAssembly();
    private static readonly List<Type> types = assembly.GetTypes().ToList();
    public static object Get(string className, Type parentType, params object[] paramArray)
    {
        Type type = types.First(t => t.Name == className);
        var instance = Activator.CreateInstance(type, paramArray);

        return instance!;
    }

    public static IEnumerable<Type> GetSubclasses(Type parentType)
    {
        return Subclasses = types.Where(t => t.IsSubclassOf(parentType));
    }
}