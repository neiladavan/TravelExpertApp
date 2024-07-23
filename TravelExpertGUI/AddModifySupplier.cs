using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TravelExpertData;

namespace TravelExpertGUI
{
    public partial class AddModifySupplier : Form
    {
        public Supplier? Supplier;
        public AddModifySupplier()
        {
            InitializeComponent();
        }
        private void AddModifySupplier_Load(object sender, EventArgs e)
        {
            if (Supplier == null)
            {
                txtSupID.ReadOnly = false;
                btnOK.Text = "Add";
            }
            else
            {
                btnOK.Text = "Update";
                txtSupID.Text = Supplier.SupplierId.ToString();
                txtSupName.Text = Supplier.SupName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var supplierID = txtSupID.Text;
            var supplierName = txtSupName.Text;

            if (supplierID.IsNullOrEmpty())
            {
                MessageBox.Show("Supplier ID can not be empty");
                return;
            }

            try
            {
                if (int.Parse(supplierID) <= 0)
                {
                    MessageBox.Show("Supplier ID must be greater than 0");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Supplier ID must be a number");
                return;
            }

            if (supplierName.IsNullOrEmpty())
            {
                MessageBox.Show("Supplier name can not be empty");
                return;
            }

            if (Supplier != null)
            {
                Supplier.SupName = supplierName;
                SupplierDB.ModifySupplier(Supplier);
            }
            else
            {
                var supplier = new Supplier();
                supplier.SupplierId = int.Parse(supplierID);
                supplier.SupName = supplierName;
                try
                {
                    SupplierDB.AddSupplier(supplier);
                }
                catch
                {
                    MessageBox.Show("Supplier ID already exists. Please choose a different one");
                    return;
                }
            }

            DialogResult = DialogResult.OK;
        }
    }
}
