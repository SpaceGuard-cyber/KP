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
    
    public partial class marks
    {
        public int id_users { get; set; }
        public int id_films { get; set; }
        public Nullable<double> marks1 { get; set; }
        public string comments { get; set; }
    
        public virtual films films { get; set; }
        public virtual Users Users { get; set; }
    }
}