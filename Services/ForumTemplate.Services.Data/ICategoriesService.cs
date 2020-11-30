﻿namespace ForumTemplate.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoriesService
    {
         IEnumerable<T> GetAll<T>(int? count = null);
    }
}