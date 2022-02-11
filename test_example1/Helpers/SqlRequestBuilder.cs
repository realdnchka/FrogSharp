using System;
using System.Collections.Generic;

namespace test_example1.Helpers
{
    public class SqlRequestBuilder
    {
        private string sqlRequest = "";

        public SqlRequestBuilder Select(string columnsNames = "*")
        {
            sqlRequest += "SELECT " + columnsNames + " ";
            return this;
        }

        public SqlRequestBuilder InsertInto(string tableName)
        {
            sqlRequest += "INSERT INTO " + tableName + " ";
            return this;
        }

        public SqlRequestBuilder Update(string tableName)
        {
            sqlRequest += "UPDATE " + tableName + " ";
            return this;
        }

        public SqlRequestBuilder Set(string value)
        {
            sqlRequest += "SET " + value + " ";
            return this;
        }

        public SqlRequestBuilder Where(string statement)
        {
            sqlRequest += "WHERE " + statement + " ";
            return this;
        }

        public SqlRequestBuilder From(string tableNames)
        {
            sqlRequest += "FROM " + tableNames + " ";
            return this;
        }

        public SqlRequestBuilder Values(string values)
        {
            sqlRequest += $"VALUES ({values})";
            return this;
        }

        public SqlRequestBuilder AddText(string text)
        {
            sqlRequest += text;
            return this;
        }

        public string Text()
        {
            return sqlRequest;
        }

        public string setStatementByTwoList(List<string> columnNames, List<string> columnData)
        {
            string result = String.Empty;
            for (int i = 0; i < columnNames.Count; i++)
            {
                if (columnNames.Count - i > 1)
                {
                    result += $"{columnNames[i]} = '{columnData[i]}', ";
                }
                else
                {
                    result += $"{columnNames[i]} = '{columnData[i]}'";
                }
                
            }
            return result;
        }
    }
}