using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebApp.Data;
using SalesWebApp.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebApp.Services.Exceptions;
using System.Threading.Tasks;

namespace SalesWebApp.Services {
    public class SellerService {
        private readonly SalesWebAppContext _context;

        public SellerService(SalesWebAppContext context) {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync() {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertAsync(Seller obj) {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id) {
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task RemoveAsync(int id) {
            try {
                var obj = _context.Seller.Find(id);
                _context.Seller.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e) {
                throw new IntegrityException("Can't delete seller because he/she has sales");
            }
        }
        public async Task UpdateAsync(Seller obj) {
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);

            if (!hasAny) {
                throw new NotFoundException("Id not found");
            }

            try {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbConcurrencyException e) {

                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
