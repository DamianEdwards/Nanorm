using System.Runtime.InteropServices;
using Npgsql;

namespace Nanorm.Npgsql;

/// <summary>
/// 
/// </summary>
[StructLayout(LayoutKind.Explicit)]
public ref struct ParameterValue
{
    [FieldOffset(0)]
    public short ShortValue;

    [FieldOffset(0)]
    public int IntValue;

    [FieldOffset(0)]
    public long LongValue;

    [FieldOffset(0)]
    public object BoxedValue;

    [FieldOffset(8)]
    public Type ValueType;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    public static implicit operator ParameterValue(int value) => new() { IntValue = value };

    public static implicit operator ParameterValue(long value) => new() { LongValue = value };

    public static implicit operator NpgsqlParameter(ParameterValue value)
    {
        NpgsqlParameter? parameter = default;

        if (value.ValueType == typeof(short))
        {
            parameter = new NpgsqlParameter<short> { Value = value.ShortValue };
        }
        else if (value.ValueType == typeof(int))
        {
            parameter = new NpgsqlParameter<int> { Value = value.IntValue };
        }
        else if (value.ValueType == typeof(long))
        {
            parameter = new NpgsqlParameter<long> { Value = value.LongValue };
        }
        else
        {
            parameter = new() { Value = value.BoxedValue };
        }

        return parameter;
    }
}
