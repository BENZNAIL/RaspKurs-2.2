//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RaspKurs.AplicationData
{
    using System;
    using System.Collections.Generic;
    
    public partial class Prepod
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prepod()
        {
            this.Para = new HashSet<Para>();
        }
    
        public int id_prepod { get; set; }
        public string lname_prepod { get; set; }
        public string name_prepod { get; set; }
        public string mname_prepod { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int id_role_prepod { get; set; }
        public int id_spec_prepod { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Para> Para { get; set; }
        public virtual Role Role { get; set; }
        public virtual Spec Spec { get; set; }
    }
}
