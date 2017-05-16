using EFCore.Data.Models;
using EFCore.Repo.Interfaces;
using EFCore.Services.Cryptography.Hashing;
using EFCore.Services.Interfaces;
using EFCore.Services.Interfaces.Cryptography.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCore.Services
{
    public class UserService : IUserService
    {
        private IRepository<tb_User> userRepository;
        private IRepository<tb_File> fileRepository;
        private IUnitOfWork unitOfWork;

        public UserService(IRepository<tb_User> _userRepo, IRepository<tb_File> _fileRepo , IUnitOfWork _unitOfWork)
        {
            userRepository = _userRepo;
            fileRepository = _fileRepo;
            unitOfWork = _unitOfWork;
        }

        public void Add(tb_User obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), $"{nameof(obj)} is null or empty");

            using (unitOfWork)
            {
                userRepository.Add(obj);
                unitOfWork.Commit();
            }
            
        }

        public void Add(tb_User user, tb_File userPhoto)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), $"{nameof(user)} is null or empty");

            using (unitOfWork)
            {
                try
                {
                    userRepository.Add(user);
                    fileRepository.Add(userPhoto);

                    unitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }
        }

        public void Delete(tb_User obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), $"{nameof(obj)} is null or empty");

            using (unitOfWork)
            {
                userRepository.Remove(obj);
                unitOfWork.Commit();
            }
        }

        public List<tb_User> GetAll()
        {
            return userRepository.GetAll().ToList();
        }

        public tb_User GetSingle(string name)
        {
            if (name == null || name == string.Empty)
                throw new ArgumentNullException(nameof(name), $"{nameof(name)} is null or empty");

            return userRepository.GetSingle(x => x.usr_Firstname.Contains(name) || x.usr_LastName.Contains(name));
        }

        public tb_User GetSingle(int pk)
        {
            if (pk > 0)
                throw new ArgumentNullException(nameof(pk), $"{nameof(pk)} is not valid");

            return userRepository.GetSingle(x => x.usr_Pk == pk);
        }

        public tb_User GetSingle(Guid uniqueIdentifier)
        {
            return userRepository.GetSingle(x => x.usr_Guid == uniqueIdentifier);
        }

        public void Update(tb_User obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), $"{nameof(obj)} is null or empty");

            using (unitOfWork)
            {
                userRepository.Update(obj);
                unitOfWork.Commit();
            }
        }
    }
}
