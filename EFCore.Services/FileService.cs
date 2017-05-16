using EFCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using EFCore.Data.Models;
using EFCore.Repo.Interfaces;

namespace EFCore.Services
{
    public class FileService : IFileService
    {
        private IRepository<tb_File> fileRepository;
        private IUnitOfWork unitOfWork;

        public FileService(IRepository<tb_File> _fileRepo, IUnitOfWork _unitOfWork)
        {
            fileRepository = _fileRepo;
            unitOfWork = _unitOfWork;
        }

        public void Add(tb_File obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), $"{nameof(obj)} is null or empty");

            using (unitOfWork)
            {
                fileRepository.Add(obj);
                unitOfWork.Commit();
            }
        }

        public void Delete(tb_File obj)
        {
            throw new NotImplementedException();
        }

        public List<tb_File> GetAll()
        {
            throw new NotImplementedException();
        }

        public tb_File GetSingle(int pk)
        {
            throw new NotImplementedException();
        }

        public tb_File GetSingle(Guid uniqueIdentifier)
        {
            throw new NotImplementedException();
        }

        public tb_File GetSingle(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(tb_File obj)
        {
            throw new NotImplementedException();
        }
    }
}
