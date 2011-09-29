using System;
using System.Collections.Generic;
using System.Text;
using DBLayers.DAL;
using DBLayers.BLL.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DBLayers.DAL.Entidades
{
    public class Administrador 
    {
        #region Propriedades Publicas
        public string UserID { get; set; }
        public string Password { get; set; }
        public int TipoPerfil { get; set; }
        public bool Situacao { get; set; }
        #endregion
    }
}
