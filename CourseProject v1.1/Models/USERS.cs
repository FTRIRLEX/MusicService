namespace CourseProject_v1._1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Security.Cryptography;
    using System.Text;

    public partial class USERS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USERS()
        {
            ALBUMS = new HashSet<ALBUMS>();
            PLAYLISTS = new HashSet<PLAYLISTS>();
            TRACKS = new HashSet<TRACKS>();
            TRACKS1 = new HashSet<TRACKS>();
        }

        [Key]
        public int id_user { get; set; }

        [Required]
        [StringLength(255)]
        public string user_login { get; set; }

        [StringLength(255)]
        public string user_nickname { get; set; }

        [Required]
        [StringLength(255)]
        public string user_password { get; set; }

        public int? user_role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ALBUMS> ALBUMS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PLAYLISTS> PLAYLISTS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACKS> TRACKS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRACKS> TRACKS1 { get; set; }

        public static string getHash(string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return "Error";
            }
            else
            {
                var md5 = MD5.Create();
                var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }

        public USERS(string _login, string _password, string _nickname)
        {
            this.user_login = _login;
            this.user_password = _password;
            this.user_nickname = _nickname;
            this.user_role = 0;
        }
    }
}
