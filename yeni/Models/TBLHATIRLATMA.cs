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
    
    public partial class TBLHATIRLATMA
    {
        public int HatırlatmaID { get; set; }
        public string HatırlatmaSebep { get; set; }
        public Nullable<System.DateTime> HatırlatmaTarıh { get; set; }
        public Nullable<System.DateTime> KayıtTarıh { get; set; }
        public string Mesaj { get; set; }
        public Nullable<bool> DURUM { get; set; }
    }
}
