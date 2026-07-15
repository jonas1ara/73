public class MeetingRoomsIITests
{
    [Fact]
    public void MinMeetingRooms_OverlappingIntervals_ReturnsTwo()
    {
        var sol = new Solution();
        var intervals = new List<Interval>
        {
            new Interval(0, 30),
            new Interval(5, 10),
            new Interval(15, 20)
        };

        var result = sol.MinMeetingRooms(intervals);

        Assert.Equal(2, result);
    }

    [Fact]
    public void MinMeetingRooms_NonOverlappingIntervals_ReturnsOne()
    {
        var sol = new Solution();
        var intervals = new List<Interval>
        {
            new Interval(7, 10),
            new Interval(2, 4)
        };

        var result = sol.MinMeetingRooms(intervals);

        Assert.Equal(1, result);
    }

    [Fact]
    public void MinMeetingRooms_SingleInterval_ReturnsOne()
    {
        var sol = new Solution();
        var intervals = new List<Interval> { new Interval(2, 7) };

        var result = sol.MinMeetingRooms(intervals);

        Assert.Equal(1, result);
    }

    [Fact]
    public void MinMeetingRooms_AllSameTime_ReturnsCountOfIntervals()
    {
        var sol = new Solution();
        var intervals = new List<Interval>
        {
            new Interval(1, 10),
            new Interval(1, 10),
            new Interval(1, 10)
        };

        var result = sol.MinMeetingRooms(intervals);

        Assert.Equal(3, result);
    }
}
