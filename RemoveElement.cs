using NUnit.Framework;

namespace Algorithm;

public class RemoveElementTest
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(new int[]{3,2,2,3}, new int[]{2, 2}, 3, ExpectedResult = 2)]
    public int Test1(int[] nums, int[] expectedNums, int val)
    {
        for(int i = 0; i < expectedNums.Length; i++){
            if(nums[i] != expectedNums[i]){
                return -1;
            }
        }
        return RemoveElement(nums, val);
    }

    [TestCase(new int[]{3,2,2,3}, new int[]{2, 2}, 3, ExpectedResult = 2)]
    [TestCase(new int[]{0,1,2,2,3,0,4,2}, new int[]{0,1,3,0,4}, 2, ExpectedResult = 5)]
     public int Test2(int[] nums, int[] expectedNums, int val)
    {
        var numsLength = nums.Length;
        for(int i = 0; i < numsLength; i++){
            if(nums[i] == val){
                for(int j = i; j < numsLength - 1; j++){
                    nums[j] = nums[j + 1];
                }
                numsLength--;
                i--;
            }
        }
        return numsLength;
    }

    private int RemoveElement(int[] nums, int val) {
        int i = 0;
        for(i = 0; i < nums.Length; i++){
            if(nums[i] == val){
                for(int j = i; j < nums.Length - 1; j++){
                    nums[j] = nums[j + 1];
                }
                i--;
            }
        }
        return i;
    }

    public class Vector{
        public Vector? Next { get; set; }
        private int val;

        public Vector(int val){
            this.val = val;
            Next = null;
        }

        public void Add(int val){
            if(Next == null){
                Next = new Vector(val);
                Next.val = val;
            }else{
                Next.Add(val);
            }
        }

        public bool Remove(int val){
            if(Next == null){
                return false;
            }
            if(Next.val == val){
                Next = Next.Next;
            }else{
                Next.Remove(val);
            }
            return true;
        }
    }
}
