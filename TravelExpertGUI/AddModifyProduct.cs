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
    public partial class AddModifyProduct : Form
    {
        public Product? Product;
        public AddModifyProduct()
        {
            InitializeComponent();
        }

        private void AddModifyProduct_Load(object sender, EventArgs e)
        {
            if (Product == null)
            {
                lblID.Visible = false;
                txtID.Visible = false;

                btnOK.Text = "Add";
            }
            else
            {
                btnOK.Text = "Update";
                txtID.Text = Product.ProductId.ToString();
                txtProdName.Text = Product.ProdName;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var productName = txtProdName.Text;
            if (productName.IsNullOrEmpty())
            {
                MessageBox.Show("Product name can not be empty");
                return;
            }

            if (Product != null)
            {
                Product.ProdName = productName;
                ProductDB.ModifyProduct(Product);
            }
            else
            {
                var product = new Product();
                product.ProdName = productName;
                ProductDB.AddProduct(product);
            }

            DialogResult = DialogResult.OK;
        }
    }
}
