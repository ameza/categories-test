using System;

namespace DataAccess
{
    public class CategoryModel
    {
        public int CategoryId
        {
            get;
            set;
        }

        public int ParentCategoryId
        {
            get;
            set;
        }
 
        public string Name
        {
            get;
            set;
        }

        public string Keywords
        {
            get;
            set;
        }


        public override string ToString() => String.Format("Category Id: {0} | Parent Category Id: {1} | Name: {2} | Keywords: {3} ", CategoryId, ParentCategoryId, Name, Keywords);
    }
}
