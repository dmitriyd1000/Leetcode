using NUnit.Framework;

namespace Algorithm;

public class MinDifference
{
    public static void FindMinDifferencePartition(int[] nums)
    {
        int sum = nums.Sum();
        int halfSum = sum / 2;
        int n = nums.Length;

        // Инициализация таблицы
        bool[,] dp = new bool[n + 1, halfSum + 1];
        for (int i = 0; i <= n; i++) dp[i, 0] = true;

        // Заполнение dp таблицы
        for (int i = 1; i <= n; i++)
            for (int j = 1; j <= halfSum; j++)
            {
                dp[i, j] = dp[i - 1, j] || (j >= nums[i - 1] && dp[i - 1, j - nums[i - 1]]);
            }

        // Найти максимальную сумму первого компонента
        int sum1 = 0;
        for (int j = halfSum; j >= 0; j--)
            if (dp[n, j])
            {
                sum1 = j;
                break;
            }

        int sum2 = sum - sum1;
        Console.WriteLine($"Минимальная разница: {Math.Abs(sum2 - sum1)}");

        // Поиск элементов для двух подмножеств
        List<int> subset1 = new List<int>();
        List<int> subset2 = new List<int>();
        int w = sum1;

        for (int i = n; i > 0 && w >= 0; i--)
        {
            if (!dp[i - 1, w])
            {
                subset1.Add(nums[i - 1]);
                w -= nums[i - 1];
            }
            else
                subset2.Add(nums[i - 1]);
        }

        Console.WriteLine("Первое подмножество: " + string.Join(", ", subset1));
        Console.WriteLine("Второе подмножество: " + string.Join(", ", subset2));
    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestFindMinDifference()
    {
        var aa = new List<int> { 3, 7, 5, 6, 2 };
        aa.Sort();
        var bb = aa.ToArray();
        FindMinDifferencePartition(bb);
        Assert.Pass();
    }
}
