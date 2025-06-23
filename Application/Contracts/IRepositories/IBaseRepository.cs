﻿using System.Linq.Expressions;

namespace Application.Contracts.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter, string? includePropeties = null);
        Task<List<T>> GetAllAsync(string? includePropeties = null);
        Task<T?> GetAsync(Expression<Func<T, bool>> filter, string? includePropeties = null);
        Task AddAsync(T entity);
        void Remove(T entity);
    }
}
