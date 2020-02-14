using System.Data.Common;

namespace Assets.Scripts.Database.Models
{
    public abstract class ModelBase
    {
        public abstract void Populate(DbDataReader reader);
        public abstract string GenerateInsertQuery();
    }
}
