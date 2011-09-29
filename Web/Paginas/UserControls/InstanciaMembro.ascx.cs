using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBLayers.BLL;
using DBLayers.DAL;

namespace Bananas.Administrativo.UserControls
{
    public partial class InstanciaMembro : References.Web.UI.UserControlBase,
        References.Web.Interfaces.IInstanciaUserControlBase
    {
        #region Propiedades
        public DBLayers.DAL.Entidades.Cliente Instancia
        {
            get
            {
                DBLayers.DAL.Entidades.Cliente instancia = new DBLayers.DAL.Entidades.Cliente();
                instancia.Email = txtEmail.Text;
                instancia.Logradouro = txtLogradouro.Text;
                instancia.Bairro = txtBairro.Text;
                instancia.Complemento = txtComplemento.Text;
                instancia.Cidade = txtCidade.Text;
                instancia.UF = txtEstado.Text;
                instancia.Ativo = true;
                instancia.ReceberEmail = chkReceberEmail.Checked;
                instancia.UserID = txtLogin.Text;
                instancia.Password = txtSenha.Text;
                return instancia;
            }
        }
        #endregion
        #region Eventos
        protected void cvLogin_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            //Valida se usuario existe
            DBLayers.BLL.Regras.Usuario usuario = new DBLayers.BLL.Regras.Usuario();
            usuario.Select(this.Instancia.UserID);

            e.IsValid = (usuario.Instance == null);
        }
        #endregion
        #region Metodos
        public void FillUserControl(int CodigoCliente)
        {
            if (!IsPostBack)
            {

            }
        }
        public void FillUserControl()
        {
            this.FillUserControl(0);
        }
        public void Save()
        {
            try
            {
                DBLayers.BLL.Regras.Cliente cliente = new DBLayers.BLL.Regras.Cliente();
                cliente.Instance = this.Instancia;
                cliente.Insert();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete()
        {

        }
        public void Clear()
        {

        }
        #endregion
    }
}