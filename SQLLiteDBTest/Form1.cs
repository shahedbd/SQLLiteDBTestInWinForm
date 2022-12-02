using SQLLiteDBTest.Data;
using SQLLiteDBTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SQLLiteDBTest
{
    public partial class Form1 : Form
    {
        private AppDBContext _context;

        public Form1()
        {
            InitializeComponent();
            _context = new AppDBContext();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var _GetCategory = GetAllCategory();
            Category _Category = new()
            {
                CategoryName = "Time: " + DateTime.Now.ToLongTimeString()
            };
            var result = AddCategory(_Category);

            Category _Category2 = new()
            {
                CategoryID = 2,
                CategoryName = "Updated Record at " + DateTime.Now,
            };
            var _UpdateCategory = UpdateCategory(_Category2);
            //var _DeleteProduct = DeleteProduct(1);
        }

        private List<Category> GetAllCategory()
        {
            var result = _context.Category.ToList();
            return result;
        }
        private Category GetByCategory(Int64 id)
        {
            var result = _context.Category.Where(x => x.CategoryID == id).SingleOrDefault();
            return result;
        }
        private Category AddCategory(Category _Category)
        {
            _context.Category.Add(_Category);
            _context.SaveChanges();

            return _Category;
        }

        private Category UpdateCategory(Category _Category)
        {
            var _GetByCategory = GetByCategory(_Category.CategoryID);
            _context.Entry(_GetByCategory).CurrentValues.SetValues(_Category);
            //_context.Category.Update(_Category);
            _context.SaveChanges();

            return _Category;
        }

        private Category DeleteCategory(Int64 id)
        {
            var _Category = _context.Category.Where(x => x.CategoryID == id).SingleOrDefault();
            _context.Category.Remove(_Category);
             _context.SaveChanges();

            return _Category;
        }

        private Category DeleteCategory2(Int64 id)
        {
            Category _Category;
            using (var context = new AppDBContext())
            {
                _Category = context.Category.Where(x => x.CategoryID == id).SingleOrDefault();
                context.Category.Remove(_Category);
                context.SaveChanges();
            }

            return _Category;
        }
    }
}
