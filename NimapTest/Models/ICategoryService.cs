﻿using System.Collections.Generic;
using NimapTest.Models;

namespace NimapTest.Services
{
    public interface ICategoryService
    {
        List<Category> GetCategories(int page, int pageSize);
        Category GetCategoryById(int id);
        void AddCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);
        int GetTotalCategoryCount();
    }
}
