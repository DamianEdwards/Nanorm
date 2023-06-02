using System.Data;

namespace Nanorm;

#if NET7_0_OR_GREATER
/// <summary>
/// Interface for statically creating an instance of <typeparamref name="T"/> from an <see cref="IDataRecord"/>.
/// </summary>
/// <typeparam name="T">The type that the implementer of <see cref="IDataRecordMapper{T}"/> can create instances of.</typeparam>
public interface IDataRecordMapper<T> where T : IDataRecordMapper<T>
{
    /// <summary>
    /// Maps the <paramref name="dataRecord"/> to an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <param name="dataRecord">The <see cref="IDataRecord"/>.</param>
    /// <returns>A new instance of <typeparamref name="T"/>.</returns>
#pragma warning disable CA1000 // Do not declare static members on generic types
    abstract static T Map(IDataRecord dataRecord);
#pragma warning restore CA1000 // Do not declare static members on generic types
}
#endif
