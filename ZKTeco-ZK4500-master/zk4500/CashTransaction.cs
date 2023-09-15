using FingerPrint_LT.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FingerPrint_LT
{

    public partial class CashTransaction : Form
    {
        Service service = new Service();

        public CashTransaction()
        {
            InitializeComponent();
            service.GeneralFill(cboAccountTypeID, service.GeneralSearch("SystemSubCodeID", "ID='AccountTypeID'"), "SubCodeID", "Description");
            service.GeneralFill(cboInstrumentTypeID, service.GeneralSearch("SystemSubCodeID", "ID='InstrumentTypeID'"), "SubCodeID", "Description");
            service.GeneralFill(cboTrxTypeID, service.GeneralSearch("SystemSubCodeID", "ID='TrxTypeID'"), "SubCodeID", "Description");
            txtBranchID.Text = GetOperatorID.VerificationBranchID;
            txtBranchName.Text = GetOperatorID.BranchName;
            pcAccount.Enabled = false;
            pcCurrency.Enabled = false;
        }

       

            private void txtExchangeRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void txtGainLoss_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void txtNarration_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {

        }

        private void InstrumentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnAdd.Enabled = false;
            btnView.Enabled = false;
            btnViewAll.Enabled = true;
            btnDenmination.Enabled = true;
            btnPrint.Enabled = false;
            pcBranch.Enabled = false;
            pcAccount.Enabled = true;
            pcCurrency.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            GetOperatorID.TrxBranchID = txtBranchID.Text;
            GetOperatorID.SearchID = "BranchID";
            SearchForm childForm = new SearchForm();

            childForm.PassingData += ChildFormOnPassingAccountID;
            childForm.PassingNumber += ChildFormOnPassingAccountName;

            try
            {
                childForm.ShowDialog();
            }
            finally
            {
                childForm.Dispose();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            GetOperatorID.TrxBranchID = txtBranchID.Text;
            GetOperatorID.SearchID = "AccountID";
            SearchForm childForm = new SearchForm();

            childForm.PassingData += ChildFormOnPassingAccountID;
            childForm.PassingNumber += ChildFormOnPassingAccountName;

            try
            {
                childForm.ShowDialog();
            }
            finally
            {
                childForm.Dispose();
            }


            //GetOperatorID.TrxBranchID = txtBranchID.Text;
            //GetOperatorID.SearchID = "AccountID";
            //new SearchForm().ShowDialog();
        }

        private void ChildFormOnPassingAccountID(string text)
        {
            if (GetOperatorID.SearchID == "CurrencyID")

                TrxCurrencyID.Text = string.IsNullOrWhiteSpace(text) ?
                "(empty)" :
                text;
            if (GetOperatorID.SearchID == "BranchID")
                txtBranchID.Text = string.IsNullOrWhiteSpace(text) ?
                "(empty)" :
                text;
            if (GetOperatorID.SearchID == "AccountID")
                txtAccountID.Text = string.IsNullOrWhiteSpace(text) ?
                "(empty)" :
                text;
        }
        private void ChildFormOnPassingAccountName(string text)
        {
            if (GetOperatorID.SearchID == "CurrencyID")
                TxtCurrencyName.Text = string.IsNullOrWhiteSpace(text) ?
                "(empty)" :
                text;
            if (GetOperatorID.SearchID == "BranchID")
                txtBranchName.Text = string.IsNullOrWhiteSpace(text) ?
                "(empty)" :
                text;
            if (GetOperatorID.SearchID == "AccountID")
            {
                txtAccountName.Text = string.IsNullOrWhiteSpace(text) ?
                "(empty)" :
                text;

                GetOperatorID.TrxBranchID = txtBranchID.Text;
                GetOperatorID.AccountID = txtAccountID.Text;
                GetOperatorID.TrxTypeID = cboTrxTypeID.SelectedValue.ToString();
                GetOperatorID.CurrencyID = string.IsNullOrWhiteSpace(TrxCurrencyID.Text) ? "UGX" : TrxCurrencyID.Text;

                var lookup = service.FetchTrxAcDetails().ToList() ;
                txtNarration.Text = lookup[0].ToString();

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GetOperatorID.TrxBranchID = txtBranchID.Text;
            GetOperatorID.SearchID = "CurrencyID";
            SearchForm childForm = new SearchForm();

            childForm.PassingData += ChildFormOnPassingAccountID;
            childForm.PassingNumber += ChildFormOnPassingAccountName;

            try
            {
                childForm.ShowDialog();
            }
            finally
            {
                childForm.Dispose();
            }
        }
    }
}
