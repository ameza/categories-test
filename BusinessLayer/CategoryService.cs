using System;
using DataAccess;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class CategoryService
    {
        private CategoryRepository _categoryRepository;

        public CategoryService(){
            _categoryRepository = new CategoryRepository();
        }

        public List<CategoryModel> GetCategories(){
            return _categoryRepository.GetCategories();
        }

        private CategoryModel getCategoryById(int Id){
            return _categoryRepository.GetCategoryById(Id);
        }

        public CategoryModel FindCategoryKeywords(int Id){
            
            var categories = GetCategories();

            var foundCategory = getCategoryById(Id);

            if (foundCategory.Keywords!=String.Empty){
                //the category already has keywords let's return it
                return foundCategory;
            }
            else {
                //check the parents for keywords
                var parent = FindParentCategory(categories, foundCategory);

                if (parent != null)
                {
                    //reassing keywords from the parent
                    foundCategory.Keywords = parent.Keywords;
                    return foundCategory;
                }
                else {
                    throw new Exception("Unable to find keywords for the given category");
                }
            }
        }

        /// <summary>
        /// Look for the parents until a parent with keywords shows up
        /// </summary>
        /// <returns>The parent category.</returns>
        /// <param name="categories">Categories.</param>
        /// <param name="child">Child.</param>
        public CategoryModel FindParentCategory(List<CategoryModel> categories, CategoryModel child)
        {
            var parent = getCategoryById(child.ParentCategoryId); 
                
            if (parent == null || parent.Keywords != String.Empty)
                return  parent ;     

            return FindParentCategory(categories, parent);
        }


        public List<CategoryModel> GetCategoriesByLevel(int level){

            if (level<1){
                throw new Exception("Level must be greater than 0");
            }
            var levelCategories = new List<CategoryModel>();
            var categories = GetCategories();
            level--;
            foreach(var item in categories){
                var totalParents = CountAllParents(categories, item);
                if (totalParents == level){
                    levelCategories.Add(item);
                }
            }

            return levelCategories;
        }

        private int CountAllParents(List<CategoryModel> all_data, CategoryModel child)
        {
            var parent = all_data.FirstOrDefault(x => x.CategoryId == child.ParentCategoryId);

            if (parent == null)
                return 0;

            return 1 + CountAllParents(all_data, parent);
        }
    }
}
