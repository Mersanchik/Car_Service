//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarDealership.bd
{
    using System;
    using System.Collections.Generic;
    
    public partial class UnderRepair
    {
        public int idUnderRepair { get; set; }
        public Nullable<int> id_Car { get; set; }
        public Nullable<int> id_Employee { get; set; }
        public Nullable<int> id_Part { get; set; }
        public Nullable<System.DateTime> DateStar { get; set; }
        public string Status { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual PartsWarehouse PartsWarehouse { get; set; }
    }
}
