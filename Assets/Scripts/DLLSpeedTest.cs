using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class DLLSpeedTest : MonoBehaviour
{
    [DllImport("JoaqSort", EntryPoint = "JoaqSort")]
    public static extern void JoaqSort(int[] a, int length);


    private int[] arr1 = new int[DataToSortHolder.Length];
    private int[] arr2 = new int[DataToSortHolder.Length];
    void Start()
    {
        arr1 = DataToSortHolder.DataToSort;
        arr2 = DataToSortHolder.DataToSort;

        MeasureFunctionExecutionTime(NativeSort);

        MeasureFunctionExecutionTime(ManagedSort);
    }

    void NativeSort()
    {
        JoaqSort(arr1, arr1.Length);
    }

    void ManagedSort()
    {
        JoaqSortManaged.JoaqSort.Sort(arr2);
    }


    void MeasureFunctionExecutionTime(Action Function)
    {
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start(); // Start timing
        Function(); // Call the function you want to measure
        stopwatch.Stop();  // Stop timing

        // Get the elapsed time
        long elapsedMilliseconds = stopwatch.ElapsedMilliseconds;
        UnityEngine.Debug.Log($"{Function.Method.Name} took {elapsedMilliseconds} ms to execute.");
    }

}



