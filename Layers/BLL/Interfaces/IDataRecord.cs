using System;

namespace DBLayers.BLL.Interfaces
{
    interface IDataRecordDBLayers
    {
        int Insert();
        int Update();
        void Delete();
        bool IsNew();
    }
}
