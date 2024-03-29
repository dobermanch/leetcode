//https://leetcode.com/problems/restore-ip-addresses/description/

namespace LeetCode.Problems;

public sealed class RestoreIpAddresses : ProblemBase
{
    [Theory]
    [ClassData(typeof(RestoreIpAddresses))]
    public override void Test(object[] data) => base.Test(data);

    protected override void AddTestCases()
        => Add(it => it.Param("25525511135").ResultArray<string>("""["255.255.11.135","255.255.111.35"]"""))
          .Add(it => it.Param("0000").ResultArray<string>("""["0.0.0.0"]"""))
          .Add(it => it.Param("101023").ResultArray<string>("""["1.0.10.23","1.0.102.3","10.1.0.23","10.10.2.3","101.0.2.3"]"""))
        ;

    private IList<string> Solution(string s)
    {
        var result = new List<string>();
        Find(s.AsSpan(), 0, new List<string>(), result);
        //Find(s.AsSpan(), 0, new List<int>(), result);
        return result;
    }

    private static void Find(ReadOnlySpan<char> raw, int index, List<string> temp, IList<string> result)
    {
        if (index == raw.Length)
        {
            if (temp.Count == 4)
            {
                raw.ToString();
                result.Add(string.Join(".", temp));
            }

            return;
        }

        for (var i = 1; i <= 3; i++)
        {
            if (index + i > raw.Length)
            {
                return;
            }

            var segment = raw[index..(index + i)];
            if (segment.Length == 3 && int.Parse(segment) > 255 || segment.Length == 2 && segment[0] == '0')
            {
                return;
            }

            temp.Add(segment.ToString());
            Find(raw, index + i, temp, result);
            temp.RemoveAt(temp.Count - 1);
        }
    }

    private static void Find1(ReadOnlySpan<char> raw, int index, int length, List<int> temp, IList<string> result)
    {
        if (index == raw.Length)
        {
            if (temp.Count >= 3 && temp[2] < index)
            {
                string? buffer = null;
                for (var i = 0; i < raw.Length; i++)
                {
                    if (temp.Contains(i))
                    {
                        buffer += '.';
                    }
                    buffer += raw[i];
                }
                result.Add(buffer!);
            }

            return;
        }
        else if (temp.Count > 3)
        {
            return;
        }

        for (var i = 1; i <= 3; i++)
        {
            if (index + i > raw.Length)
            {
                break;
            }

            var segment = raw[index..(index + i)];
            if (segment.Length == 3 && int.Parse(segment) > 255 || segment.Length == 2 && segment[0] == '0')
            {
                break;
            }

            temp.Add(index + i);

            Find1(raw, index + i, length, temp, result);

            temp.Remove(temp.Last());
        }
    }

    private static void Find2(ReadOnlySpan<char> raw, int index, List<int> temp, IList<string> result)
    {
        if (index == raw.Length)
        {
            if (temp.Count == 4)
            {
                var buffer = new StringBuilder(raw.ToString());
                for (var i = 2; i >= 0; i--)
                {
                    buffer.Insert(temp[i], ".");
                }
                result.Add(buffer.ToString());
            }

            return;
        }

        for (var i = 1; i <= 3; i++)
        {
            if (index + i > raw.Length)
            {
                break;
            }

            var segment = raw[index..(index + i)];
            if (segment.Length == 3 && int.Parse(segment) > 255 || segment.Length == 2 && segment[0] == '0')
            {
                return;
            }

            temp.Add(index + i);

            Find2(raw, index + i, temp, result);

            temp.Remove(temp.Last());
        }
    }
}