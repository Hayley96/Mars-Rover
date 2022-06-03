public static class AddItemToList
{
    public static List<T> Add<T>(this List<T> list, T item)
    {
        list.Add(item);
        return list;
    }
}