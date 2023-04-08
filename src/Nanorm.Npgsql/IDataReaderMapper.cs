using Npgsql;

namespace Nanorm.Npgsql;

public interface IDataReaderMapper<T> where T : IDataReaderMapper<T>
{
    abstract static T Map(NpgsqlDataReader dataReader);
}
