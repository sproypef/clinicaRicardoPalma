//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UPC.TP2.WEB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_BASE_FINANCIERA
    {
        public T_BASE_FINANCIERA()
        {
            this.T_PLAN_DE_SALUD = new HashSet<T_PLAN_DE_SALUD>();
        }
    
        public int id_base_financiera { get; set; }
        public string descripcion { get; set; }
        public string comentario { get; set; }
        public Nullable<int> monto { get; set; }
        public Nullable<int> presupuesto { get; set; }
        public string promocion { get; set; }
        public Nullable<System.DateTime> fecha_registro { get; set; }
    
        public virtual ICollection<T_PLAN_DE_SALUD> T_PLAN_DE_SALUD { get; set; }
    }
}
