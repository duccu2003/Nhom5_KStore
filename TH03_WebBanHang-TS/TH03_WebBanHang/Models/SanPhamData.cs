//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TH03_WebBanHang.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SanPhamData
    {
        public string MaSP { get; set; }
        public string DuongDan1 { get; set; }
        public string DuongDan2 { get; set; }
        public string DuongDan3 { get; set; }
        public string DuongDan4 { get; set; }
        public string DuongDan5 { get; set; }
        public string AnhNote { get; set; }
        public Nullable<bool> Pob { get; set; }
        public Nullable<bool> IsPreOrder { get; set; }
    
        public virtual SanPham SanPham { get; set; }
    }
}
