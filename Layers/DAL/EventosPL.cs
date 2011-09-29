using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using References.DAL;

namespace DBLayers.DAL
{
    public class EventosPL : IDisposable
    {
        public List<DAL.Entidades.Eventos> SP_CONSULTAR_EVENTOS()
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            List<DAL.Entidades.Eventos> retorno = new List<Entidades.Eventos>();
            try
            {
                db = new Database();

                retorno = Mapping.Mapping<DAL.Entidades.Eventos>.ConvertReaderToIEnumerable(
                                                        db.ExecuteDataReader("SP_CONSULTAR_EVENTOS", ref qParameters)).ToList();
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
        public DAL.Entidades.Eventos SP_SELECIONAR_EVENTOS(int Codigo)
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            DAL.Entidades.Eventos retorno = new Entidades.Eventos();
            try
            {
                db = new Database();

                CreateParameters(ref qParameters,
                    new Property() { NomeCampo = "Codigo", Value = Codigo });

                List<DAL.Entidades.Eventos> rMapping =
                    Mapping.Mapping<DAL.Entidades.Eventos>.ConvertReaderToIEnumerable(
                            db.ExecuteDataReader("SP_SELECIONAR_EVENTOS", ref qParameters)).ToList();

                if (rMapping.Count > 0)
                    retorno = rMapping.ElementAt(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }
        public void SP_EXCLUIR_EVENTOS(int Codigo)
        {
            Database db = null;
            Queue<SqlParameter> qParameters = null;
            DAL.Entidades.Eventos retorno = new Entidades.Eventos();
            try
            {
                db = new Database();

                CreateParameters(ref qParameters,
                    new Property() { NomeCampo = "Codigo", Value = Codigo });

                db.ExecuteNonQuery("SP_EXCLUIR_EVENTOS", ref qParameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int SP_SALVAR_EVENTOS(Entidades.Eventos entidade)
        {
            int Codigo = 0;
            Queue<SqlParameter> qParameter = null;
            Database db = null;
            try
            {
                db = new Database();

                CreateParameters(ref qParameter,
                    new References.DAL.Property() { NomeCampo = "Codigo", Value = entidade.Codigo, Direction = ParameterDirection.Output },
                    new References.DAL.Property() { NomeCampo = "Descricao", Value = entidade.Descricao },
                    new References.DAL.Property() { NomeCampo = "Local", Value = entidade.Local },
                    new References.DAL.Property() { NomeCampo = "Data", Value = entidade.Data },
                    new References.DAL.Property() { NomeCampo = "Cartaz", Value = entidade.Cartaz }

                );

                Codigo = db.ExecuteNonQuery("[dbo].[SP_SALVAR_EVENTOS]", ref qParameter);
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
