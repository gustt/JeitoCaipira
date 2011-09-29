using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using References.DAL;

namespace DBLayers.DAL
{
    public class UsuarioPL : IDisposable
    {

        public List<Entidades.Usuario> SP_CONSULTAR_USUARIO(string NomeAdministrador)
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            List<Entidades.Usuario> retorno = new List<Entidades.Usuario>();
            try
            {
                db = new Database();

                CreateParameters(ref qParameters,
                            new Property() { NomeCampo = "NomeAdministrador", Value = NomeAdministrador });

                retorno =
                    Mapping.Mapping<Entidades.Usuario>.ConvertReaderToIEnumerable(
                        db.ExecuteDataReader("SP_CONSULTAR_USUARIO", ref qParameters)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                    db.Dispose();

                if (qParameters != null)
                {
                    GC.SuppressFinalize(qParameters);
                    qParameters = null;
                }
            }

            return retorno;
        }
        public Entidades.Usuario SP_VALIDA_USUARIO(string UserID, string Password)
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            Entidades.Usuario retorno = null;
            try
            {
                db = new Database();
                
                //Evita InnerScript
                Password = HttpUtility.HtmlEncode(Password);
                UserID = HttpUtility.HtmlEncode(UserID);

                string SenhaCriptografada = string.Empty;

                //Criptografando senha
                using (References.Security.Crypt cript = new References.Security.Crypt())
                {
                    SenhaCriptografada = cript.Codificar(Password);
                };

                CreateParameters(ref qParameters,
                    new Property() { NomeCampo = "UserID", Value = UserID },
                    new Property() { NomeCampo = "Password", Value = SenhaCriptografada }
                    );

                List<Entidades.Usuario> rMapping =
                    Mapping.Mapping<Entidades.Usuario>.ConvertReaderToIEnumerable(
                        db.ExecuteDataReader("SP_VALIDA_USUARIO", ref qParameters)).ToList();

                if (rMapping.Count > 0)
                    retorno = rMapping.ElementAt(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }
        public Entidades.Usuario SP_SELECIONAR_USUARIO(string UserID, int CodigoCliente)
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            Entidades.Usuario retorno = null;
            try
            {
                db = new Database();

                CreateParameters(ref qParameters,
                    new Property() { NomeCampo = "UserID", Value = UserID },
                    new Property() { NomeCampo = "CodigoCliente", Value = CodigoCliente }
                    );

                List<Entidades.Usuario> rMapping =
                    Mapping.Mapping<Entidades.Usuario>.ConvertReaderToIEnumerable(
                        db.ExecuteDataReader("SP_SELECIONAR_USUARIO", ref qParameters)).ToList();

                if (rMapping.Count > 0)
                    retorno = rMapping.ElementAt(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }
        public void SP_DELETAR_USUARIO(string UserID)
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            DAL.Entidades.Usuario retorno = new Entidades.Usuario();
            try
            {
                db = new Database();

                CreateParameters(ref qParameters,
                          new Property() { NomeCampo = "UserID", Value = UserID });

                db.ExecuteNonQuery("SP_DELETAR_USUARIO", ref qParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SP_SALVAR_USUARIO(Entidades.Usuario entidade)
        {
            int Codigo = 0;
            Queue<SqlParameter> qParameter = null;
            Database db = null;
            try
            {
                db = new Database();

                //Criptografando senha
                using (References.Security.Crypt cript = new References.Security.Crypt())
                {
                    entidade.Password = cript.Codificar(entidade.Password);
                };

                CreateParameters(ref qParameter,
                    new References.DAL.Property() { NomeCampo = "NomeAdministrador", Value = entidade.NomeAdministrador },
                    new References.DAL.Property() { NomeCampo = "UserID", Value = entidade.UserID },
                    new References.DAL.Property() { NomeCampo = "Password", Value = entidade.Password },
                    new References.DAL.Property() { NomeCampo = "TipoPerfil", Value = entidade.TipoPerfil },
                    new References.DAL.Property() { NomeCampo = "Ativo", Value = entidade.Situacao }
                );

                db.ExecuteNonQuery("[dbo].[SP_SALVAR_USUARIO]", ref qParameter);
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
