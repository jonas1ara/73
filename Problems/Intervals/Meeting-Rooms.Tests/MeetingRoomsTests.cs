public class MeetingRoomsTests
{
    [Fact]
    public void CanAttendMeetings_OverlappingIntervals_ReturnsFalse()
    {
        var sol = new Solution();
        var intervals = new List<Interval>
        {
            new Interval(0, 30),
            new Interval(5, 10),
            new Interval(15, 20)
        };

        var result = sol.CanAttendMeetings(intervals);

        Assert.False(result);
    }

    [Fact]
    public void CanAttendMeetings_NonOverlappingIntervals_ReturnsTrue()
    {
        var sol = new Solution();
        var intervals = new List<Interval>
        {
            new Interval(7, 10),
            new Interval(2, 4)
        };

        var result = sol.CanAttendMeetings(intervals);

        Assert.True(result);
    }

    [Fact]
    public void CanAttendMeetings_SingleInterval_ReturnsTrue()
    {
        var sol = new Solution();
        var intervals = new List<Interval> { new Interval(1, 5) };

        var result = sol.CanAttendMeetings(intervals);

        Assert.True(result);
    }

    [Fact]
    public void CanAttendMeetings_TouchingEndpoints_ReturnsTrue()
    {
        var sol = new Solution();
        var intervals = new List<Interval>
        {
            new Interval(1, 5),
            new Interval(5, 10)
        };

        var result = sol.CanAttendMeetings(intervals);

        Assert.True(result);
    }
}
