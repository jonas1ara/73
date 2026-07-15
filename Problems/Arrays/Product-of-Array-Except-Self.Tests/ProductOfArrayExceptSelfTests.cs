public class ProductOfArrayExceptSelfTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4 }, new int[] { 24, 12, 8, 6 })]
    [InlineData(new int[] { -1, 1, 0, -3, 3 }, new int[] { 0, 0, 9, 0, 0 })]
    [InlineData(new int[] { 3, 4 }, new int[] { 4, 3 })]
    public void ProductExceptSelf_ReturnsProductOfAllOtherElements(int[] nums, int[] expected)
    {
        var sol = new Solution();

        var result = sol.ProductExceptSelf(nums);

        Assert.Equal(expected, result);
    }
}
