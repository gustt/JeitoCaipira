using System;
using System.Collections.Generic;
using System.Text;
using DBLayers.DAL;
using DBLayers.BLL.Interfaces;
using System.Data;
using System.Data.SqlClient;
using DBLayers.DAL.Mapping.Attributes;

namespace DBLayers.DAL.Entidades
{
    public class Eventos
    {
        #region Propriedades Publicas
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Local { get; set; }
        public DateTime Data { get; set; }
        public byte[] Cartaz { get; set; }
        #endregion
    }
}
