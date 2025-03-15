using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Algorithm;

public class MaxNumberEvents
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        var events = new int[][] {new int[]{1, 4}, new int[]{4, 4}, new int[]{2, 2}, new int[]{3, 4}, new int[]{1, 1}};
        int n = events.Length;
        var schedule =  new Dictionary<int, int>();
        var sumEvents = 0;
        for (int i = 0; i < n; i++)
        {
            var evFirst = events[i][0];
            var evLast = events[i].LastOrDefault();
            for (int j = evFirst; j <= evLast; j++)
            {
                if (j == evFirst || j == evLast)
                {
                    // проверка на пересечение
                    if (schedule.Keys.Contains(j) && schedule[j] == 2)
                    {
                        // если пересекается, то вычисляем границу предыдущего события
                        var prev = j;
                        while (schedule[prev] == 1)
                        {
                            prev--;
                        }
                        {
                            prev--;
                        }

                        var next = j;
                        while (schedule[next] == 1)
                        {
                            next++;
                        }
                        
                        // сравниваем длину текущего события с длиной предыдущего
                        // если текущее событие короче, то удаляем предыдущее
                        if (next - prev + 1 > evLast - evFirst + 1)
                        {
                            for (int k = prev; k < next; k++)
                            {
                                schedule.Remove(k);
                            }
                            sumEvents++;
                        }
                        // если текущее событие длиннее, то пропускаем его
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        sumEvents++;
                        schedule[j] =1;
                    }
                }
                else
                {
                   schedule[j] =2;
                }
            }
        }

        Assert.That(sumEvents, Is.EqualTo(8));
    }
}
