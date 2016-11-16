using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Models;
using Outsourcing.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Outsourcing.Service
{
    public interface IAccountService
    {
        #region [basic Method]
        /// <summary>
        /// 
        /// </summary>
        IEnumerable<Account> GetAllAccounts();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Account GetAccountById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        void AddAccount(Account user);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        void EditAccount(Account user);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        void DeleteAccount(Account user);
        #endregion

    }

    public class AccountService : IAccountService
    {
        #region[Fields]
        private readonly IAccountRepository _accountRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region [Ctor]
        public AccountService(IAccountRepository _accountRepository, IUnitOfWork _unitOfWork)
        {
            this._accountRepository = _accountRepository;
            this._unitOfWork = _unitOfWork;
        }
        #endregion

        public IEnumerable<Account> GetAllAccounts()
        {
            return _accountRepository.GetAll().Where(p=>p.isDelete == false);
        }

        public Account GetAccountById(int id)
        {
            var obj = _accountRepository.Get(c => c.Id == id && c.isDelete == false);
            //var obj = _accountRepository.GetAll().Where(p=>p.Id==id).FirstOrDefault();
            //var obj = _accountRepository.GetById(id);
            //var obj = _accountRepository.GetMany(p => p.Id == id).FirstOrDefault();
            return obj;
        }

        public void AddAccount(Account obj)
        {
            _accountRepository.Add(obj);
            _unitOfWork.Commit();
        }

        public void EditAccount(Account user)
        {
            _accountRepository.Update(user);
            _unitOfWork.Commit();
        }

        public void DeleteAccount(Account user)
        {
            _accountRepository.Delete(user); //xoa luon ca record trong db


            //vendor.note = "true";
            //EditVendor(vendor);

            //user.Note = "true";
            //_userRepository.Update(vendor);
            //_unitOfWork.Commit();
        }
    }
}
