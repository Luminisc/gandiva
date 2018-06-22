using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gandiva.Data.Entity
{
    public abstract class Entity
    {
        protected Entity()
        {
            CreatedDate = DateTime.Now;
            IsActual = true;
        }

        [Key] //optional
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActual { get; set; }

    }
}