public class EncodeAndDecodeStringsTests
{
    public static IEnumerable<object[]> Cases()
    {
        yield return new object[] { new List<string> { "lint", "code", "love", "you" } };
        yield return new object[] { new List<string> { "we", "say", ":", "yes" } };
        yield return new object[] { new List<string>() };
        yield return new object[] { new List<string> { "" } };
        yield return new object[] { new List<string> { "a$b", "$$", "" } };
    }

    [Theory]
    [MemberData(nameof(Cases))]
    public void EncodeThenDecode_ReturnsOriginalList(List<string> input)
    {
        var sol = new Solution();

        var encoded = sol.Encode(input);
        var decoded = sol.Decode(encoded);

        Assert.Equal(input, decoded);
    }
}
