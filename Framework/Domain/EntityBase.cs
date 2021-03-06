using System;
using System.ComponentModel.DataAnnotations;

namespace Framework.Domain
{
    public abstract class EntityBase
    {
        [Key]
        public long Id { get; private set; }
        public bool IsDelete { get;  set; }
        public DateTime CreationDate { get; private set; }
        public DateTime LastUpdateDate { get; set; }
        public DateTime DeletionDate { get; set; }

        protected EntityBase()
        {
            CreationDate = DateTime.Now;
            IsDelete = false;
        }
    }
}
