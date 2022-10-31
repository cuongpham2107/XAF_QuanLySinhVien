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
    [XafDisplayName("Năm học")]
    [DefaultProperty(nameof(TenNamHoc))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [NavigationItem(Menu.CategoryMenuItem)]
    public class NamHoc : BaseObject
    { 
        public NamHoc(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        string tenNamHoc;
        [XafDisplayName("Tên năm học")]
        [RuleRequiredField("Bắt buộc phải có NamHoc.TenNamHoc", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenNamHoc
        {
            get => tenNamHoc;
            set => SetPropertyValue(nameof(TenNamHoc), ref tenNamHoc, value);
        }
    }
}