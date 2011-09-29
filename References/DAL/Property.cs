using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace References.DAL
{
    public class Property
    {
        #region Propriedades
        public string NomeCampo { get; set; }
        public object Value { get; set; }
        public System.Data.ParameterDirection Direction { get; set; }
        #endregion
    }
}
