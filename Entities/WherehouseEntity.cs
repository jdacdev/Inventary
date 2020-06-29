using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class WherehouseEntity
    {
        [Key]
        [StringLength(50)]
        public string WherehouseEntityId { get; set; }

        [Required]        
        [StringLength(100)]
        public string WherehouseEntityName { get; set; }

        [Required]
        [StringLength(100)]
        public string WherehouseEntityAddress { get; set; }

        public ICollection<ProductEntity> Products { get; set; }
    }
}
