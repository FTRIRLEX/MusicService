namespace CourseProject_v1._1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PLAYLISTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PLAYLISTS()
        {
            TRACKS = new HashSet<TRACKS>();
        }

        public int? id_user { get; set; }

        [Key]
        public int playlist_id { get; set; }

        [Required]
        [StringLength(255)]
        public string playlist_name { get; set; }

        public virtual USERS USERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACKS> TRACKS { get; set; }
        public PLAYLISTS(int user_id, string playlist_name)
        {
            this.id_user = user_id;
            this.playlist_name = playlist_name;

        }
    }
}
