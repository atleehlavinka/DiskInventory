using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace DiskInventory.Models
{
    public partial class Disk
    {
        public Disk()
        {
            DiskHasBorrowers = new HashSet<DiskHasBorrower>();
        }

        public int DiskId { get; set; }
        [Required(ErrorMessage = "Please enter a Disk Name.")]
        public string DiskName { get; set; }
        [Required(ErrorMessage = "Please enter a Disk Artist.")]
        public string DiskArtist { get; set; }
        [Required(ErrorMessage = "Please enter a Release Date.")]
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "Please enter a Status.")]
        public int StatusId { get; set; }
        [Required(ErrorMessage = "Please enter a Disk Type ID.")]
        public int DiskTypeId { get; set; }
        [Required(ErrorMessage = "Please enter a Genre ID")]
        public int GenreId { get; set; }

        public virtual DiskType DiskType { get; set; }
        public virtual DiskGenre Genre { get; set; }
        public virtual DiskStatus Status { get; set; }
        public virtual ICollection<DiskHasBorrower> DiskHasBorrowers { get; set; }
    }
}
