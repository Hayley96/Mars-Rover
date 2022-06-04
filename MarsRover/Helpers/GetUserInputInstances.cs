using System.Reflection;
public static class GetUserInputInstances
{
    public static IEnumerable<Type> subclasses { get; private set; }
    private static Assembly assembly = Assembly.GetExecutingAssembly();
    private static Type[] types = assembly.GetTypes();
    public static object Get(string className, Type parentType, params object[] paramArray)
    {
        Type type = types.First(t => t.Name == className);

        return Activator.CreateInstance(type, args:paramArray);
    }

    public static IEnumerable<Type> GetSubclasses(Type parentType)
    {
        return subclasses = types.Where(t => t.IsSubclassOf(parentType));
    }
}