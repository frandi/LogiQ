using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;

namespace LogiQ.Helpers
{
    public static class ConversionHelper
    {
        /// <summary>
        /// Convert List to DataTable
        /// </summary>
        /// <typeparam name="T">Object Type</typeparam>
        /// <param name="source">List</param>
        /// <returns>DataTable</returns>
        public static DataTable ToDataTable<T>(this List<T> source)
        {
            DataTable result = new DataTable();

            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));

            // set datatable columns
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                result.Columns.Add(prop.Name, prop.PropertyType);
            }

            // enter the data
            foreach (T item in source)
            {
                DataRow row = result.NewRow();
                for (int i = 0; i < result.Columns.Count; i++)
                {
                    row[i] = props[i].GetValue(item);
                }
                result.Rows.Add(row);
            }

            return result;
        }

        /// <summary>
        /// Convert String to Decimal (default value = 0)
        /// </summary>
        /// <param name="source">String</param>
        /// <returns>Decimal</returns>
        public static decimal ToDecimal(this string source)
        {
            return ToDecimal(source, 0);
        }

        /// <summary>
        /// Convert String to Decimal
        /// </summary>
        /// <param name="source">String</param>
        /// <param name="defaultValue">Default value if conversion failed</param>
        /// <returns>Decimal</returns>
        public static decimal ToDecimal(this string source, decimal defaultValue)
        {
            decimal result = defaultValue;

            if (source != null)
                decimal.TryParse(source, out result);

            return result;
        }

        /// <summary>
        /// Convert String to Guid (default value = Guid.Empty)
        /// </summary>
        /// <param name="source">String</param>
        /// <returns>Guid</returns>
        public static Guid ToGuid(this string source)
        {
            return ToGuid(source, Guid.Empty);
        }

        /// <summary>
        /// Convert String to Guid
        /// </summary>
        /// <param name="source">String</param>
        /// <param name="defaultValue">Default value if conversion failed</param>
        /// <returns>Guid</returns>
        public static Guid ToGuid(this string source, Guid defaultValue)
        {
            Guid result = defaultValue;

            if (source != null)
                Guid.TryParse(source, out result);

            return result;
        }

        /// <summary>
        /// Convert String to Integer (default value = 0)
        /// </summary>
        /// <param name="source">String</param>
        /// <returns>Integer</returns>
        public static int ToInteger(this string source)
        {
            return ToInteger(source, 0);
        }

        /// <summary>
        /// Convert String to Integer
        /// </summary>
        /// <param name="source">Integer</param>
        /// <param name="defaultValue">Default value if conversion failed</param>
        /// <returns>Integer</returns>
        public static int ToInteger(this string source, int defaultValue)
        {
            int result = defaultValue;

            if (source != null)
                int.TryParse(source, out result);

            return result;
        }

        /// <summary>
        /// Convert Short to Integer (default value = 0)
        /// </summary>
        /// <param name="source">Short</param>
        /// <returns>Integer</returns>
        public static int ToInteger(this short source)
        {
            return ToInteger(source, 0);
        }

        /// <summary>
        /// Convert Short to Integer
        /// </summary>
        /// <param name="source">Short</param>
        /// <param name="defaultValue">Default value if conversion failed</param>
        /// <returns>Integer</returns>
        public static int ToInteger(this short source, int defaultValue)
        {
            int result = defaultValue;
            int.TryParse(source.ToString(), out result);

            return result;
        }

        /// <summary>
        /// Convert String to Short (default value = 0)
        /// </summary>
        /// <param name="source">String</param>
        /// <returns>Short</returns>
        public static short ToShort(this string source)
        {
            return ToShort(source, 0);
        }

        /// <summary>
        /// Convert String to Short
        /// </summary>
        /// <param name="source">String</param>
        /// <param name="defaultValue">Default value if conversion failed</param>
        /// <returns>Short</returns>
        public static short ToShort(this string source, short defaultValue)
        {
            short result = defaultValue;

            if (source != null)
                short.TryParse(source, out result);

            return result;
        }

        /// <summary>
        /// Convert Integer to Short (default value = 0)
        /// </summary>
        /// <param name="source">Integer</param>
        /// <returns>Short</returns>
        public static short ToShort(this int source)
        {
            return ToShort(source, 0);
        }

        /// <summary>
        /// Convert Integer to Short
        /// </summary>
        /// <param name="source">Integer</param>
        /// <param name="defaultValue">Default value if conversion failed</param>
        /// <returns>Short</returns>
        public static short ToShort(this int source, short defaultValue)
        {
            short result = defaultValue;
            short.TryParse(source.ToString(), out result);

            return result;
        }

        /// <summary>
        /// Get exception message, including the inner exception (separated by "&lt;br /&gt;")
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <returns>Messages</returns>
        public static string GetLongMessages(this Exception ex)
        {
            return GetLongMessages(ex, "<br />");
        }

        /// <summary>
        /// Get exception message, including the inner exception
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="separator">Separator character between messages</param>
        /// <returns>Messages</returns>
        public static string GetLongMessages(this Exception ex, string separator)
        {
            string msg = "";

            if (ex != null)
            {
                msg = ex.Message;

                if (ex.InnerException != null)
                    msg += separator + GetLongMessages(ex.InnerException, separator);
            }

            return msg;
        }
    }
}