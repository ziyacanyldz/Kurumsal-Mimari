using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _ıCategoryDal;
        public CategoryManager(ICategoryDal ıCategoryDal)
        {
            _ıCategoryDal = ıCategoryDal;
        }
        public List<Category> GetAll()
        {
            return _ıCategoryDal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _ıCategoryDal.Get(p => p.CategoryId == categoryId);
        }
    }
}
