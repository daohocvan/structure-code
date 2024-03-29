﻿using Structure.Domain.Abstractions;

namespace Structure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
            => _context = context;

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
            => await _context.SaveChangesAsync(cancellationToken);


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}