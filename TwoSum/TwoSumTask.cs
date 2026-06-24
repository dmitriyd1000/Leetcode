namespace Algorithm.TwoSum;

public class TwoSumTask
{
    public int[] TwoSum0(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var diff = target - nums[i];
            if (dict.TryGetValue(nums[i], out var value))
            {
                return [value, i];
            }
            // defence from repeatable
            _ = dict.TryAdd(diff, i);
        }
        return Array.Empty<int>();
    }
    
    public int[] TwoSum1(int[] nums, int target)
    {
        var dict = new Dictionary<string, int>();
        var numsExp = new List<(string, int)>();
        for (var i = 0; i < nums.Length; i++)
        {
            _ = dict.TryAdd($"{nums[i]}_{i}", i);
            numsExp.Add(($"{nums[i]}_{i}", nums[i]));
        }
        numsExp = numsExp.OrderBy(x => x.Item2).ThenBy(y => y.Item1).ToList();
        var left = 0;
        var right = numsExp.Count - 1;
        while (left < right)
        {
            var sum = numsExp[left].Item2 + numsExp[right].Item2;
            if (sum == target)
            {
                dict.TryGetValue(numsExp[left].Item1, out var leftIndex);
                dict.TryGetValue(numsExp[right].Item1, out var rightIndex);
                return [leftIndex, rightIndex];
            }
            if (sum < target)
            {
                left++;
            }
            else
            {
                right--;
            }
        }
        return Array.Empty<int>();
    }
}