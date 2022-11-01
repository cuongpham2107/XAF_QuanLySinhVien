using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.SystemModule;
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
    [XafDisplayName("Sinh viên")]
    [DefaultProperty(nameof(HoTen))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [NavigationItem(Menu.DataMenuItem)]

    [ListViewFilter("Tất cả", "", Index = 1)]
    [ListViewFilter("Xếp loại Xuất sắc", "[HanhKiem] = ##Enum#QLSV.Module.BusinessObjects.HanhKiem,XX#", Index = 2)]
    [ListViewFilter("Xếp loại Tốt", "[HanhKiem] = ##Enum#QLSV.Module.BusinessObjects.HanhKiem,T#", Index = 3)]
    [ListViewFilter("Xếp loại Khá", "[HanhKiem] = ##Enum#QLSV.Module.BusinessObjects.HanhKiem,K#", Index = 4)]
    [ListViewFilter("Xếp loại Trung bình", "[HanhKiem] = ##Enum#QLSV.Module.BusinessObjects.HanhKiem,TB#", Index = 5)]
    [ListViewFilter("Xếp loại Yếu", "[HanhKiem] = ##Enum#QLSV.Module.BusinessObjects.HanhKiem,Y#", Index = 6)]
    public class SinhVien : BaseObject
    { 
        public SinhVien(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        protected override void OnLoaded()
        {
            base.OnLoaded();
            DiemTichLuy = KetQuaHocTaps.Sum(i => i.DiemTongKet) / KetQuaHocTaps.Count();
        }
        string nienKhoa;
        float diemTichLuy;
        HanhKiem hanhKiem;
        byte[] anh;
        Lop lop;
        string email;
        string soDienThoai;
        string diaChi;
        GioiTinh gioiTinh;
        DateTime ngaySinh;
        string hoTen;
        string maSinhVien;
        [XafDisplayName("Mã sinh viên")]
        [RuleRequiredField("Bắt buộc phải có SinhVien.MaSinhVien", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string MaSinhVien
        {
            get => maSinhVien;
            set => SetPropertyValue(nameof(MaSinhVien), ref maSinhVien, value);
        }

        [XafDisplayName("Họ và tên")]
        [RuleRequiredField("Bắt buộc phải có SinhVien.HoTen", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string HoTen
        {
            get => hoTen;
            set => SetPropertyValue(nameof(HoTen), ref hoTen, value);
        }
        [XafDisplayName("Ngày sinh")]
        [RuleRequiredField("Bắt buộc phải có SinhVien.NgaySinh", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public DateTime NgaySinh
        {
            get => ngaySinh;
            set => SetPropertyValue(nameof(NgaySinh), ref ngaySinh, value);
        }
        [XafDisplayName("Giới tính")]
        public GioiTinh GioiTinh
        {
            get => gioiTinh;
            set => SetPropertyValue(nameof(GioiTinh), ref gioiTinh, value);
        }
        [XafDisplayName("Địa chỉ")]
        [RuleRequiredField("Bắt buộc phải có SinhVien.DiaChi", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public string DiaChi
        {
            get => diaChi;
            set => SetPropertyValue(nameof(DiaChi), ref diaChi, value);
        }
        [XafDisplayName("Số điện thoại")]
        [RuleRequiredField("Bắt buộc phải có SinhVien.SoDienThoai", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
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
        [XafDisplayName("Niên khoá")]
        public string NienKhoa
        {
            get => nienKhoa;
            set => SetPropertyValue(nameof(NienKhoa), ref nienKhoa, value);
        }
        [XafDisplayName("Thuộc lớp")]
        [Association("Lop-SinhViens")]
        [RuleRequiredField("Bắt buộc phải có SinhVien.Lop", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        public Lop Lop
        {
            get => lop;
            set => SetPropertyValue(nameof(Lop), ref lop, value);
        }
        [XafDisplayName("Điểm tích luỹ")]
        [ModelDefault("AllowEdit","False")]
        public float DiemTichLuy
        {
            get => diemTichLuy;
            set => SetPropertyValue(nameof(DiemTichLuy), ref diemTichLuy, value);
        }
        [XafDisplayName("Hạnh kiểm")]
        public HanhKiem HanhKiem
        {
            get => hanhKiem;
            set => SetPropertyValue(nameof(HanhKiem), ref hanhKiem, value);
        }
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, ListViewImageEditorCustomHeight = 40)]
        [XafDisplayName("Ảnh")]
        public byte[] Anh
        {
            get => anh;
            set => SetPropertyValue(nameof(Anh), ref anh, value);
        }
        [XafDisplayName("Danh sách điểm các môn học")]
        [Association("SinhVien-KetQuaHocTaps")]
        public XPCollection<KetQuaHocTap> KetQuaHocTaps
        {
            get
            {
                return GetCollection<KetQuaHocTap>(nameof(KetQuaHocTaps));
            }
        }
        
        
        
    }
    public enum GioiTinh
    {
        [XafDisplayName("Nam")] Nam = 0,
        [XafDisplayName("Nữ")] Nu = 1,
    }
}