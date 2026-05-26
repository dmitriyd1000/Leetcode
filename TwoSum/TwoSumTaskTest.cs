using Shouldly;

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
    
    [TearDown]
    public void TearDown()
    {
        
    }
    
    [TestCase(new int[] {6,3,6,3,4,6,8 }, 7, ExpectedResult = new object[] {1, 4})]
    public object[] TwoSumTaskTest1(int[] nums, int target)
    {
        // arrange

        //act
        var result = _target.TwoSum(nums, target);
        // assert
        return [result.Item1, result.Item2];
    }
}