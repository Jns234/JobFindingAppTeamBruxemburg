using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobFindingAppTeamBruxemburg.Data
{
    public abstract class Entity
    {
    }

    public abstract class Entity<TKEY> : Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKEY Id { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            var comparer = Comparer<TKEY>.Default;
            var result = comparer.Compare(this.Id, (obj as Entity<TKEY>).Id);
            return (result == 0);
        }

        public static bool operator ==(Entity<TKEY> entity1, Entity<TKEY> entity2)
        {
            if (ReferenceEquals(entity1, entity2))
            {
                return true;
            }

            if (ReferenceEquals(entity1, null))
            {
                return false;
            }

            if (ReferenceEquals(entity2, null))
            {
                return false;
            }

            return entity1.Equals(entity2);
        }

        public static bool operator !=(Entity<TKEY> entity1, Entity<TKEY> entity2)
        {
            return !(entity1 == entity2);
        }

        public override int GetHashCode()
        {
            return (GetType() + ":" + Id).GetHashCode();
        }
    }
}