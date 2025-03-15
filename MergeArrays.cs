namespace TestProject1;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        Console.Write("Setup");
    }

    public class Tree{
        public int val;
        public Tree? left;
        public Tree? right;
        public Tree(int val) => this.val = val;

        public void Add(int val)
        {
            if (val < this.val)
            {
                if (left == null)
                {
                    left = new Tree(val);
                }
                else
                {
                    left.Add(val);
                }
            }
            else
            {
                if (right == null)
                {
                    right = new Tree(val);
                }
                else
                {
                    right.Add(val);
                }
            }
        }

        public void TransformToList(ref List<int> list)
        {
            if (left != null)
            {
                left.TransformToList(ref list);
            }
            list.Add(val);
            if (right != null)
            {
                right.TransformToList(ref list);
            }
        }
    }

    [TestCase (new int[] {1,2,3,0,0,0}, 3, new int[] {2,5,6}, 3, ExpectedResult = new int[] {1,2,2,3,5,6})]
    [TestCase (new int[] {1}, 1, new int[] {}, 0, ExpectedResult = new int[] {1})]
    [TestCase (new int[] {0}, 0, new int[] {1}, 1, ExpectedResult = new int[] {1})]
    [TestCase (new int[] {2,0}, 1, new int[] {1}, 1, ExpectedResult = new int[] {1,2})]
    [TestCase (new int[] {4,5,6,0,0,0}, 3, new int[] {1,2,3}, 3, ExpectedResult = new int[] {1,2,3,4,5,6})]
    [TestCase (new int[] {4,0,0,0,0,0}, 1, new int[] {1,2,3,5,6}, 5, ExpectedResult = new int[] {1,2,3,4,5,6})]
    public int[] Test2(int[] nums1, int m, int[] nums2, int n)
    {
        for (int i = 0; i < n; i++)
        {
            nums1[m+i] = nums2[i];
        }
        var tree = new Tree(nums1[0]);
        for (int i = 1; i < nums1.Length; i++ )
        {
            tree.Add(nums1[i]);
        }
        var list =  new List<int>();
        tree.TransformToList(ref list);
        nums1 = list.ToArray();
        
        return nums1;
    }

     private void MergeParts(ref int[] inp, int left, int mid,  int right)
        {
            var stp1 = left;
            var stp2 = mid + 1;
            var index = 0;
            var result = new int[right - left + 1];
             
            while (stp1 <= mid && stp2 <= right)
            {
                if(inp[stp1] < inp[stp2])
                {
                    result[index]= inp[stp1];
                    stp1++;
                }
                else
                {
                    result[index]= inp[stp2];
                    stp2++;
                }
                index++;
            }

            while (stp1 <= mid)
            {
                result[index]= inp[stp1];
                stp1++;
                index++;
            }

            while (stp2  <= right)
            {
               result[index]= inp[stp2];
               stp2++;
                index++;
            }

            for (int i = 0; i < result.Length; i++)
            {
                inp[left + i] = result[i];
            }
        }

    private void MergedSortedRecursive(ref int[] inpArr,  int left,  int right, bool IsStart = false)
        {
            if (!IsStart && left >= right)
                return;
            int mid = (left + right)/2;
            MergedSortedRecursive(ref inpArr,  left,  mid);
            MergedSortedRecursive(ref inpArr,  mid + 1,  right);
            MergeParts(ref inpArr, left, mid, right);
        }

     private void Merge(int[] nums1, int m, int[] nums2, int n) {
        for (int i = 0; i < n; i++)
        {
            nums1[m+i] = nums2[i];
        }
        MergedSortedRecursive(ref nums1, 0, m+n-1, true);
     }

    [TestCase (new int[] {1,2,3,0,0,0}, 3, new int[] {2,5,6}, 3, ExpectedResult = new int[] {1,2,2,3,5,6})]
    [TestCase (new int[] {1}, 1, new int[] {}, 0, ExpectedResult = new int[] {1})]
    [TestCase (new int[] {0}, 0, new int[] {1}, 1, ExpectedResult = new int[] {1})]
    [TestCase (new int[] {2,0}, 1, new int[] {1}, 1, ExpectedResult = new int[] {1,2})]
    [TestCase (new int[] {4,5,6,0,0,0}, 3, new int[] {1,2,3}, 3, ExpectedResult = new int[] {1,2,3,4,5,6})]
    [TestCase (new int[] {4,0,0,0,0,0}, 1, new int[] {1,2,3,5,6}, 5, ExpectedResult = new int[] {1,2,3,4,5,6})]
    public int[] Test1(int[] nums1, int m, int[] nums2, int n)
    {
        Merge(nums1, m, nums2, n);
        return nums1;
    }
}
