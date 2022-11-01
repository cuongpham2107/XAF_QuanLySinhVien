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
    [XafDisplayName("Lớp")]
    [DefaultProperty(nameof(TenLop))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [NavigationItem(Menu.DataMenuItem)]
    public class Lop : BaseObject
    { 
        public Lop(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        KhoaHoc khoaHoc;
        Khoa khoa;
        string tenLop;
        string maLop;
        [XafDisplayName("Mã lớp")]
        [RuleRequiredField("Bắt buộc phải có Lop.MaLop", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string MaLop
        {
            get => maLop;
            set => SetPropertyValue(nameof(MaLop), ref maLop, value);
        }
        [XafDisplayName("Tên lớp")]
        [RuleRequiredField("Bắt buộc phải có Lop.TenLop", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenLop
        {
            get => tenLop;
            set
            {
                SetPropertyValue(nameof(TenLop), ref tenLop, value);
                
            }
        }
        [XafDisplayName("Khoá học")]
        [RuleRequiredField("Bắt buộc phải có Lop.KhoaHoc", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public KhoaHoc KhoaHoc
        {
            get => khoaHoc;
            set 
            { 
                SetPropertyValue(nameof(KhoaHoc), ref khoaHoc, value);
                if (!IsLoading && !IsSaving)
                {
                    TenLop = $"{TenLop} {KhoaHoc}";
                    MaLop = $"{MaLop} {KhoaHoc}";
                }
            }
        }
        [XafDisplayName("Thuộc khoa")]
        [Association("Khoa-Lops")]
        [RuleRequiredField("Bắt buộc phải có Lop.Khoa", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public Khoa Khoa
        {
            get => khoa;
            set => SetPropertyValue(nameof(Khoa), ref khoa, value);
        }
        [XafDisplayName("Danh sách sinh viên")]
        [Association("Lop-SinhViens")]
        public XPCollection<SinhVien> SinhViens
        {
            get
            {
                return GetCollection<SinhVien>(nameof(SinhViens));
            }
        }
        //[XafDisplayName("Kết quả học tập của sinh viên trong lớp")]
        //[Association("Lop-KetQuaHocTaps")]
        //public XPCollection<KetQuaHocTap> KetQuaHocTaps
        //{
        //    get
        //    {
        //        return GetCollection<KetQuaHocTap>(nameof(KetQuaHocTaps));
        //    }
        //}
    }
}