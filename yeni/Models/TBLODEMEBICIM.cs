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
    
    public partial class TBLODEMEBICIM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLODEMEBICIM()
        {
            this.TBLÇEKSENET = new HashSet<TBLÇEKSENET>();
            this.TBLFIRMAHAREKETLERI = new HashSet<TBLFIRMAHAREKETLERI>();
            this.TBLPERSODEME = new HashSet<TBLPERSODEME>();
            this.TBLPERSONELODEME = new HashSet<TBLPERSONELODEME>();
            this.TBLPERSONELODEME1 = new HashSet<TBLPERSONELODEME>();
        }
    
        public int BıcımID { get; set; }
        public string OdemeTıpı { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLÇEKSENET> TBLÇEKSENET { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLFIRMAHAREKETLERI> TBLFIRMAHAREKETLERI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLPERSODEME> TBLPERSODEME { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLPERSONELODEME> TBLPERSONELODEME { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLPERSONELODEME> TBLPERSONELODEME1 { get; set; }
    }
}
