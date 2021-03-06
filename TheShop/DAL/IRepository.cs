﻿using System.Collections.Generic;

namespace TheShop
{
    public interface IRepository<T>
    {
        T GetById(int id);

        IList<T> GetAll();

        void Remove(T entity);

        void Save(T entity);
    }
}