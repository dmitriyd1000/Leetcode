namespace Algorithm.MinDifference;

[TestFixture]
public class MinDifferenceTest
{
    private MinDifference _target;

    [SetUp]
    public void Setup()
    {
        _target = new MinDifference();
    }

    [Test]
    public void TestFindMinDifference()
    {
        var aa = new List<int> { 3, 7, 5, 6, 2 };
        aa.Sort();
        var bb = aa.ToArray();
        _target.FindMinDifferencePartition(bb);
        Assert.Pass();
    }
}