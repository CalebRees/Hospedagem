//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hospedagem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Quarto
    {
        public int IDEstab { get; set; }
        public int NumeroQuarto { get; set; }
        public int IDTipoQuarto { get; set; }
        public bool Disponivel { get; set; }
    
        public virtual Estabelecimento Estabelecimento { get; set; }
        public virtual TipoQuarto TipoQuarto { get; set; }
    }
}
