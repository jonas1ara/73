public class CourseScheduleTests
{
    public static IEnumerable<object[]> CanFinishCases()
    {
        yield return new object[] { 2, new int[][] { new int[] { 1, 0 } }, true };
        yield return new object[] { 2, new int[][] { new int[] { 1, 0 }, new int[] { 0, 1 } }, false };
        yield return new object[] { 1, new int[][] { }, true };
        yield return new object[] { 4, new int[][] { new int[] { 1, 0 }, new int[] { 2, 1 }, new int[] { 3, 2 } }, true };
        yield return new object[] { 3, new int[][] { new int[] { 0, 1 }, new int[] { 1, 2 }, new int[] { 2, 0 } }, false };
    }

    [Theory]
    [MemberData(nameof(CanFinishCases))]
    public void CanFinish_DetectsWhetherAllCoursesCanBeCompleted(int numCourses, int[][] prerequisites, bool expected)
    {
        var sol = new Solution();

        var result = sol.CanFinish(numCourses, prerequisites);

        Assert.Equal(expected, result);
    }
}
