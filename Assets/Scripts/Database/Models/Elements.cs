using System;
using System.Data.Common;

namespace Assets.Scripts.Database.Models
{
    public class elements : ModelBase
    {
        public int ID;
        public string Name;
        public string Symbol;
        public int Electrons;
        public int Protons;
        public int Neutrons;

        public override string GenerateInsertQuery()
        {
            throw new NotImplementedException();
        }

        public override void Populate(DbDataReader reader)
        {
            ID = Convert.ToInt32(reader[0]);
            Name = Convert.ToString(reader[1]);
            Symbol = Convert.ToString(reader[2]);
            Electrons = Convert.ToInt32(reader[3]);
            Protons = Convert.ToInt32(reader[4]);
            Neutrons = Convert.ToInt32(reader[5]);
        }
    }
}
