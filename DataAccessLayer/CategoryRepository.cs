using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;


namespace DataAccessLayer
{
    public class CategoryRepository
    {
        private List<CategoryModel> _categories;

        public CategoryRepository(){
            buildCategories();
        }

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns>The categories.</returns>
        public List<CategoryModel> GetCategories(){
            return this._categories;
        }

        public CategoryModel GetCategoryById(int Id) => this._categories.FirstOrDefault(x => x.CategoryId == Id);

        /// <summary>
        /// Allows to populate the categories List, this data will ideally come from a DB
        /// </summary>
        private void buildCategories(){
            _categories = new List<CategoryModel>() {
                new CategoryModel() { CategoryId=100, ParentCategoryId=-1, Name="Business", Keywords="Money" },
                new CategoryModel() { CategoryId=200, ParentCategoryId=-1, Name="Tutoring", Keywords="Teaching" },
                new CategoryModel() { CategoryId=101, ParentCategoryId=100, Name="Accounting", Keywords="Taxes" },
                new CategoryModel() { CategoryId=102, ParentCategoryId=100, Name="Taxation", Keywords="" },
                new CategoryModel() { CategoryId=201, ParentCategoryId=200, Name="Computer", Keywords="" },
                new CategoryModel() { CategoryId=103, ParentCategoryId=101, Name="Corporate Tax", Keywords="" },
                new CategoryModel() { CategoryId=202, ParentCategoryId=201, Name="Operating System", Keywords="" },
                new CategoryModel() { CategoryId=109, ParentCategoryId=101, Name="Small bussiness Tax", Keywords="" },
            };
        }
    }
}
