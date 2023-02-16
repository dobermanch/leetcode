//https://leetcode.com/problems/minimum-window-substring/

namespace LeetCode.Problems;

public sealed class MinWindow : ProblemBase
{
    [Theory]
    [ClassData(typeof(MinWindow))]
    public override void Test(object[] data) => base.Test(data);

    public override void AddTestCases()
        => Add(it => it.Param("ADOBECODEBANC").Param("ABC").Result("BANC"))
          .Add(it => it.Param("a").Param("a").Result("a"))
          .Add(it => it.Param("a").Param("aa").Result(""));

    private string Solution(string s, string t)
    {
        return null;
    }
}