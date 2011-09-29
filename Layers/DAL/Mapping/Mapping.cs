using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;
using DBLayers.DAL.Mapping.Attributes;

namespace DBLayers.DAL.Mapping
{
    public static class Mapping<T>
    {
        public static IEnumerable<T> ConvertReaderToIEnumerable(SqlDataReader dr)
        {
            while (dr.Read())
            {
                T instance = Activator.CreateInstance<T>();

                bool notReader = false;

                PropertyInfo[] pis = typeof(T).GetProperties();
                for (int index = 0; index < pis.Length; index++)
                {
                    object[] atts =
                        pis[index].GetCustomAttributes(true);

                    for (int indatt = 0; indatt < atts.Length; indatt++)
                    {
                        if (atts[indatt] is CustomMapper)
                        {
                            CustomMapper cm =
                                atts[indatt] as CustomMapper;

                            //Nao tenta recuperar o campo
                            notReader = cm.notMapper;
                        }
                    }

                    if (!notReader && dr[pis[index].Name] != DBNull.Value)
                        typeof(T).InvokeMember(pis[index].Name, BindingFlags.SetProperty, null, instance, new object[] { dr[pis[index].Name] });
                }

                yield return instance;
            }
        }
    }
}
