using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace References.Web.Interfaces
{
    public interface IInstanciaUserControlBase
    {
        void FillUserControl();
        void Save();
        void Delete();
        void Clear();
    }
}
