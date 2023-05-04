using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nanorm.Sqlite;
internal static class SqliteQueryExtension
{

    /// <summary>
    /// Parses a sqlite parameter query into a named paramenter query
    /// </summary>
    /// <param name="query">Command Text</param>
    /// <returns>Returns a name parameter command text</returns>
    public static string ParseQuery(this string query)
    {
        ExceptionHelpers.ThrowIfNullOrEmpty(query);

        var hasQuestionMarks = query.Contains('?');
        if(hasQuestionMarks)
            query = query.Replace("?", "@param");
        return query;
    }
}
