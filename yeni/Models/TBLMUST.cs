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
    
    public partial class TBLMUST
    {
        public int MustID { get; set; }
        public string MustAdı { get; set; }
        public string MustSoyad { get; set; }
        public string MustTC { get; set; }
        public string MustEhliyetNo { get; set; }
        public string MustAdres { get; set; }
        public string MustTelefon { get; set; }
        public Nullable<bool> DURUM { get; set; }
        public string FOTO { get; set; }
        public Nullable<System.DateTime> GirisTarih { get; set; }
    }
}
