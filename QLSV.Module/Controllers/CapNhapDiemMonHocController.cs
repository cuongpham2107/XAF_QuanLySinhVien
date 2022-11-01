using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QLSV.Module.BusinessObjects;

namespace QLSV.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CapNhapDiemMonHocController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public CapNhapDiemMonHocController()
        {
            InitializeComponent();
        }
        protected override void OnAfterConstruction()
        {
            base.OnViewControlsCreated();
            Btn_CapNhapDiemMonHoc();
        }
        private void Btn_CapNhapDiemMonHoc()
        {
            var action = new SimpleAction(this, $"{nameof(MonHoc)}-{nameof(Btn_CapNhapDiemMonHoc)}", "Edit")
            {
                Caption = "Thêm mới điểm cho sinh viên của môn học này",
                ImageName = "SnapInsertHeader",
                TargetViewNesting = Nesting.Nested,
                TargetObjectType = typeof(KetQuaHocTap),
                TargetViewType = ViewType.ListView,
                SelectionDependencyType = SelectionDependencyType.Independent,
            };
            action.Execute += (sender, args) =>
            {
                if (((DetailView)ObjectSpace.Owner).CurrentObject is MonHoc td)
                {

                    NewObjectViewController controller = Frame.GetController<NewObjectViewController>();
                    if (controller != null)
                    {
                        void Created(object sender, ObjectCreatedEventArgs e)
                        {
                            var kqht = e.CreatedObject as KetQuaHocTap;
                            var monHoc = e.ObjectSpace.GetObject(td);
                            kqht.MonHoc = monHoc;
                        }
                        controller.ObjectCreated += Created;
                        controller.NewObjectAction.DoExecute(controller.NewObjectAction.Items[0]);

                    }

                }
            };
        }
    }
}
