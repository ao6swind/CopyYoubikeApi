using Dapper;
using DbContexts;
using Pluralize.NET.Core;
using Repositories.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Repositories.Dapper
{
    public class GeneralQuery<T> : IGeneralQuery<T> where T : class
    {
        public T Find(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("id", id);
            string table = new Pluralizer().Pluralize(typeof(T).Name);
            string key = String.Empty;

            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                var attribute = Attribute.GetCustomAttribute(prop, typeof(KeyAttribute)) as KeyAttribute;
                if (attribute != null)
                {
                    key = prop.Name;
                    break;
                }
            }

            string sql = $"SELECT * FROM {table} WHERE {key} = @id";
            using (SqlConnection conn = new SqlConnection(ConnectionString.DbEasyLife))
            {
                conn.Open();
                return conn.Query<T>(sql, parameters).FirstOrDefault<T>();
            }
        }

        public bool Create(T entity)
        {
            DynamicParameters parameters = new DynamicParameters();
            StringBuilder columnBuilder = new StringBuilder();
            StringBuilder valuesBuilder = new StringBuilder();

            PropertyInfo[] props = typeof(T).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                columnBuilder.Append($"{prop.Name},");
                valuesBuilder.Append($"@{prop.Name},");
                parameters.Add(prop.Name, prop.GetValue(entity));
            }

            string table = new Pluralizer().Pluralize(typeof(T).Name);
            string column = columnBuilder.ToString();
            string values = valuesBuilder.ToString();
            column = column.Substring(0, column.Length - 1);
            values = values.Substring(0, values.Length - 1);
            string sql = $"INSERT INTO {table}({column}) VALUES({values})";

            using (SqlConnection conn = new SqlConnection(ConnectionString.DbEasyLife))
            {
                conn.Open();
                conn.Execute(sql, parameters);
            }
            return true;
        }

        public bool Update(int id, T entity)
        {
            string table = new Pluralizer().Pluralize(typeof(T).Name);
            string update = String.Empty;
            string key = String.Empty;

            DynamicParameters parameters = new DynamicParameters();
            StringBuilder updateBuilder = new StringBuilder();
            PropertyInfo[] props = typeof(T).GetProperties();

            foreach (PropertyInfo prop in props)
            {
                var attribute = Attribute.GetCustomAttribute(prop, typeof(KeyAttribute)) as KeyAttribute;
                if (attribute != null)
                {
                    key = prop.Name;
                }
                else
                {
                    updateBuilder.Append($"{prop.Name} = @{prop.Name},");
                    parameters.Add(prop.Name, prop.GetValue(entity));
                }
            }
            parameters.Add("id", id);
            update = updateBuilder.ToString();
            update = update.Substring(0, update.Length - 1);
            string sql = $"UPDATE {table} SET {update} WHERE {key} = @id";

            using (SqlConnection conn = new SqlConnection(ConnectionString.DbEasyLife))
            {
                conn.Open();
                conn.Execute(sql, parameters);
            }
            return true;
        }
    }
}
