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
    [XafDisplayName("Môn học")]
    [DefaultProperty(nameof(TenMon))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [NavigationItem(Menu.CategoryMenuItem)]
    public class MonHoc : BaseObject
    { 
        public MonHoc(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }

        GiangVien giangVien;
        Khoa khoa;
        HocKi hocKi;
        int soTinChi;
        string tenMon;
        string maMonHoc;
        [XafDisplayName("Mã môn học")]
        [RuleRequiredField("Bắt buộc phải có MonHoc.MaMonHoc", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string MaMonHoc
        {
            get => maMonHoc;
            set => SetPropertyValue(nameof(MaMonHoc), ref maMonHoc, value);
        }

        [XafDisplayName("Tên môn học")]
        [RuleRequiredField("Bắt buộc phải có MonHoc.TenMon", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenMon
        {
            get => tenMon;
            set => SetPropertyValue(nameof(TenMon), ref tenMon, value);
        }

        [XafDisplayName("Số tín chỉ")]
        public int SoTinChi
        {
            get => soTinChi;
            set => SetPropertyValue(nameof(SoTinChi), ref soTinChi, value);
        }
        [XafDisplayName("Giảng viên dậy")]
        [Association("GiangVien-MonHocs")]
        [RuleRequiredField("Bắt buộc phải có MonHoc.GiangVien", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public GiangVien GiangVien
        {
            get => giangVien;
            set => SetPropertyValue(nameof(GiangVien), ref giangVien, value);
        }
        [XafDisplayName("Học kì")]
        public HocKi HocKi
        {
            get => hocKi;
            set => SetPropertyValue(nameof(HocKi), ref hocKi, value);
        }
        NamHoc namHoc;
        [XafDisplayName("Năm học")]
        public NamHoc NamHoc
        {
            get => namHoc;
            set => SetPropertyValue(nameof(NamHoc), ref namHoc, value);
        }
        [XafDisplayName("Thuộc khoa")]
        public Khoa Khoa
        {
            get => khoa;
            set => SetPropertyValue(nameof(Khoa), ref khoa, value);
        }
        [XafDisplayName("Danh sách điểm của sinh viên")]
        [Association("MonHoc-KetQuaHocTaps")]
        public XPCollection<KetQuaHocTap> KetQuaHocTaps
        {
            get
            {
                return GetCollection<KetQuaHocTap>(nameof(KetQuaHocTaps));
            }
        }

    }
    public enum HocKi
    {
        [XafDisplayName("Học kỳ I")] hk1 = 1,
        [XafDisplayName("Học kỳ II")] hk2 = 2,
        [XafDisplayName("Học kỳ III")] hk3 = 3,
        [XafDisplayName("Học kỳ IV")] hk4 = 4,
        [XafDisplayName("Học kỳ V")] hk5 = 5,
        [XafDisplayName("Học kỳ VI")] hk6 = 6,
        [XafDisplayName("Học kỳ VII")] hk7 = 7,
        [XafDisplayName("Học kỳ VIII")] hk8 = 8,
        [XafDisplayName("Học kỳ IX")] hk9 = 9,
        [XafDisplayName("Học kỳ X")] hk10 = 10,

    }
}