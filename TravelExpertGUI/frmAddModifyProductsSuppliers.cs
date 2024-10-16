﻿using System.Xml.Linq;
using TravelExpertData;
// Author: Mackenzie Whitney
namespace TravelExpertGUI
{
    public partial class frmAddModifyProductsSuppliers : Form
    {
        List<Product> products = new List<Product>();
        List<Supplier> suppliers = new List<Supplier>();

        public frmAddModifyProductsSuppliers()
        {
            InitializeComponent();
        }

        public ProductsSupplier ProductsSupplier { get; set; } = null!;
        private void frmAddModifyProductsSuppliers_Load(object sender, EventArgs e)
        {
            products = ProductDB.GetProducts();
            cboProduct.DataSource = products;
            cboProduct.DisplayMember = "ProdName";
            cboProduct.ValueMember = "ProductId";

            suppliers = SupplierDB.GetSuppliers();
            cboSupplier.DataSource = suppliers;
            cboSupplier.DisplayMember = "SupName";
            cboSupplier.ValueMember = "SupplierId";

            if (ProductsSupplier == null)
            {
                Text = "Add Products Supplier";
                ProductsSupplier = new ProductsSupplier();
            }
            else
            {
                Text = "Modify Products Supplier";
                cboProduct.SelectedValue = ProductsSupplier.ProductId;
                cboSupplier.SelectedValue = ProductsSupplier.SupplierId;

            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (validateProductSuppliers())
            {
                ProductsSupplier.ProductId = Int32.Parse(cboProduct.SelectedValue.ToString());
                ProductsSupplier.SupplierId = Int32.Parse(cboSupplier.SelectedValue.ToString());
                DialogResult = DialogResult.OK;
            }
        }


        /* if dropdowns are made to be not read only, we would need to validate the selections
        */
        private bool validateProductSuppliers()
        {
            if(cboProduct.SelectedValue == null || cboSupplier.SelectedValue == null) { return false; }
            return true;
        }
    }
}
