using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outsourcing.Data.Models;
using Outsourcing.Data.Repository;
using Outsourcing.Data.Infrastructure;

namespace Outsourcing.Service
{
    public interface ICollectionService
    {
        #region [basic Method]
        /// <summary>
        /// 
        /// </summary>
        IEnumerable<Collection> GetAllCollections();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return a CollectionCategory</returns>
        Collection GetCollectionById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CollectionCategory"></param>
        void AddCollection(Collection Collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Collection"></param>
        void EditCollection(Collection Collection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Collection"></param>
        void DeleteCollection(Collection Collection);
        #endregion

    }
    public class CollectionService : ICollectionService
    {
        #region[Fields]
        private readonly ICollectionRepository _CollectionRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region [Ctor]
        public CollectionService(ICollectionRepository _CollectionRepository, IUnitOfWork _unitOfWork)
        {
            this._CollectionRepository = _CollectionRepository;
            this._unitOfWork = _unitOfWork;
        }
        #endregion
        public Collection GetCollectionById(int id)
        {
            var obj = _CollectionRepository.Get(c => c.Id == id);
            //var obj = _CollectionRepository.GetAll().Where(p=>p.Id==id).FirstOrDefault();
            //var obj = _CollectionRepository.GetById(id);
            //var obj = _CollectionRepository.GetMany(p => p.Id == id).FirstOrDefault();
            return obj;
        }

        public void AddCollection(Collection Collection)
        {
            
            Collection.isDelete = false;         
            _CollectionRepository.Add(Collection);         
            _unitOfWork.Commit();
        }

        public void EditCollection(Collection Collection)
        {

            //Collection.isDelete = false;
            _CollectionRepository.Update(Collection);
            _unitOfWork.Commit();
        }

        public void DeleteCollection(Collection Collection)
        {
            //_CollectionRepository.Delete(Collection); //xoa luon ca record trong db 1 delete 0 available


            //Collection.note = "true";
            //EditCollection(Collection);

            
            Collection.isDelete = true;
            _CollectionRepository.Update(Collection);
            _unitOfWork.Commit();
        }

        public IEnumerable<Collection> GetAllCollections()
        {
            return _CollectionRepository.GetAll().Where(p=>p.isDelete == false);
        }
    }
}
