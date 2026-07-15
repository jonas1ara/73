public class MedianFinderTests
{
    [Fact]
    public void FindMedian_MatchesOfficialExampleWalkthrough()
    {
        var medianFinder = new MedianFinder();

        medianFinder.AddNum(1);
        medianFinder.AddNum(2);
        Assert.Equal(1.5, medianFinder.FindMedian());

        medianFinder.AddNum(3);
        Assert.Equal(2.0, medianFinder.FindMedian());
    }

    [Fact]
    public void FindMedian_SingleElement_ReturnsThatElement()
    {
        var medianFinder = new MedianFinder();

        medianFinder.AddNum(5);

        Assert.Equal(5.0, medianFinder.FindMedian());
    }

    [Fact]
    public void FindMedian_TwoEqualElements_ReturnsAverage()
    {
        var medianFinder = new MedianFinder();

        medianFinder.AddNum(4);
        medianFinder.AddNum(4);

        Assert.Equal(4.0, medianFinder.FindMedian());
    }

    [Fact]
    public void FindMedian_OddCountWithDuplicates_ReturnsMiddleValue()
    {
        var medianFinder = new MedianFinder();

        medianFinder.AddNum(2);
        medianFinder.AddNum(2);
        medianFinder.AddNum(2);

        Assert.Equal(2.0, medianFinder.FindMedian());
    }

    [Fact]
    public void FindMedian_DescendingInsertionOrder_KeepsMedianCorrect()
    {
        var medianFinder = new MedianFinder();

        medianFinder.AddNum(5);
        medianFinder.AddNum(4);
        medianFinder.AddNum(3);
        medianFinder.AddNum(2);
        medianFinder.AddNum(1);

        Assert.Equal(3.0, medianFinder.FindMedian());
    }

    [Fact]
    public void FindMedian_WithNegativeNumbers_ReturnsCorrectMedian()
    {
        var medianFinder = new MedianFinder();

        medianFinder.AddNum(-1);
        medianFinder.AddNum(-2);
        medianFinder.AddNum(-3);
        medianFinder.AddNum(-4);
        medianFinder.AddNum(-5);

        Assert.Equal(-3.0, medianFinder.FindMedian());
    }

    [Fact]
    public void FindMedian_LargerEvenStream_ReturnsAverageOfMiddleTwo()
    {
        var medianFinder = new MedianFinder();

        foreach (var num in new[] { 6, 10, 2, 6, 5, 0 })
        {
            medianFinder.AddNum(num);
        }

        Assert.Equal(5.5, medianFinder.FindMedian());
    }
}
