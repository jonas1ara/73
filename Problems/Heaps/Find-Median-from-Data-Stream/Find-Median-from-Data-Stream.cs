using System;
using System.Collections.Generic;

// Using two heaps - Time: O(log(n))

public class MedianFinder
{
    private SortedSet<(int num, int index)> sm = new SortedSet<(int num, int index)>();
    private SortedSet<(int num, int index)> gt = new SortedSet<(int num, int index)>();
    private int index = 0;

    public MedianFinder() { }

    public void AddNum(int num)
    {
        if (gt.Count > 0 && num > gt.Min.num)
        {
            gt.Add((num, index++));
            if (gt.Count > sm.Count)
            {
                sm.Add(gt.Min);
                gt.Remove(gt.Min);
            }
        }
        else
        {
            sm.Add((num, index++));
            if (sm.Count > gt.Count + 1)
            {
                gt.Add(sm.Max);
                sm.Remove(sm.Max);
            }
        }
    }

    public double FindMedian()
    {
        return sm.Count > gt.Count ? sm.Max.num : (sm.Max.num + gt.Min.num) / 2.0;
    }
}

class Program
{
    static void Main()
    {
        MedianFinder medianFinder = new MedianFinder();

        Console.WriteLine("Input");
        Console.WriteLine("[\"MedianFinder\", \"addNum\", \"addNum\", \"findMedian\", \"addNum\", \"findMedian\"]");
        Console.WriteLine("[[], [1], [2], [], [3], []]");

        Console.WriteLine("Output");

        List<object> outputList = new List<object>();

        outputList.Add(null); // Output of MedianFinder constructor

        outputList.Add(null); // Output of AddNum(1)
        medianFinder.AddNum(1);

        outputList.Add(null); // Output of AddNum(2)
        medianFinder.AddNum(2);

        outputList.Add(medianFinder.FindMedian()); // Output of FindMedian()
        
        outputList.Add(null); // Output of AddNum(3)
        medianFinder.AddNum(3);

        outputList.Add(medianFinder.FindMedian()); // Output of FindMedian()

        // Print the formatted output
        Console.WriteLine("[" + string.Join(", ", outputList.Select(x => FormatOutput(x))) + "]");
    }

    static string FormatOutput(object output)
    {
        return output == null ? "null" : output.ToString();
    }
}


