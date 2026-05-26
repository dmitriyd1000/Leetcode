namespace Algorithm.TwoSum;

public class TwoSumTask
{
    public (int, int) TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var diff = target - nums[i];
            if (dict.TryGetValue(nums[i], out var value))
            {
                return (value, i);
            }
            // defence from repeatable
            _ = dict.TryAdd(diff, i);
        }
        return (0,0);
    }
}