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
    
    public partial class role_actors
    {
        public int id_creator { get; set; }
        public int id_film { get; set; }
        public string role_actor { get; set; }
    
        public virtual creators_film creators_film { get; set; }
        public virtual films films { get; set; }
    }
}