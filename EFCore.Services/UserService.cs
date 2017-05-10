using EFCore.Data.Models;
using EFCore.Repo.Interfaces;
using EFCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Services
{
    public class UserService : IUserService
    {
        private IRepository<tb_User> userRepository;

        public UserService(IRepository<tb_User> _userRepo)
        {
            userRepository = _userRepo;

        }

        public void Add(tb_User obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(tb_User obj)
        {
            throw new NotImplementedException();
        }

        public List<tb_User> GetAll()
        {
            throw new NotImplementedException();
        }

        public tb_User GetSingle(string name)
        {
            throw new NotImplementedException();
        }

        public tb_User GetSingle(int pk)
        {
            throw new NotImplementedException();
        }

        public tb_User GetSingle(Guid uniqueIdentifier)
        {
            throw new NotImplementedException();
        }

        public void Update(tb_User obj)
        {
            throw new NotImplementedException();
        }
    }
}
