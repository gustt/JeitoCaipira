using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime;

namespace DBLayers.DAL.Mapping.Attributes
{
    /// <summary>
    /// Campos não mapeados, somente leitura
    /// </summary>
    public class CustomMapper : System.Attribute
    {
        #region .:: Propriedades
        public bool readOnly;
        public bool notMapper;
        #endregion
        #region .:: Construtor
        public CustomMapper(bool _readOnly, bool _notMapper)
            : base()
        {
            readOnly = _readOnly;
            notMapper = _notMapper;
        }
        #endregion
    }
}
