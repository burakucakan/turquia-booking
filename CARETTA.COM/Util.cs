using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CARETTA.COM
{
    public class Util
    {
        public static string Left(string param, int length)
        {
            if (param.Length < length) { length = param.Length; }
            return param.Substring(0, length);
        }
        public static string Right(string param, int length)
        {
            if (param.Length < length) { length = param.Length; }
            return param.Substring(param.Length - length, length);
        }
        public static string Mid(string param, int startIndex, int length)
        {
            if (param.Length < length) { length = param.Length; }
            return param.Substring(startIndex, length);
        }
        public static string Mid(string param, int startIndex)
        {
            return param.Substring(startIndex);
        }

        public static string ToUpper(string Text)
        {
            return Text.Replace('i', 'Ý').Replace('ý', 'I').ToUpperInvariant();
        }

        public static string ReturnPageName()
        {
            return System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.RawUrl);
        }

        public static string ReturnRefererPageName()
        {
            return System.IO.Path.GetFileName(System.Web.HttpContext.Current.Request.UrlReferrer.ToString());
        }

        public static float FormatPrice(object inNumber) {
            return float.Parse(String.Format("{0:c}", inNumber).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, "").Trim());
        }
        public static string FormatPriceToString(object inNumber) {
            return String.Format("{0:c}", inNumber).Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol, "").Trim();
        }

        /// <summary>
        /// String içindeki yeni satýrlarý <code>&lt;br /&gt;</code>'ye dönüþtürür.
        /// </summary>
        /// <param name="Text">Yeni satýrlarý html break'e dönüþtürülecek string</param>
        /// <returns>Yeni satýrlarý break'e dönüþtürülmüþ string</returns>
        public static string Nl2Br(string Text) {
            return Text.Replace("\n", "<br />");
        }

        /// <summary>
        /// STRING TEMIZLE (REG EXP)
        /// </summary>
        /// <param name="input">Temizlenecek Deðiþken</param>
        /// <returns></returns>
        public static string ClearString(string input)
        {
            System.Text.RegularExpressions.Regex regEx = new System.Text.RegularExpressions.Regex("[^0-9a-zA-Z_iþçöüðÝÞÇÖÜÐ@\\-,.:]");
            return regEx.Replace(input, "");
        }

        /// <summary>
        /// String deki tüm html taglarýný temizler
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ClearHtmlTags(string input) {
            return System.Text.RegularExpressions.Regex.Replace(input, "(<[^>]+>)", "");
        }

        /// <summary>
        /// Deðiþken Numeric ise true, deðilse false
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNumeric(object input) {

            if (input == null) {
                return false;
            }

            if (input.ToString() == string.Empty) {
                return false;
            }

            foreach (char c in input.ToString()) {
                if (!char.IsNumber(c))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// LÝSTBOXTAKÝLERÝ DATATABLE A AKTARIR
        /// </summary>
        /// <param name="lb"></param>
        /// <returns></returns>
        public static DataTable ListboxToDataTable(System.Web.UI.WebControls.ListBox lb)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn(lb.DataValueField.ToString()));
            dt.Columns.Add(new DataColumn(lb.DataTextField.ToString()));
            DataRow dr;

            foreach (System.Web.UI.WebControls.ListItem li in lb.Items)
            {
                if (li.Selected)
                {
                    dr = dt.NewRow();
                    dr[lb.DataValueField.ToString()] = li.Value;
                    dr[lb.DataTextField.ToString()] = li.Text;
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        /// <summary>
        /// (tavsiye edilmeyen fonksiyon - bu fonksiyon yerine strDegisken.Padleft(2, '0') kullanýn)
        /// GELEN RAKAMI 2 STRING KARAKTERE ÇEVÝRÝR TEK KARAKTER ÝSE BAÞINA "0" KOYAR
        /// </summary>
        /// <param name="inNumber"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string ReplaceNumberToTwo(int inNumber)
        {
            return inNumber.ToString().PadLeft(2, '0');
        }

        /// <summary>
        /// Rasgele Sayý Üretir
        /// </summary>
        /// <param name="CharLength">Rasgele Sayý Kaç Karakterli Olsun</param>
        /// <returns></returns>
        public static string CreateRandomNumber(int CharLength) {
            Random rnd = new Random(DateTime.Now.Year * DateTime.Now.Month * DateTime.Now.Day * DateTime.Now.Millisecond);
            string RndNumber = string.Empty;
            for (int i = 1; i <= CharLength; i++) {
                RndNumber += rnd.Next(0, 9).ToString();
            }
            return RndNumber;
        }

    }
}
