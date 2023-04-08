using System.Data.Common;

namespace Nanorm;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IDataReaderMapper<T> where T : IDataReaderMapper<T>
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dataReader"></param>
    /// <returns></returns>
#pragma warning disable CA1000 // Do not declare static members on generic types
    abstract static T Map(DbDataReader dataReader);
#pragma warning restore CA1000 // Do not declare static members on generic types
}
