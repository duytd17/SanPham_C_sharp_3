using Project_Template_SM22_Csharp.DomainClass;
using Project_Template_SM22_Csharp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Template_SM22_Csharp.Services
{
    public class SanPhamService
    {
        private SanPhamRepository _spRepository;
        List<SanPham> _spList;

        public SanPhamService()
        {
            _spRepository = new SanPhamRepository();
            _spList = new List<SanPham>();
            GetValue();
        }

        public void GetValue()
        {
            _spList = _spRepository.GetAll();
        }

        public List<SanPham> GetSanPham()
        {
            return _spList;
        }

        public List<SanPham> GetSanPham(SanPham obj)
        {
            if(obj == null) return GetSanPham();
            return _spRepository.GetAll().Where(c => c.Ma == obj.Ma).ToList() ;
        }


        public string AddSP(SanPham obj)
        {
            if (_spRepository.AddSP(obj))
            {
                GetValue();
                return "Them thanh cong!";

            }

            return "Them khong thanh cong!";

        }

        public string DeleteSP(SanPham obj)
        {
            var SP = _spRepository.GetAll().FirstOrDefault(c => c.Ma == obj.Ma);
            if (_spRepository.DeleteSP(SP))
            {
                GetValue();
                return "Xoa thanh cong!";
            }
            return "Xoa khong thanh cong!";

        }
    }
}
