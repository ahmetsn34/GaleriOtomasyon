//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AraçKiralama2023.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLFIRMAHAREKETLERI
    {
        public int HAREKETID { get; set; }
        public string URUN { get; set; }
        public string ACIKLAMA { get; set; }
        public Nullable<decimal> TUTAR { get; set; }
        public Nullable<decimal> ADET { get; set; }
        public Nullable<System.DateTime> TARIH { get; set; }
        public Nullable<int> FIRMA { get; set; }
        public Nullable<int> TUR { get; set; }
        public Nullable<bool> DURUM { get; set; }
    
        public virtual TBLODEMEBICIM TBLODEMEBICIM { get; set; }
        public virtual TBLSIRKET TBLSIRKET { get; set; }
    }
}
