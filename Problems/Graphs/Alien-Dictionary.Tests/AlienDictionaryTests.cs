public class AlienDictionaryTests
{
    [Theory]
    [InlineData(new string[] { "wrt", "wrf", "er", "ett", "rftt" }, "wertf")]
    [InlineData(new string[] { "z", "x" }, "zx")]
    [InlineData(new string[] { "z", "x", "z" }, "")]
    public void AlienOrder_ReturnsTopologicalOrderOrEmptyOnCycle(string[] words, string expected)
    {
        var sol = new Solution();

        var result = sol.AlienOrder(words);

        Assert.Equal(expected, result);
    }
}
