using Microsoft.Data.Sqlite;

namespace Nanorm.Sqlite;

public interface IDataReaderMapper<T> where T : IDataReaderMapper<T>
{
    abstract static T Map(SqliteDataReader dataReader);
}
