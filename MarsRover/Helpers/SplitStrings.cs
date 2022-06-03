public static class SplitStrings
{
    public static int SplitIntDataIndex0(string input) =>
        int.Parse(input.Split(" ")[0]);

    public static int SplitIntDataIndex1(string input) =>
        int.Parse(input.Split(" ")[1]);

    public static string SplitDataIndex2(string input) =>
         input.Split(" ")[2];
}