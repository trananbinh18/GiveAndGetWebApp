//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace giveandgetwebapp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Post()
        {
            this.Notifications = new HashSet<Notification>();
            this.Reports = new HashSet<Report>();
            this.Users = new HashSet<User>();
            this.Users1 = new HashSet<User>();
            this.Users2 = new HashSet<User>();
        }
    
        public int Id { get; set; }
        public Nullable<int> CatalogId { get; set; }
        public Nullable<int> Actor { get; set; }
        public Nullable<int> Receiver { get; set; }
        public Nullable<int> Image { get; set; }
        public Nullable<int> Image2 { get; set; }
        public Nullable<int> Image3 { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ExpireDate { get; set; }
        public Nullable<int> GiveType { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> ReceiverCount { get; set; }
        public Nullable<int> ExpireType { get; set; }
        public Nullable<int> LikeCount { get; set; }
    
        public virtual Catalog Catalog { get; set; }
        public virtual Image Image1 { get; set; }
        public virtual Image Image4 { get; set; }
        public virtual Image Image5 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Report> Reports { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users2 { get; set; }
    }
}
