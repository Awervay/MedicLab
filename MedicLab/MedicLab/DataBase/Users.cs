//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MedicLab.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.Blood_Service = new HashSet<Blood_Service>();
            this.HistoryLogUsers = new HashSet<HistoryLogUsers>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string ip { get; set; }
        public Nullable<System.DateTime> lastenter { get; set; }
        public int id_services1 { get; set; }
        public Nullable<int> id_services2 { get; set; }
        public Nullable<int> id_services3 { get; set; }
        public Nullable<int> id_services4 { get; set; }
        public Nullable<int> id_services5 { get; set; }
        public int type { get; set; }
        public string Attempt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Blood_Service> Blood_Service { get; set; }
        public virtual Services Services { get; set; }
        public virtual Services Services1 { get; set; }
        public virtual Services Services2 { get; set; }
        public virtual Services Services3 { get; set; }
        public virtual Services Services4 { get; set; }
        public virtual Type_User Type_User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HistoryLogUsers> HistoryLogUsers { get; set; }
    }
}
