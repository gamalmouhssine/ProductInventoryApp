using ProductInventoryApp.Data.Repositories;
using ProductInventoryApp.Models;
using ProductInventoryApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProductInventoryApp
{
    public partial class Form1: Form
    {
        private readonly IProductService _productService;
       
        public Form1()
        {
            InitializeComponent();
            _productService = new ProductService(new ProductRepository());
            LoadProducts();
        }
        private void LoadProducts()
        {
            var products = _productService.GetAllProducts();
            dataGridView1.DataSource = products;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string quantityText = txtQuantity.Text.Trim();
            string priceText = txtPrice.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Product name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(quantityText, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Quantity must be a valid non-negative integer Or String.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price) || price < 0)
            {
                MessageBox.Show("Price must be a valid non-negative decimal number Or String.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var product = new Product
                {
                    Name = name,
                    Quantity = quantity,
                    Price = price
                };

                _productService.AddProduct(product);
                LoadProducts();
                ClearInputs();

                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while adding the product:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearInputs()
        {
            txtName.Text = txtQuantity.Text = txtPrice.Text = string.Empty;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Please enter a product name to search.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var result = _productService.Search(searchText);
            dataGridView1.DataSource = result;

            if (result.Count == 0)
            {
                MessageBox.Show("No products found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
