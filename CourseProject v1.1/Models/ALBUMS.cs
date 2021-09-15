namespace CourseProject_v1._1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ALBUMS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ALBUMS()
        {
            TRACKS = new HashSet<TRACKS>();
        }

        public int? id_user { get; set; }

        public int? genre_id { get; set; }

        [Key]
        public int album_id { get; set; }

        [Required]
        [StringLength(255)]
        public string albums_name { get; set; }

        public virtual GENRES GENRES { get; set; }

        public virtual USERS USERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACKS> TRACKS { get; set; }
        public ALBUMS(int genre_id, int user_id, string name)
        {
            this.genre_id = genre_id;
            this.id_user = user_id;
            this.albums_name = name;
        }
    }
}
