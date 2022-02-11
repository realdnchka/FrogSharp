using System;
using System.Collections.Generic;
using NUnit.Framework;
using test_example1.Helpers;
using test_example1.POM;

namespace test_example1
{
    [TestFixture]
    public class Tests: CoreTest
    {
        SQLTryPOM sqlTryPom;
        [Test]
        public void AllCustomersAndContactName()
        {
            //Arrange
            string columnNameOtherText = "ContactName";
            string otherColumnText = "Giovanni Rovelli";
            string columnNameCheckText = "Address";
            string checkText = "Via Ludovico il Moro 22";
            
            //Act
            sqlTryPom.BtnAcceptCookiesClick();
            sqlTryPom.BtnRunSqlClick();
            
            //Actual
            bool rowExist = sqlTryPom.DataTextExistByColumnNameAndOtherColumn(columnNameOtherText, otherColumnText, columnNameCheckText, checkText);
            
            //Assert
            Assert.IsTrue(rowExist);
        }
        
        [Test]
        public void AllLondonCustomers()
        {
            //Arrange
            SqlRequestBuilder sqlRequest = new SqlRequestBuilder();
            string sqlStatement = sqlRequest.Select().From("Customers").Where("city='London'").Text();
            int numberOfResultStrings = 6;
            
            //Act
            sqlTryPom.BtnAcceptCookiesClick();
            sqlTryPom.InputFieldSetText(sqlStatement);
            sqlTryPom.BtnRunSqlClick();
            
            //Actual
            bool result = numberOfResultStrings == sqlTryPom.GetTotalRows();
            
            //Assert
            Assert.IsTrue(result);
        }
        
        
        [Test]
        public void CreateNewCustomersField()
        {
            //Arrange
            List<string> data = new List<string>() {"Woker", "Jerry Green", "Some address", "City", "23143", "Country"};
            for (int i = 0; i < data.Count; i++)
            {
                data[i] = "'" + data[i] + "'";
            }
            string dataString = String.Join(", ", data);
        
            List<string> columnNamesList = new List<string>()
                {"CustomerName", "ContactName", "Address", "City", "PostalCode", "Country"};
            string columnNamesString = String.Join(",", columnNamesList);
            
            string sqlUpdateStatement = new SqlRequestBuilder().InsertInto("Customers").AddText($"({columnNamesString})").Values(dataString).Text();
            string sqlSelectStatement = new SqlRequestBuilder().Select().From("Customers").Text();
            
            //Act
            sqlTryPom.BtnAcceptCookiesClick();
            sqlTryPom.InputFieldSetText(sqlUpdateStatement);
            sqlTryPom.BtnRunSqlClick();
            sqlTryPom.WaitForInsertResult();
            
            sqlTryPom.InputFieldSetText(sqlSelectStatement);
            sqlTryPom.BtnRunSqlClick();
            
            //Actual
            var result = sqlTryPom.DataTextExistByListOfColumnsAndListOfText(data, columnNamesList);
            
            //Assert
            Assert.IsTrue(result);
        }
        
        [Test]
        public void UpdateAllCustomersFieldExeptCustomerId()
        {
            int customerId = 25;
            /*
             * Можно написать генератор data
             */
            List<string> data = new List<string>() {"Hyper", "Master Jack", "Some address", "City", "23143", "Country"};
            List<string> columnNamesList = new List<string>() {"CustomerName", "ContactName", "Address", "City", "PostalCode", "Country"};
            
            string sqlSelect = new SqlRequestBuilder().Select().From("Customers").Where($"customerid={customerId}").Text();
            string setStatement = new SqlRequestBuilder().setStatementByTwoList(columnNamesList, data);
            string sqlSet = new SqlRequestBuilder().Update("Customers").Set(setStatement).Where($"customerid = {customerId}").Text();
            
            //Act
            sqlTryPom.BtnAcceptCookiesClick();
            sqlTryPom.InputFieldSetText(sqlSet);
            sqlTryPom.BtnRunSqlClick();
            sqlTryPom.WaitForInsertResult();
            sqlTryPom.InputFieldSetText(sqlSelect);
            sqlTryPom.BtnRunSqlClick();
            
            //Actual
            var result = sqlTryPom.DataTextExistByListOfColumnsAndListOfText(data, columnNamesList);
            
            Assert.IsTrue(result);
        }

        [Test]
        public void SqlStatementByDefault()
        {
            //Arrange
            string defaultStatement = "SELECT * FROM Customers\nORDER BY CustomerName ASC;";
            
            //Act
            sqlTryPom.BtnAcceptCookiesClick();
            
            //Actual
            var result = defaultStatement.Trim() == sqlTryPom.InputFieldGetText().Trim();
            
            //Assert
            Assert.IsTrue(result);
        }

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            sqlTryPom = new SQLTryPOM(driver);
            OpenSite();
        }
    }
}