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