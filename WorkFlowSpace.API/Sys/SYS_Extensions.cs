using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace WorkFlowSpace.API.Sys
{
    public class SYS_Extensions
    {
        #region Return String Mess

        public static string MessSuccess(string data, string type)
        {
            if(type == "Add")
            {
                return "[" + data + "] is created!";
            }

            if (type == "Upd")
            {
                return "[" + data + "] is updated!";
            }

            if (type == "Del")
            {
                return "[" + data + "] is deleted!";
            }

            return "";
        }

        public static string MessNotFound()
        {
            return "Not found data.";
        }

        public static string MessNotFound(string data)
        {
            return "Data " + data + " not found.";
        }

        public static string MessNotFound(Exception ex)
        {
            return "Not found.\nError detail: " + ex.ToString();
        }
        #endregion
    }
}
