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
    
    public partial class TBLPERSONEL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLPERSONEL()
        {
            this.TBLPERSODEME = new HashSet<TBLPERSODEME>();
            this.TBLPERSONELODEME = new HashSet<TBLPERSONELODEME>();
        }
    
        public int PerID { get; set; }
        public string PerAd { get; set; }
        public string PerSoyad { get; set; }
        public string PerTelefon { get; set; }
        public string PerTC { get; set; }
        public string PerSicil { get; set; }
        public Nullable<System.DateTime> PerGirisTarih { get; set; }
        public string PerAdres { get; set; }
        public string PerFoto { get; set; }
        public Nullable<bool> DURUM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLPERSODEME> TBLPERSODEME { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLPERSONELODEME> TBLPERSONELODEME { get; set; }
    }
}
