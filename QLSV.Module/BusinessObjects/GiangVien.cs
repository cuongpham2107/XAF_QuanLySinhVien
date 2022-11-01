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
    [XafDisplayName("Giảng viên")]
    [DefaultProperty(nameof(TenGiaoVien))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [NavigationItem(Menu.CategoryMenuItem)]
    public class GiangVien : BaseObject
    { 
        public GiangVien(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }
        byte[] anh;
        PhanLoaiGV phanLoaiGV;
        string email;
        string soDienThoai;
        string diaChi;
        GioiTinh gioiTinh;
        string tenGiaoVien;
        string maGV;
        [XafDisplayName("Mã giảng viên")]
        [RuleRequiredField("Bắt buộc phải có GiangVien.MaGV", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string MaGV
        {
            get => maGV;
            set => SetPropertyValue(nameof(MaGV), ref maGV, value);
        }
        [XafDisplayName("Tên giảng viên")]
        [RuleRequiredField("Bắt buộc phải có GiangVien.TenGiaoVien", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string TenGiaoVien
        {
            get => tenGiaoVien;
            set => SetPropertyValue(nameof(TenGiaoVien), ref tenGiaoVien, value);
        }
        [XafDisplayName("Giới tính")]
        public GioiTinh GioiTinh
        {
            get => gioiTinh;
            set => SetPropertyValue(nameof(GioiTinh), ref gioiTinh, value);
        }
        [XafDisplayName("Địa chỉ")]
        public string DiaChi
        {
            get => diaChi;
            set => SetPropertyValue(nameof(DiaChi), ref diaChi, value);
        }
        [XafDisplayName("Số điện thoại")]
        public string SoDienThoai
        {
            get => soDienThoai;
            set => SetPropertyValue(nameof(SoDienThoai), ref soDienThoai, value);
        }
        [XafDisplayName("Địa chỉ email")]
        public string Email
        {
            get => email;
            set => SetPropertyValue(nameof(Email), ref email, value);
        }
        [XafDisplayName("Phân loại Giảng viên")]
        public PhanLoaiGV PhanLoaiGV
        {
            get => phanLoaiGV;
            set => SetPropertyValue(nameof(PhanLoaiGV), ref phanLoaiGV, value);
        }
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, ListViewImageEditorCustomHeight = 40)]
        [XafDisplayName("Ảnh")]
        public byte[] Anh
        {
            get => anh;
            set => SetPropertyValue(nameof(Anh), ref anh, value);
        }
        [XafDisplayName("Danh sách môn học được phân công giảng dậy")]
        [Association("GiangVien-MonHocs")]
        public XPCollection<MonHoc> MonHocs
        {
            get
            {
                return GetCollection<MonHoc>(nameof(MonHocs));
            }
        }
        [XafDisplayName("Danh sách tài khoản"),ToolTip("")]
        [Association("GiangVien-ApplicationUsers")]
        [VisibleInDetailView(false)]
        public XPCollection<ApplicationUser> ApplicationUsers => GetCollection<ApplicationUser>(nameof(ApplicationUsers));
    }
    public enum PhanLoaiGV
    {
        [XafDisplayName("Giảng viên giỏi")] Gv = 1,
        [XafDisplayName("Giảng viên tiên tiến")] tt = 2,

    }
}