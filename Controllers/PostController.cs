using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostAndComment.CoreLayer.Src.DataTransferObject;
using PostAndComment.CoreLayer.Src.Repository;
using PostAndComment.CoreLayer.Src.Service;
using PostAndReaction.Models;

namespace PostAndReaction.Controllers
{
    public class PostController : Controller
    {
        private readonly UserRepositoryInterface _userRepositoryInterface;
        private readonly PostServiceInterface _postServiceInterface;

        public PostController(UserRepositoryInterface userRepositoryInterface, PostServiceInterface postServiceInterface)
        {
            _userRepositoryInterface = userRepositoryInterface;
            _postServiceInterface = postServiceInterface;
        }

        // GET: PostController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(PostModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createDto=new PostDto();
                    var user = _userRepositoryInterface.GetQueryable().FirstOrDefault();
                    createDto.CreatedById = user.Id;
                    createDto.Title = model.Title;
                    createDto.Description = model.Description;
                    createDto.image = model.Image;
                    await _postServiceInterface.Create(createDto);
                }
                return RedirectToAction(nameof(Index), "Home");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
