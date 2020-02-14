using System;
using System.Data.Common;

namespace Assets.Scripts.Database.Models
{
    class users : ModelBase
    {
        public uint UserID;
        public string Username;
        public DateTime JoinDate;

        public override string GenerateInsertQuery()
        {
            throw new NotImplementedException();
        }

        public override void Populate(DbDataReader reader)
        {
            UserID = Convert.ToUInt32(reader[0].ToString());
            Username = reader[0].ToString();
            JoinDate = DateTime.Parse(reader[0].ToString());
        }
    }
}
