
public static class DataToSortHolder
{
    public static readonly int Length = 100000;
    public static int[] DataToSort
    {
        get
        {
            int[] arr = new int[Length];
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = UnityEngine.Random.Range(1000000, 1000000000);
            }
            return arr;
        }
    }
}