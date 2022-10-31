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
    [XafDisplayName("Kết quả học tập")]
    [DefaultProperty(nameof(SinhVien))]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    [ListViewFindPanel(true)]
    [LookupEditorMode(LookupEditorMode.AllItemsWithSearch)]
    [NavigationItem(Menu.DataMenuItem)]
    public class KetQuaHocTap : BaseObject
    { 
        public KetQuaHocTap(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
           
        }
        HocKi hocKi;
        MonHoc monHoc;
        string ghiChu;
        HanhKiem hanhKiem;
        float diemTongKet;
        float diemThi;
        float diemKiemTra;
        float diemTrenLop;
        string maSV;
        SinhVien sinhVien;
        [XafDisplayName("Mã sinh viên")]
        [ModelDefault("AllowEdit", "False")]
        public string MaSV
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    if (SinhVien != null)
                    {
                        return SinhVien.MaSinhVien;
                    }
                }
                return null;
            }
        }
        [XafDisplayName("Sinh Viên")]
        [Association("SinhVien-KetQuaHocTaps")]
        [RuleRequiredField("Bắt buộc phải có KetQuaHocTap.SinhVien", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [ModelDefault("ImmediatePostData", "True")]
        public SinhVien SinhVien
        {
            get => sinhVien;
            set => SetPropertyValue(nameof(SinhVien), ref sinhVien, value);
        }

        [PersistentAlias("[SinhVien.Lop]")]
        [ModelDefault("AllowEdit", "False")]
        [XafDisplayName("Thuộc lớp")]
        //[Association("Lop-KetQuaHocTaps")]
        public Lop Lop
        {
            get
            {
                var tmp = EvaluateAlias(nameof(Lop));
                if (tmp != null)
                {
                    return tmp as Lop;
                }
                else
                {
                    return null;
                }
            }
        }
        [XafDisplayName("Môn học")]
        [RuleRequiredField("Bắt buộc phải có KetQuaHocTap.MonHoc", DefaultContexts.Save, "Trường dữ liệu không được để trống")]
        [Association("MonHoc-KetQuaHocTaps")]
        public MonHoc MonHoc
        {
            get => monHoc;
            set => SetPropertyValue(nameof(MonHoc), ref monHoc, value);
        }
        [XafDisplayName("Điểm trung bình trên lớp")]
        public float DiemTrenLop
        {
            get => diemTrenLop;
            set => SetPropertyValue(nameof(DiemTrenLop), ref diemTrenLop, value);
        }
        [XafDisplayName("Điểm thi")]
        public float DiemThi
        {
            get => diemThi;
            set => SetPropertyValue(nameof(DiemThi), ref diemThi, value);
        }
        [XafDisplayName("Điểm tổng kết")]
        [ModelDefault("AllowEdit", "False")]
        public float DiemTongKet
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    return (float)Math.Round((DiemThi * 70 + DiemTrenLop * 30) / 100, 1);
                }
                return 0;
            }
        }
        [XafDisplayName("Điểm hệ số 4")]
        [ModelDefault("AllowEdit","False")]
        public float DiemHeSo4
        {
            get
            {
                if(!IsLoading && !IsSaving)
                {
                    return (float)Math.Round((DiemTongKet / 10) * 4,1);
                }
                return 0;
            }
        }
        [XafDisplayName("Điểm chữ")]
        [ModelDefault("AllowEdit", "False")]
        public string DiemChu
        {
            get
            {
                if (!IsLoading && !IsSaving)
                {
                    if(DiemTongKet > 0 && DiemTongKet <= 3.9)
                    {
                        return "F";
                    }
                    else if(DiemTongKet >= 4.0 && DiemTongKet <= 5.4)
                    {
                        return "D";
                    }
                    else if (DiemTongKet >= 5.5 && DiemTongKet <= 6.9)
                    {
                        return "C";
                    }
                    else if (DiemTongKet >= 7.0 && DiemTongKet <= 8.4)
                    {
                        return "B";
                    }
                    else if (DiemTongKet >= 8.5 && DiemTongKet <= 10)
                    {
                        return "A";
                    }
                    return null;
                }
                return null;
            }
        }
        [XafDisplayName("Học kì")]
        [ModelDefault("AllowEdit", "False")]
        public HocKi HocKi
        {
            get
            {
                if(!IsLoading && !IsSaving)
                {
                    if(MonHoc != null)
                    {
                        return MonHoc.HocKi;
                    }
                }
                return HocKi.hk1;
            }
        }

        //[XafDisplayName("Hạnh kiểm")]
        //public HanhKiem HanhKiem
        //{
        //    get => hanhKiem;
        //    set => SetPropertyValue(nameof(HanhKiem), ref hanhKiem, value);
        //}
        [XafDisplayName("Ghi chú")]
        public string GhiChu
        {
            get => ghiChu;
            set => SetPropertyValue(nameof(GhiChu), ref ghiChu, value);
        }

    }
    public enum HanhKiem
    {
        [XafDisplayName("Xuất sắc")] XX = 0,
        [XafDisplayName("Tốt")] T = 1,
        [XafDisplayName("Khá")] K = 2,
        [XafDisplayName("Trung bình")] TB = 3,
        [XafDisplayName("Yếu")] Y = 4,
    }
}