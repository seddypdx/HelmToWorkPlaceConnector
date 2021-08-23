using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HelmToWorkPlaceConnector.Services.Services
{
  

    public class SqlService
    {
        DbContext _context;
        public SqlService(DbContext context)
        {
            _context = context;

        }

        public double AggregateLookup(string sql)
        {

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = sql;
                _context.Database.OpenConnection();
                object result = command.ExecuteScalar();

                if (result == null)
                    return 0;

                double retval = 0;
                if (double.TryParse(result.ToString(), out retval))
                    return retval;

                return 0;


            }
        }

        public double ExecSproc(string sproc, SqlParameter[] parameters)
        {

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = sproc;

                //SqlParameter newParam = new SqlParameter(strName, guidValue);

                foreach (SqlParameter parameter in parameters)
                    command.Parameters.Add(parameter);


                _context.Database.OpenConnection();
                object result = command.ExecuteScalar();

                if (result == null)
                    return 0;

                double retval = 0;
                if (double.TryParse(result.ToString(), out retval))
                    return retval;

                return 0;


            }
        }

        public double ExecStatement(string sql)
        {

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = sql;
                _context.Database.OpenConnection();
                object result = command.ExecuteScalar();

                if (result == null)
                    return 0;

                double retval = 0;
                if (double.TryParse(result.ToString(), out retval))
                    return retval;

                return 0;


            }
        }

        public void SqlOutToCsv(string sql, StreamWriter streamWriter)
        {

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = sql;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    createCsvFile(reader, streamWriter);
                }


            }
        }

        private static void createCsvFile(IDataReader reader, StreamWriter writer)
        {
            string Delimiter = "\"";
            string Separator = ",";

            // write header row
            for (int columnCounter = 0; columnCounter < reader.FieldCount; columnCounter++)
            {
                if (columnCounter > 0)
                {
                    writer.Write(Separator);
                }
                writer.Write(Delimiter + reader.GetName(columnCounter) + Delimiter);
            }
            writer.WriteLine(string.Empty);

            // data loop
            while (reader.Read())
            {
                // column loop
                for (int columnCounter = 0; columnCounter < reader.FieldCount; columnCounter++)
                {
                    if (columnCounter > 0)
                    {
                        writer.Write(Separator);
                    }
                    writer.Write(Delimiter + reader.GetValue(columnCounter).ToString().Replace('"', '\'') + Delimiter);
                }   // end of column loop
                writer.WriteLine(string.Empty);
            }   // data loop

            writer.Flush();
        }

    }
}
