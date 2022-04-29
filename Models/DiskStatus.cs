using System;
using System.Collections.Generic;

#nullable disable

namespace DiskInventory.Models
{
    public partial class DiskStatus
    {
        public DiskStatus()
        {
            Disks = new HashSet<Disk>();
        }

        public int StatusId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Disk> Disks { get; set; }
    }
}
