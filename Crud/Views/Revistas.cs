//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Crud.Views
{
    using System;
    using System.Collections.Generic;
    
    public partial class Revistas
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public Nullable<int> Edicion { get; set; }
        public string Codigo_barras { get; set; }
        public Nullable<System.DateTime> Fecha_Publicacion { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<int> Categorias_Id { get; set; }
        public Nullable<System.DateTime> Fecha_Actualizacion { get; set; }
    
        public virtual Categorias Categorias { get; set; }
    }
}
