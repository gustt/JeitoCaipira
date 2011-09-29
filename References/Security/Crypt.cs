using System;
using System.IO;
using System.Security.Cryptography;

namespace References.Security
{
    public class Crypt : IDisposable
    {
        string key = "GRFFUN00";
        ///<summary>
        /// MÉTODO DESTRUTOR DA CLASSE
        ///</summary>
        ~Crypt()
        {
            this.Dispose();
        }

        /// <summary>
        /// Método que codifica string
        /// </summary>
        /// <param name="strTexto">string</param>
        /// <returns>string codificada</returns>

        public string Codificar(string strTexto)
        {
            DESCryptoServiceProvider oDes = new DESCryptoServiceProvider();

            byte[] IV = { 121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62 };
            byte[] bytValor = System.Text.Encoding.ASCII.GetBytes(strTexto.ToCharArray());
            byte[] bytKey = System.Text.Encoding.ASCII.GetBytes(key.Substring(0, 8).ToCharArray());

            MemoryStream oMemory = new MemoryStream();
            CryptoStream oCStream = new CryptoStream(oMemory, oDes.CreateEncryptor(bytKey, IV), CryptoStreamMode.Write);
            oCStream.Write(bytValor, 0, bytValor.Length);
            oCStream.FlushFinalBlock();

            return Convert.ToBase64String(oMemory.ToArray());
        }

        /// <summary>

        /// Método que decodifica string

        /// </summary>

        /// <param name="strTexto">string codificada</param>

        /// <returns>string decodificada</returns>

        public string Decodificar(string strTexto)
        {
            DESCryptoServiceProvider oDes = new DESCryptoServiceProvider();

            byte[] IV = { 121, 241, 10, 1, 132, 74, 11, 39, 255, 91, 45, 78, 14, 211, 22, 62 };
            byte[] bytValor = Convert.FromBase64String(strTexto);
            byte[] bytKey = System.Text.Encoding.ASCII.GetBytes(key.Substring(0, 8).ToCharArray());

            MemoryStream oMemory = new MemoryStream(bytValor, 0, bytValor.Length);
            CryptoStream oCStream = new CryptoStream(oMemory, oDes.CreateDecryptor(bytKey, IV), CryptoStreamMode.Read);
            StreamReader oSr = new StreamReader(oCStream);

            return oSr.ReadToEnd();
        }

        #region IMPLEMENTAÇÃO DO MÉTODO DISPOSE

        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }

        #endregion
    }
}
