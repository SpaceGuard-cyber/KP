//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KP
{
    using System;
    using System.Collections.Generic;
    
    public partial class creators_film
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public creators_film()
        {
            this.role_actors = new HashSet<role_actors>();
        }
    
        public int id_creator { get; set; }
        public string actor_name { get; set; }
        public string actor_lastname { get; set; }
        public string actor_secondname { get; set; }
        public Nullable<System.DateTime> dateofbirth { get; set; }
        public Nullable<System.DateTime> dateofcareer { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<role_actors> role_actors { get; set; }
    }
}
