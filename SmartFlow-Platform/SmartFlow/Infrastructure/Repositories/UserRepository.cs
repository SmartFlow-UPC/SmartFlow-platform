﻿using SmartFlow_Platform.SmartFlow.Domain.Model.Aggregates;
using SmartFlow_Platform.SmartFlow.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using SmartFlow_Platform.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace SmartFlow_Platform.SmartFlow.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetByIdAsync(int id) => await _context.Users.FindAsync(id);

    public async Task<IEnumerable<User>> GetAllAsync() => await _context.Users.ToListAsync();

    public async Task AddAsync(User user) 
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user) 
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id) 
    {
        var user = await GetByIdAsync(id);
        if (user != null) _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}
