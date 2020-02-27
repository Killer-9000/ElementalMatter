using System;
using System.Data.Common;

namespace Assets.Scripts.Database.Models
{
    class UserElements : ModelBase
    {
        public uint UserID;
        public uint ElementID;

        public override string GenerateInsertQuery()
        {
            throw new NotImplementedException();
        }

        public override void Populate(DbDataReader reader)
        {
            UserID = Convert.ToUInt32(reader[0].ToString());
            ElementID = Convert.ToUInt32(reader[1].ToString());
        }
    }
}
