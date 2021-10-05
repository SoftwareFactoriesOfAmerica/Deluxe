using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Deluxe.Calculator.Api.Classes
{
    public static class Common
    {
        #region private methods
        private static void InitializeData()
        {
            InvalidData = false;
            InvalidKey = string.Empty;
        }
        #endregion 

        public static bool InvalidData { get; set; } = false;
        public static string InvalidKey { get; set; } = string.Empty;

        public static bool CheckForValidEmail(string key, string email)
        {
            InitializeData();
            if (string.IsNullOrWhiteSpace(email))
                return true;

            if (!email.Contains("@"))
                return !CheckForSQLInjection(key, email);

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                InvalidData = true;
                InvalidKey = $"Invalid email address: {email}";

                return false;
            }
        }

        public static Boolean CheckForSQLInjection(string key, string userInput)
        {
            bool isSQLInjection = false;

            string[] sqlCheckList = { "--",
                                       ";--",
                                       ";",
                                       "/*",
                                       "*/",
                                       "@@",
                                       "@",
                                       "char",
                                       "nchar",
                                       "varchar",
                                       "nvarchar",
                                       "alter",
                                       "begin",
                                       "cast",
                                       "create",
                                       "cursor",
                                       "declare",
                                       "delete",
                                       "drop",
                                       "end",
                                       "exec",
                                       "execute",
                                       "fetch",
                                       "insert",
                                       "kill",
                                       "select",
                                       "sys",
                                       "sysobjects",
                                       "syscolumns",
                                       "table",
                                       "update",
                                       "while",
                                       "1=1",
                                       "dbo",
                                       "sp_",
                                       "modify",
                                       "database",
                                       "filename",
                                       "add",
                                       "from",
                                       "join",
                                       "view",
                                       "where",
                                       "union",
                                       "truncate",
                                       "usp_"
                                       };

            string CheckString = userInput.Replace("'", "''");

            for (int i = 0; i <= sqlCheckList.Length - 1; i++)
            {
                if ((CheckString.IndexOf(sqlCheckList[i], StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    InvalidData = true;
                    InvalidKey = $"Sql Injection attempt on property: {key} value: {userInput}";
                    isSQLInjection = true;
                    break;
                }
            }

            return isSQLInjection;
        }
        public static string UnJavaScriptEscape(string key, string userInput)
        {
            InitializeData();
            if (string.IsNullOrWhiteSpace(userInput))
                return userInput;

            if (key.ToLower() == "username" == true)
            {
                if (!CheckForValidEmail(key, userInput))
                {
                    InvalidData = true;
                    InvalidKey = $"Invalid {key}, value: {userInput}";
                }
            }
            else
            {
                if (CheckForSQLInjection(key, userInput) == true) { return userInput; }
            }

            HttpUtility.UrlDecode(userInput.Replace("+", "%2b"), Encoding.Default);
            return userInput;
        }

        public static void SaveCalculatorErrors(CalculatorContext context, ExceptionContext exContext, BrowserInfo browser)
        {
            //TODO...
        }
    }
}
