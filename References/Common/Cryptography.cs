using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Security;
using System.IO;

namespace References.Common
{
    public class Cryptography<T> : IDisposable
    {
        #region ..:: Propertie

        private const string _key = "REF2010b";
        private T dataobj;

        #endregion

        #region ..:: Methods

        public Cryptography(T obj)
        {
            dataobj = obj;
        }

        protected byte[] EncryptData()
        {
            DESCryptoServiceProvider _des = null;
            MemoryStream result = null;
            StreamReader r  = null;
            CryptoStream cryptStream = null;
            try
            {
                _des = new DESCryptoServiceProvider();

                _des.Key = ASCIIEncoding.ASCII.GetBytes(_key);

                result = new MemoryStream();
                
                cryptStream = new CryptoStream(result, _des.CreateEncryptor(), CryptoStreamMode.Write);
                using (StreamWriter sw = new StreamWriter(cryptStream))
                {
                    sw.WriteLine(dataobj);
                }

                return result.ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (result != null)
                    result.Dispose();

                if (cryptStream != null)
                    cryptStream.Dispose();

                if (_des != null)
                    GC.SuppressFinalize(_des);
            }
        }

        public override string ToString()
        {
            try
            {
                string result = string.Empty;
                using (MemoryStream ms = new MemoryStream(EncryptData()))
                {
                    using (StreamReader sr = new StreamReader(ms))
                    {
                        result = sr.ReadLine();
                    };
                };

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {

        }

        #endregion
    }
}
