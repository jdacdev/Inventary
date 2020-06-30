using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class WarehouseEntity
    {
        [Key]
        [StringLength(50)]
        public string WarehouseEntityId { get; set; }

        [Required]        
        [StringLength(100)]
        public string WarehouseEntityName { get; set; }

        [Required]
        [StringLength(100)]
        public string WarehouseEntityAddress { get; set; }

        public ICollection<StorageEntity> Storages { get; set; }
    }
}
