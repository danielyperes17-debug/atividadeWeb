
using MySql.Data.MySqlClient;

namespace AppWebExemplo.Configs
{
    public static class DAOHelper
    {
        // Lê uma string; se a coluna for NULL, devolve string vazia.
        public static string GetString(
            MySqlDataReader reader,
            string column_name)
        {
            if (reader.IsDBNull(reader.GetOrdinal(column_name)))
            {
                return string.Empty;
            }

            return reader.GetString(column_name);
        }

        // Lê um double; se a coluna for NULL, devolve 0.0.
        public static double GetDouble(
            MySqlDataReader reader,
            string column_name)
        {
            if (reader.IsDBNull(reader.GetOrdinal(column_name)))
            {
                return 0.0;
            }

            return reader.GetDouble(column_name);
        }

        // Lê uma data; se a coluna for NULL, devolve null.
        public static DateTime? GetDateTime(
            MySqlDataReader reader,
            string column_name)
        {
            if (reader.IsDBNull(reader.GetOrdinal(column_name)))
            {
                return null;
            }

            return reader.GetDateTime(column_name);
        }

        // Indica se uma coluna está NULL.
        public static bool IsNull(
            MySqlDataReader reader,
            string column_name)
        {
            return reader.IsDBNull(reader.GetOrdinal(column_name));
        }
    }
}
