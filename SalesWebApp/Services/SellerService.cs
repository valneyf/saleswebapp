﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebApp.Data;
using SalesWebApp.Models;

namespace SalesWebApp.Services {
    public class SellerService {
        private readonly SalesWebAppContext _context;

        public SellerService(SalesWebAppContext context) {
            _context = context;
        }

        public List<Seller> FindAll() {
            return _context.Seller.ToList();
        }
    }
}
