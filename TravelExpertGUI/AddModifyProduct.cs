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
//August, 2024

//The `AddModifyProduct` form allows users to either add a new product or update
//an existing one. When the form loads, it configures itself based on whether a `Product` object is
//provided: hiding the ID fields for adding and displaying them for updating. On clicking the OK
//button, it validates the product name input, then either adds a new product or updates the
//existing one using the `ProductDB` methods, and finally closes the form with a success result.

namespace TravelExpertGUI
{
    public partial class AddModifyProduct : Form
    {
        public Product? Product;
        public AddModifyProduct()
        {
            InitializeComponent();
        }
        //The `AddModifyProduct_Load` method configures the form to either add a new product
        //or update an existing one by showing or hiding controls and setting their values based
        //on the presence of a `Product` object.
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
        //The `btnOK_Click` method validates the product name input, updates an existing product
        //or adds a new one based on the presence of a `Product` object, and then closes the form
        //with a dialog result of OK.
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
