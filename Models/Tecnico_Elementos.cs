//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Laboratorio.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tecnico_Elementos
    {
        public int id_tecnico_elemento { get; set; }
        public Nullable<int> id_tecnico { get; set; }
        public Nullable<int> id_elemento { get; set; }
        public Nullable<int> cantidad { get; set; }
    
        public virtual Elementos Elementos { get; set; }
        public virtual Tecnico Tecnico { get; set; }
    }
}
