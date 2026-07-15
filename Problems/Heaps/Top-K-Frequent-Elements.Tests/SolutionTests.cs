public class SolutionTests
{
    [Fact]
    public void TopKFrequent_OfficialExampleOne_ReturnsTwoMostFrequent()
    {
        var sol = new Solution();

        var result = sol.TopKFrequent(new int[] { 1, 1, 1, 2, 2, 3 }, 2);

        Assert.Equal(new[] { 1, 2 }, result);
    }

    [Fact]
    public void TopKFrequent_OfficialExampleTwo_SingleElement_ReturnsThatElement()
    {
        var sol = new Solution();

        var result = sol.TopKFrequent(new int[] { 1 }, 1);

        Assert.Equal(new[] { 1 }, result);
    }

    [Fact]
    public void TopKFrequent_KEqualsDistinctCount_ReturnsAllDistinctValues()
    {
        var sol = new Solution();

        var result = sol.TopKFrequent(new int[] { 4, 4, 5, 5, 6, 6 }, 3);

        Assert.Equal(new[] { 4, 5, 6 }, result.OrderBy(x => x));
    }

    [Fact]
    public void TopKFrequent_KEqualsArrayLength_ReturnsArrayAsIs()
    {
        var sol = new Solution();
        var nums = new int[] { 7, 8, 9 };

        var result = sol.TopKFrequent(nums, 3);

        Assert.Equal(new[] { 7, 8, 9 }, result.OrderBy(x => x));
    }

    [Fact]
    public void TopKFrequent_KOne_ReturnsMostFrequentElement()
    {
        var sol = new Solution();

        var result = sol.TopKFrequent(new int[] { 3, 0, 1, 0, 4, 0 }, 1);

        Assert.Equal(new[] { 0 }, result);
    }

    [Fact]
    public void TopKFrequent_WithNegativeNumbers_ReturnsMostFrequentValues()
    {
        var sol = new Solution();

        var result = sol.TopKFrequent(new int[] { -1, -1, -1, -2, -2, -3 }, 2);

        Assert.Equal(new[] { -1, -2 }, result);
    }

    [Fact]
    public void TopKFrequent_LargerMixedFrequencies_ReturnsCorrectSet()
    {
        var sol = new Solution();

        var result = sol.TopKFrequent(new int[] { 1, 2, 2, 3, 3, 3, 4, 4, 4, 4 }, 3);

        Assert.Equal(new[] { 2, 3, 4 }, result.OrderBy(x => x));
    }
}
