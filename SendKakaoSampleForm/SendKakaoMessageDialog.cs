using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

using Smes.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace SendKakaoSampleForm
{
    public partial class SendKakaoMessageDialog :Form
    {
        // This is for the MainGrd
        private BindingList<CustomerModel> SearchBindingList;
        private BindingList<CustomerModel> SelectedBindingList;

        /// <summary>
        ///일반 생성자. 등록모드로 시작할 때 사용 
        /// </summary>
        public SendKakaoMessageDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// grdSubModel 초기화
        /// </summary>
        private void InitApplication()
        {
            // 고객 테스트 데이터 생성
            // 좌측그리드
            SearchBindingList = new BindingList<CustomerModel>();
            CustomerModel cm;

            cm = new CustomerModel();
            cm.CustomerId = 1;
            cm.CustomerName = "파람스";
            cm.CtWorker = "이교준";
            cm.CtWorkerPhone = "010-4527-8888";
            SearchBindingList.Add(cm);

            cm = new CustomerModel();
            cm.CustomerId = 2;
            cm.CustomerName = "파람스";
            cm.CtWorker = "강문식";
            cm.CtWorkerPhone = "010-9703-3109";
            SearchBindingList.Add(cm);
            grdMain.DataSource = SearchBindingList; 

                // 우측 그리드
            SelectedBindingList = new BindingList<CustomerModel>();
            grdRight.DataSource = SelectedBindingList; 



            // 템플릿 가져오기           

        }

        private void MaterialOrderDialog_Load(object sender, EventArgs e)
        {         
            InitApplication();
        }        

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
           
        }


        private void tcbTemplate_SelectedValueChanged(object sender, EventArgs e)
        {
            // 템플릿 선택
        }

        private void grdMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            GridHitInfo hitInfo = grdMainView.CalcHitInfo(e.Location);
            if (hitInfo.InRowCell)
            {
                CustomerModel cm = grdMainView.GetRow(grdMainView.FocusedRowHandle) as CustomerModel;
                if (cm == null) return;

                if(SelectedBindingList.ToList().Where(a => a.CustomerId == cm.CustomerId).ToList().Count > 0)
                {
                    XtraMessageBox.Show($"{cm.CustomerName}은(는) 이미 추가하셨습니다.");
                    return;
                }
                else
                {
                    SelectedBindingList.Add(cm);
                }

            }
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            List<CustomerModel> customer = grdRight.DataSource as List<CustomerModel>;
            if (customer == null || customer.Count == 0)
            {
                XtraMessageBox.Show("수신자가 선택되지 않았습니다.");
                return;
            }

            // 발송로직
        }

        private void grdRightView_Click(object sender, EventArgs e)
        {
           
        }

        private void grdRightView_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void 선택고객전송ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerModel cm = grdRightView.GetFocusedRow() as CustomerModel;
            if (cm == null) return;            
        }
    }
    }
