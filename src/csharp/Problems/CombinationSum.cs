//https://leetcode.com/problems/combination-sum/

namespace LeetCode.Problems;

public sealed class CombinationSum : ProblemBase
{
    [Theory]
    [ClassData(typeof(CombinationSum))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param(10).Param(12).Result(22))
          .Add(it => it.Param(15).Param(12).Result(27));

    private IList<IList<int>> Solution(int[] candidates, int target)
    {
        return null;
    }
}