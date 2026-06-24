namespace Algorithm.TwoSum;

[TestFixture]
public class TwoSumTaskTest
{
    private TwoSumTask _target;

    [SetUp]
    public void SetUp()
    {
        _target = new TwoSumTask();
    }
    
    [TestCase(new int[] {6,3,6,3,4,6,8 }, 7, ExpectedResult = new object[] {1, 4})]
    public object[] TwoSumTaskTest1(int[] nums, int target)
    {
        // arrange

        //act
        var result = _target.TwoSum0(nums, target);
        // assert
        return [result[0], result[1]];
    }
    
    [TestCase(new int[] {6,3,6,3,4,6,8}, 7, ExpectedResult = new object[] {1, 4})]
    [TestCase(new int[] {2,7,11,15}, 9, ExpectedResult = new object[] {0, 1})]
    [TestCase(new int[] {3, 4, 2}, 6, ExpectedResult = new object[] {2, 1})]
    [TestCase(new int[] {3, 3}, 6, ExpectedResult = new object[] {0, 1})]
    public object[] TwoSumTaskTest2(int[] nums, int target)
    {
        // arrange

        //act
        var result = _target.TwoSum1(nums, target);
        // assert
        return [result[0], result[1]];
    }
}