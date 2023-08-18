﻿namespace LeetCode.Core.Parsers;

internal class IntValueParser : ValueParserBase<int>
{
    private readonly NullIntValueParser _parser = new();

    public override bool TryParse(ReadOnlySpan<char> input, out int result)
    {
        if (_parser.TryParse(input, out var value) && value.HasValue)
        {
            result = (int)value;

            return true;
        }

        result = default;

        return false;
    }
}
