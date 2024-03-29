namespace LeetCode.Models;

public class Matrix : Matrix<int>
{
    public Matrix() { }
    public Matrix(int[][] matrix) : base(matrix) { }

    public static Matrix Parse(string? input) => input.To2dArray<int>(false);

    public static implicit operator int[][](Matrix matrix) => matrix._matrix.ToArray();

    public static implicit operator Matrix(int[][] matrix) => new(matrix);
}

public class Matrix<T> : IEquatable<Matrix<T>>
{
    protected readonly IList<T[]> _matrix;

    public Matrix() => _matrix = new List<T[]>();

    public Matrix(T[][] matrix) => _matrix = matrix;

    public T[] this[int row] => _matrix[row];

    public Matrix<T> Row(params T[] row)
    {
        _matrix.Add(row);
        return this;
    }

    public int Length => _matrix.Count;

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("[");
        for (int i = 0; i < _matrix.Count; i++)
        {
            sb.Append("[");
            for (int j = 0; j < _matrix[i].Length; j++)
            {
                sb.Append($"{_matrix[i][j]},");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("],");
        }

        sb.Remove(sb.Length - 1, 1);
        sb.Append("]");

        return sb.ToString();
    }

    public bool Equals(Matrix<T>? other)
        => !ReferenceEquals(null, other)
           && (ReferenceEquals(this, other)
               || _matrix.Equals(other._matrix)
               || _matrix.Count == other._matrix.Count
               && !_matrix.Where((t, i) => !t.SequenceEqual(other._matrix[i])).Any());

    public override bool Equals(object? obj)
        => !ReferenceEquals(null, obj)
           && (ReferenceEquals(this, obj)
               || obj.GetType() == GetType()
               && Equals((Matrix<T>)obj));

    public override int GetHashCode() => _matrix.GetHashCode();

    public static implicit operator T[][](Matrix<T> matrix) => matrix._matrix.ToArray();

    public static implicit operator Matrix<T>(T[][] matrix) => new(matrix);
}