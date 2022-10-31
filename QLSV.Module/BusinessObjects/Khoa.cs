using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace QLSV.Module.BusinessObjects
{
    [DefaultClassOptions]
    [ImageName("BO_Contact")]
    [XafDisplayName("Khoa")]
    [DefaultProperty(nameof(TenKhoa))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [NavigationItem(Menu.CategoryMenuItem)]
    public class Khoa : BaseObject
    { 
        public Khoa(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        string tenKhoa;
        string maKhoa;
        [XafDisplayName("Mã khoa")]
        [RuleRequiredField("Bắt buộc phải có Khoa.MaKhoa", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string MaKhoa
        {
            get => maKhoa;
            set => SetPropertyValue(nameof(MaKhoa), ref maKhoa, value);
        }
        [XafDisplayName("Tên khoa")]
        [RuleRequiredField("Bắt buộc phải có Khoa.TenKhoa", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenKhoa
        {
            get => tenKhoa;
            set => SetPropertyValue(nameof(TenKhoa), ref tenKhoa, value);
        }
        [XafDisplayName("Danh sách lớp")]
        [Association("Khoa-Lops")]
        public XPCollection<Lop> Lops
        {
            get
            {
                return GetCollection<Lop>(nameof(Lops));
            }
        }
    }
}