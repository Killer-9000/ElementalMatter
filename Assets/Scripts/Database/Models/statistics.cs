using System;
using System.Data.Common;

namespace Assets.Scripts.Database.Models
{
    public class statistics : ModelBase
    {
        public uint UserID;
        public uint AtomsCreated;
        public uint HoursPlayed;

        public override string GenerateInsertQuery()
        {
            throw new System.NotImplementedException();
        }

        public override void Populate(DbDataReader reader)
        {
            UserID = Convert.ToUInt32(reader[0]);
            AtomsCreated = Convert.ToUInt32(reader[0]);
            HoursPlayed = Convert.ToUInt32(reader[0]);
        }
    }
}
