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

//Jessica Pereira Lins 
//August,2024

//Sets up a form for either adding a new supplier or
//modifying an existing one: it configures form controls based on the presence
//of a `Supplier` object, validates the input, and either updates the existing
//supplier in the database or inserts a new one depending on whether the `Supplier` is null or not.



namespace TravelExpertGUI
{
    public partial class AddModifySupplier : Form
    {
        public Supplier? Supplier;
        public AddModifySupplier()
        {
            InitializeComponent();
        }
        //The `AddModifySupplier_Load` method configures the form when
        //it loads based on whether a `Supplier` object is provided.
        //If `Supplier` is `null`, it hides the supplier ID text box and label,
        //and sets the "OK" button text to "Add." If a `Supplier` object is present,
        //it sets the button text to "Update," populates the supplier ID text box with the supplier's ID,
        //and fills the supplier name text box with the supplier's name.
        private void AddModifySupplier_Load(object sender, EventArgs e)
        {
            if (Supplier == null)
            {
                txtSupID.Visible = false;
                lblSupID.Visible = false;
                btnOK.Text = "Add";
            }
            else
            {
                btnOK.Text = "Update";
                txtSupID.Text = Supplier.SupplierId.ToString();
                txtSupName.Text = Supplier.SupName;
            }
        }
        //The `btnOK_Click` method validates the supplier name input, updates an existing supplier
        //or adds a new one based on whether a `Supplier` object is present, and then closes the
        //form with a dialog result of OK.
        private void btnOK_Click(object sender, EventArgs e)
        {
            var supplierName = txtSupName.Text;

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
                supplier.SupName = supplierName;
                SupplierDB.AddSupplier(supplier);
            }

            DialogResult = DialogResult.OK;
        }
    }
}
