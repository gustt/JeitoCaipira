using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using References.DAL;

namespace DBLayers.DAL
{
    public class ClientePL : IDisposable
    {
        public int SP_SALVAR_CLIENTE(Entidades.Cliente entidade)
        {
            int Codigo = 0;
            Queue<SqlParameter> qParameter = null;
            Database db = null;
            try
            {
                db = new Database();


                using(References.Security.Crypt crp = new References.Security.Crypt())
                {
                    entidade.Password = crp.Codificar(entidade.Password);
                };

                CreateParameters(ref qParameter,
                    new References.DAL.Property() { NomeCampo = "Codigo", Value = entidade.Codigo, Direction = ParameterDirection.Output },
                    new References.DAL.Property() { NomeCampo = "Email", Value = entidade.Email },
                    new References.DAL.Property() { NomeCampo = "Logradouro", Value = entidade.Logradouro },
                    new References.DAL.Property() { NomeCampo = "Cidade", Value = entidade.Cidade },
                    new References.DAL.Property() { NomeCampo = "Complemento", Value = entidade.Complemento },
                    new References.DAL.Property() { NomeCampo = "Bairro", Value = entidade.Bairro },
                    new References.DAL.Property() { NomeCampo = "UF", Value = entidade.UF },
                    new References.DAL.Property() { NomeCampo = "Ativo", Value = entidade.Ativo },
                    new References.DAL.Property() { NomeCampo = "ReceberEmail", Value = entidade.ReceberEmail },
                    new References.DAL.Property() { NomeCampo = "UserID", Value = entidade.UserID },
                    new References.DAL.Property() { NomeCampo = "Password", Value = entidade.Password }
                );

                Codigo = db.ExecuteNonQuery("[dbo].[SP_SALVAR_CLIENTE]", ref qParameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (qParameter != null)
                    GC.SuppressFinalize(qParameter);
                if (db != null)
                    db.Dispose();
            }
            return Codigo;

        }
        public int CreateParameters(ref Queue<SqlParameter> qParameters, params Property[] Properties)
        {
            try
            {
                if (qParameters == null)
                    qParameters = new Queue<SqlParameter>();

                foreach (Property p in Properties)
                    qParameters.Enqueue(
                        new SqlParameter()
                        {
                            ParameterName = string.Concat("@", p.NomeCampo),
                            Value = p.Value
                        }
                    );
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return qParameters.Count;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
