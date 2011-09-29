using System;

namespace DM.BLL
{
    interface IDataRecord
    {
        int Insert();
        int Update();
        int Delete();
        bool IsNew();
    }
}
