using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using test_example1.Helpers;

namespace test_example1.POM
{
    public class SQLTryPOM: CorePOM
    {
        private WebDriver driver;
        /// <summary>
        /// WebDriver init
        /// </summary>
        /// <param name="driver"></param>
        public SQLTryPOM(WebDriver driver): base(driver)
        {
            this.driver = driver;
        }
        
        #region Selectors

        /// <summary>
        /// "Run SQL" button
        /// </summary>
        private By btnRunSql = By.XPath("//button[@class='ws-btn']");
        
        /// <summary>
        /// Table with result
        /// </summary>
        private By tableResult = By.XPath("(//tbody)[1]");
        
        /// <summary>
        /// All table rows
        /// </summary>
        private By tableRow = By.XPath("(//tbody)[1]/tr");
        
        /// <summary>
        /// All table data
        /// </summary>
        private By tableData = By.XPath("(//tbody)[1]/tr/td");
        
        /// <summary>
        /// Accept cookies button
        /// </summary>
        private By btnAcceptCookies = By.XPath("//*[@id='accept-choices']");
        
        private By tableColumnNames = By.XPath("(//tbody)[1]//th");
        
        private By resultInsert = By.XPath("//*[@id='divResultSQL']//*[contains(text(), 'You have made changes to the database')]");

        private By inputField = By.XPath("//*[contains(@class, 'CodeMirror-code')]");
        #endregion

        #region Methods
        
        /// <summary>
        /// Click "Run SQL" button
        /// </summary>
        public void BtnRunSqlClick()
        {
            Click(btnRunSql);
        }

        public bool TableDataHaveText(string text)
        {
            foreach (var element in FindElements(tableData))
            {
                if (element.Text == text)
                {
                    return true;
                }
            }
            return false;
        }

        public void BtnAcceptCookiesClick()
        {
            try
            {
                Click(btnAcceptCookies);
            }
            catch (NoSuchElementException)
            { }
        }

        public bool DataTextExistByColumnNameAndOtherColumn(string columnNameOtherText, string otherColumnText, string columnNameCheckText, string checkText)
        {
            WaitForElementExist(tableColumnNames);
            var columnElement = driver.FindElement(By.XPath($"(//tbody)[1]//th[contains(text(), '{columnNameOtherText}')]"));
            var columnOtherTextIndex = FindElements(tableColumnNames).IndexOf(columnElement);
            columnElement =
                driver.FindElement(By.XPath($"(//tbody)[1]//th[contains(text(), '{columnNameCheckText}')]"));
            var columnCheckTextIndex = FindElements(tableColumnNames).IndexOf(columnElement);
            By selector = By.XPath($"//td[{columnOtherTextIndex+1}][contains(text(), '{otherColumnText}')]/parent::tr/td[{columnCheckTextIndex+1}][contains(text(), '{checkText}')]");
            return IsElementExist(selector);
        }
        
        public bool DataTextExistByListOfColumnsAndListOfText(List<string> data, List<string> columns)
        {
            bool result = true;
            WaitForElementExist(tableColumnNames);
            foreach (var elementText in columns)
            {
                var columnIndex = FindElements(tableColumnNames).IndexOf(driver.FindElement(By.XPath($"(//tbody)[1]//th[contains(text(), '{elementText}')]"))) + 1;
                By selector = By.XPath($"//td[{columnIndex}][contains(text(), '{data[columns.IndexOf(elementText)].Trim('\'')}')]");
                result = result && IsElementExist(selector);
            }
            return result;
        }

        public void InputFieldSetText(string text)
        {
            WaitForElementExist(inputField);
            IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
            js.ExecuteScript($"window.editor.setValue(\"{text}\")");
        }

        public string InputFieldGetText()
        {
            WaitForElementExist(inputField);
            IJavaScriptExecutor js = (IJavaScriptExecutor) driver;
            return js.ExecuteScript($"return window.editor.getValue()").ToString();
        }
        public int GetTotalRows()
        {
            return FindElements(tableRow).Count - 1;
        }
        
        public void WaitForInsertResult()
        {
            WaitForElementExist(resultInsert);
        }

        #endregion

    }
}