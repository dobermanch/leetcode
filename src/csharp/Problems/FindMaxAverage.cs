//https://leetcode.com/problems/maximum-average-subarray-i

namespace LeetCode.Problems;

public sealed class FindMaxAverage : ProblemBase
{
    [Theory]
    [ClassData(typeof(FindMaxAverage))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.ParamArray("[1,12,-5,-6,50,3]").Param(4).Result(12.75000))
          .Add(it => it.ParamArray("[5]").Param(1).Result(5.0))
          .Add(it => it.ParamArray("[-1]").Param(1).Result(-1.0))
          .Add(it => it.ParamArray("[-6662,5432,-8558,-8935,8731,-3083,4115,9931,-4006,-3284,-3024,1714,-2825,-2374,-2750,-959,6516,9356,8040,-2169,-9490,-3068,6299,7823,-9767,5751,-7897,6680,-1293,-3486,-6785,6337,-9158,-4183,6240,-2846,-2588,-5458,-9576,-1501,-908,-5477,7596,-8863,-4088,7922,8231,-4928,7636,-3994,-243,-1327,8425,-3468,-4218,-364,4257,5690,1035,6217,8880,4127,-6299,-1831,2854,-4498,-6983,-677,2216,-1938,3348,4099,3591,9076,942,4571,-4200,7271,-6920,-1886,662,7844,3658,-6562,-2106,-296,-3280,8909,-8352,-9413,3513,1352,-8825]").Param(90).Result(37.25556))
        ;

    private double Solution(int[] nums, int k)
    {
        var result = double.MinValue;
        var window = 0.0;
        for (var i = 0; i < nums.Length; i++)
        {
            window += nums[i];

            var left = i - k + 1;
            var avg = window / k;
            if (left >= 0 && result < avg)
            {
                result = avg;
            }

            if (left >= 0) 
            {
                window -= nums[left];
            }
        }

        return result;
    }
}