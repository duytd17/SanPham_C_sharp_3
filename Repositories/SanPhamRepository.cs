using Project_Template_SM22_Csharp.Context;
using Project_Template_SM22_Csharp.DomainClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Template_SM22_Csharp.Repositories
{
    public class SanPhamRepository
    {
        private FpolyDBContext _dbContext;

        public SanPhamRepository()
        {
            _dbContext = new FpolyDBContext();
        }

        public List<SanPham> GetAll()
        {
            return _dbContext.SanPhams.ToList();
        }

        public bool AddSP(SanPham obj)
        {
            if(obj == null) return false;
            _dbContext.SanPhams.Add(obj);
            _dbContext.SaveChanges();
            return true;
        }

        public bool DeleteSP(SanPham obj)
        {
            if (obj == null) return false;
            _dbContext.SanPhams.Remove(obj);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
