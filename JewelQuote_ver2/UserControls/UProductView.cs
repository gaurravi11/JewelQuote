using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceLayer.Masters;
using ModelLayer.Product;
using AccessDBLayer.Product;
using ModelLayer.Masters;
using AccessDBLayer.Masters;
using JewelQuote.Product;

namespace JewelQuote.UserControls
{
    public partial class UProductView : UserControl
    {
        IProductRepository _productRepository;
        IProductTypeRepository _productTypeRepository;
        Int32 ProdId = 0;
        public UProductView(Int32 ProductId)
        {
            InitializeComponent();
            _productRepository = new LocalProductRepository();
            _productTypeRepository = new LocalProductTypeRepository();
            
            ProdId = ProductId;
            ProductModel product = _productRepository.GetProduct(ProductId);
            if (product.ImagePath != "")
            {
                ProductTypeModel productType = _productTypeRepository.GetProductType(product.TypeId);
                string sourcePath = "";
                if (productType != null && productType.FolderLocation != "")
                {
                    sourcePath = productType.FolderLocation;
                }
                if (System.IO.Directory.Exists(sourcePath))
                {
                    using (var img = new Bitmap(sourcePath + product.ImagePath))
                    {
                        pictureBox1.Image = new Bitmap(img);
                    }
                }
            }
            lblProductCode.Text = product.ProductCode;
        }
        private void UProductView_Load(object sender, EventArgs e)
        {

        }

        private void btnView_Click(object sender, EventArgs e)
        {
            FormUpdateProduct frm = new FormUpdateProduct(ProdId);
            frm.ShowDialog();
            ProductModel product = _productRepository.GetProduct(ProdId);
            if (product.ImagePath != "")
            {
                ProductTypeModel productType = _productTypeRepository.GetProductType(product.TypeId);
                string sourcePath = "";
                if (productType != null && productType.FolderLocation != "")
                {
                    sourcePath = productType.FolderLocation;
                }
                if (System.IO.Directory.Exists(sourcePath))
                {
                    using (var img = new Bitmap(sourcePath + product.ImagePath))
                    {
                        pictureBox1.Image = new Bitmap(img);
                    }
                }
            }
            lblProductCode.Text = product.ProductCode;
        }
    }
}
