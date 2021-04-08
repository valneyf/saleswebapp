﻿using System;
using System.Collections.Generic;
using System.Linq;
using SalesWebApp.Data;
using SalesWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace SalesWebApp.Services {
    public class SellerService {
        private readonly SalesWebAppContext _context;

        public SellerService(SalesWebAppContext context) {
            _context = context;
        }

        public List<Seller> FindAll() {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj) {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id) {
            return _context.Seller.Include(obj =>obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id) {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}