//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Acme.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class newspaper
    {
        public newspaper()
        {
            this.ads = new HashSet<ad>();
        }
    
        public int newspaper_id { get; set; }
        public string newspaper_name { get; set; }
    
        public virtual ICollection<ad> ads { get; set; }
    }
}
