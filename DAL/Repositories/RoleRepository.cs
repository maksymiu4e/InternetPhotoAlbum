using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(IPADbContext context) : base(context)
        {
        }
        private IPADbContext IPADbContext 
        {
            get { return _context as IPADbContext; }
        }
    }
}
