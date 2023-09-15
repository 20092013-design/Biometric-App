using FingerPrint_LT.Services;
using System;
using System.Windows.Forms;

namespace FingerPrint_LT
{
    public partial class SearchForm : Form
    {
        Service service = new Service();
        public delegate void OnPassingText(string text);
        public event OnPassingText PassingData;

        public delegate void OnPassingNumber(string value);
        public event OnPassingNumber PassingNumber;
        public SearchForm()
        {
            InitializeComponent();

            string WhereStmt = "";
            string AdvFilter = "";

            if (GetOperatorID.SearchID == "AccountID")
                AdvFilter = "OurBranchID = '" + GetOperatorID.TrxBranchID + "'";
              


            service.Search(gdSearchForm, WhereStmt, GetOperatorID.SearchID, AdvFilter);

            //ComboboxItem item= new ComboboxItem();
            //item.Text = "Account ID";
            //item.Value = "AccountID";
            //item.Text = "Currency ID";
            //item.Value = "CurrencyID";
            //item.Text = "Branch ID";
            //item.Value = "BranchID";
            //cboSearchID.Items.Add(item);
        }


        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {

        }

        private void txtSearchValue_KeyDown(object sender, KeyEventArgs e)
        {
            string WhereStmt = "";
            string AdvFilter = "";
            if (txtSearchValue.Text.Length > 2)
            {
                if (GetOperatorID.SearchID == "AccountID")
                {
                    WhereStmt = "Name Like '%" + txtSearchValue.Text + "%'";
                    AdvFilter = "OurBranchID = '" + GetOperatorID.TrxBranchID + "'";
                }
                else if (GetOperatorID.SearchID == "CurrencyID")
                    WhereStmt = "Description Like '%" + txtSearchValue.Text + "%'";
                else if (GetOperatorID.SearchID == "BranchID")

                    WhereStmt = "BranchName Like '%" + txtSearchValue.Text + "%'";

                service.Search(gdSearchForm, WhereStmt, GetOperatorID.SearchID, AdvFilter);
            }
        }

        private void gdSearchForm_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gdSearchForm.SelectedCells.Count > 0)
                {
                    int selectedrowindex = e.RowIndex;

                    gdSearchForm.Rows[selectedrowindex].Selected = true;

                    DataGridViewRow selectedRow = gdSearchForm.Rows[selectedrowindex];
                    if (GetOperatorID.SearchID == "AccountID")
                    {
                        PassingData?.Invoke(Convert.ToString(selectedRow.Cells["AccountID"].Value));
                        PassingNumber?.Invoke(Convert.ToString(selectedRow.Cells["Name"].Value));
                        //GetOperatorID.ResultID = Convert.ToString(selectedRow.Cells["AccountID"].Value);
                        //GetOperatorID.ResultValue = Convert.ToString(selectedRow.Cells["Name"].Value);
                        //new CashTransaction(GetOperatorID.ResultID, GetOperatorID.ResultValue).Refresh();
                        this.Close();

                    }
                    else if (GetOperatorID.SearchID == "CurrencyID")
                    {
                        PassingData?.Invoke(Convert.ToString(selectedRow.Cells["CurrencyID"].Value));
                        PassingNumber?.Invoke(Convert.ToString(selectedRow.Cells["Description"].Value));
                        this.Close();
                    }
                    else if (GetOperatorID.SearchID == "BranchID")
                    {
                        PassingData?.Invoke(Convert.ToString(selectedRow.Cells["OurBranchID"].Value));
                        PassingNumber?.Invoke(Convert.ToString(selectedRow.Cells["BranchName"].Value));
                        this.Close();
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
