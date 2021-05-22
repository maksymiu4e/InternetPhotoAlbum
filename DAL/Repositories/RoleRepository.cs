using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Role GetRoleByUserLogin(string login)
        {
            var roleId = IPADbContext.Users.Where(x => x.Login == login).Select(c => c.RoleId).FirstOrDefault();
            return (Role)IPADbContext.Roles.Where(v => v.Id == roleId);
        }
    }
}
