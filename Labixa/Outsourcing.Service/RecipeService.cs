using Outsourcing.Data.Infrastructure;
using Outsourcing.Data.Models;
using Outsourcing.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outsourcing.Data.Repository;

namespace Outsourcing.Service
{
    public interface IRecipeService
    {
        #region [basic Method]
        /// <summary>
        /// 
        /// </summary>
        IEnumerable<Recipe> GetAllRecipes();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return a Recipe</returns>
        Recipe GetRecipeById(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Recipe"></param>
        void AddRecipe(Recipe Recipe);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Recipe"></param>
        void EditRecipe(Recipe Recipe);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Recipe"></param>
        void DeleteRecipe(Recipe Recipe);
        #endregion

    }

    public class RecipeService : IRecipeService
    {
        #region[Fields]
        private readonly IRecipeRepository _RecipeRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion

        #region [Ctor]
        public RecipeService(IRecipeRepository _RecipeRepository, IUnitOfWork _unitOfWork)
        {
            this._RecipeRepository = _RecipeRepository;
            this._unitOfWork = _unitOfWork;
        }
        #endregion

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _RecipeRepository.GetAll().Where(p=>p.isDelete == false);
        }


        public Recipe GetRecipeById(int id)
        {
            var obj = _RecipeRepository.Get(c => c.Id == id);
            //var obj = _RecipeRepository.GetAll().Where(p=>p.Id==id).FirstOrDefault();
            //var obj = _RecipeRepository.GetById(id);
            //var obj = _RecipeRepository.GetMany(p => p.Id == id).FirstOrDefault();
            return obj;
        }

        public void AddRecipe(Recipe Recipe)
        {
            //Recipe.Note = "0";
            Recipe.isDelete = false;
            _RecipeRepository.Add(Recipe);
            _unitOfWork.Commit();
        }

        public void EditRecipe(Recipe Recipe)
        {
           
            //Recipe.isDelete = false;
            _RecipeRepository.Update(Recipe);
            _unitOfWork.Commit();
        }

        public void DeleteRecipe(Recipe Recipe)
        {
            //Recipe.Note = "1";
            Recipe.isDelete = true;
            _RecipeRepository.Update(Recipe);
            _unitOfWork.Commit();
        }
    }
}
