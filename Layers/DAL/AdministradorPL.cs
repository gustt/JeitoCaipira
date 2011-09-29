using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using References.DAL;

namespace DBLayers.DAL
{
    public class AdministradorPL : IDisposable
    {

        public List<Entidades.Administrador> SP_CONSULTAR_ADMINISTRADOR(string NomeAdministrador)
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            List<Entidades.Administrador> retorno = new List<Entidades.Administrador>();
            try
            {
                db = new Database();

                CreateParameters(ref qParameters,
                            new Property() { NomeCampo = "NomeAdministrador", Value = NomeAdministrador });

                retorno = 
                    Mapping.Mapping<Entidades.Administrador>.ConvertReaderToIEnumerable(
                        db.ExecuteDataReader("SP_CONSULTAR_ADMINISTRADOR", ref qParameters)).ToList();
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
        public Entidades.Administrador SP_SELECIONAR_ADMINISTRADOR(string UserID)
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            Entidades.Administrador retorno = new Entidades.Administrador();
            try
            {
                db = new Database();

                CreateParameters(ref qParameters,
                    new Property() { NomeCampo = "UserID", Value = UserID });

                List<Entidades.Administrador> rMapping = 
                    Mapping.Mapping<Entidades.Administrador>.ConvertReaderToIEnumerable(
                        db.ExecuteDataReader("SP_SELECIONAR_ADMINISTRADOR", ref qParameters)).ToList();

                if (rMapping.Count > 0)
                    retorno = rMapping.ElementAt(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }

        public void SP_DELETAR_ADMINISTRADOR(string UserID)
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            DAL.Entidades.Administrador retorno = new Entidades.Administrador();
            try
            {
                db = new Database();

                CreateParameters(ref qParameters,
                          new Property() { NomeCampo = "UserID", Value = UserID });

                db.ExecuteNonQuery("SP_DELETAR_ADMINISTRADOR", ref qParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SP_SALVAR_ADMINISTRADOR(Entidades.Administrador entidade)
        {
            int Codigo = 0;
            Queue<SqlParameter> qParameter = null;
            Database db = null;
            try
            {
                db = new Database();

                CreateParameters(ref qParameter,
                    new References.DAL.Property() { NomeCampo = "UserID", Value = entidade.UserID, Direction = ParameterDirection.Output },
                    new References.DAL.Property() { NomeCampo = "Password", Value = entidade.Password },
                    new References.DAL.Property() { NomeCampo = "TipoPerfil", Value = entidade.TipoPerfil },
                    new References.DAL.Property() { NomeCampo = "Ativo", Value = entidade.Situacao }
                );

                Codigo = db.ExecuteNonQuery("[dbo].[SP_SALVAR_ADMINISTRADOR]", ref qParameter);
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
