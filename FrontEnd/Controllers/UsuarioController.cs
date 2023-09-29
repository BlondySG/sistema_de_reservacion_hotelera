using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class UsuarioController : Controller
    {


        #region Constructor
        UsuarioHelper _usuarioHelper;
        RolHelper _rolHelper;

        public UsuarioController()
        {
            _usuarioHelper = new UsuarioHelper();
            _rolHelper = new RolHelper();

        }
        #endregion


        #region Obtiene Rol
        private RolViewModel GetRol(int id)
        {
            try
            {
                RolViewModel rolViewModel = _rolHelper.Details(id);

                return rolViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Obtiene Lista Roles
        private List<RolViewModel> GetRoles()
        {
            List<RolViewModel> rolViewModel = _rolHelper.GetAll();

            return rolViewModel;

        }
        #endregion

        #region Create
        // GET: TbArticulosController/Create
        public ActionResult Create()
        {
            try
            {
                UsuarioViewModel rol = new UsuarioViewModel { };
                rol.Roles = this.GetRoles();

                return View(rol);

            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: TbArticulosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioViewModel usuario)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Usuario", usuario);
                response.EnsureSuccessStatusCode();
                UsuarioViewModel usuarioViewModel = response.Content.ReadAsAsync<UsuarioViewModel>().Result;
                return RedirectToAction("Details", new { id = usuarioViewModel.Idusuario });
            }
            catch (HttpRequestException
          )
            {
                return RedirectToAction("Error", "Home");
            }

            catch (Exception
            )
            {

                throw;
            }
        }
        #endregion

        #region Read
        // GET: TbArticulosController
        public ActionResult Index()
        {
            try
            {
                List<UsuarioViewModel> usuarios = _usuarioHelper.GetAll();

                foreach (var item in usuarios)
                {
                    item.Rol = _rolHelper.Details(item.Idrol);
                }
                return View(usuarios);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: TbArticulosController/Details/5
        public ActionResult Details(int id)
        {
            UsuarioViewModel usuarioViewModel = _usuarioHelper.Details(id);

            return View(usuarioViewModel);

        }
        #endregion

        #region Update
        // GET: TbArticulosController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                UsuarioViewModel usuarioViewModel = _usuarioHelper.Edit(id);
                return View(usuarioViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbArticulosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioViewModel usuario)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/Usuario", usuario);
                response.EnsureSuccessStatusCode();
                UsuarioViewModel usuarioViewModel = response.Content.ReadAsAsync<UsuarioViewModel>().Result;
                return RedirectToAction("Details", new { id = usuarioViewModel.Idusuario });
            }
            catch
            {
                return View();
            }
        }
        #endregion

        #region Delete
        // GET: TbArticulosController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                UsuarioViewModel usuarioViewModel = _usuarioHelper.Delete(id);
                return View(usuarioViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbArticulosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UsuarioViewModel usuario)
        {
            try
            {
                int id = usuario.Idusuario;
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Usuario/" + id.ToString());
                response.EnsureSuccessStatusCode();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        //public IActionResult Index()
        //{
        //    try
        //    {
        //        ServiceRepository Repository = new ServiceRepository();
        //        HttpResponseMessage response = Repository.GetResponse("api/usuario/");

        //        response.EnsureSuccessStatusCode();

        //        var content = response.Content.ReadAsStringAsync().Result;

        //        List<UsuarioViewModel> usuarios = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(content);

        //        return View(usuarios);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //[HttpGet]
        //public ActionResult Details(int id)
        //{
        //    try
        //    {
        //        ServiceRepository serviceObj = new ServiceRepository();
        //        HttpResponseMessage response = serviceObj.GetResponse("api/usuario/" + id.ToString());

        //        response.EnsureSuccessStatusCode();

        //        Models.UsuarioViewModel usuarioViewModel = response.Content.ReadAsAsync<Models.UsuarioViewModel>().Result;
        //        //ViewBag.Title = "All Products";
        //        return View(usuarioViewModel);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public ActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(UsuarioViewModel usuario)
        //{
        //    try
        //    {
        //        ServiceRepository Repository = new ServiceRepository();
        //        HttpResponseMessage response = Repository.PostResponse("api/usuario/", usuario);

        //        response.EnsureSuccessStatusCode();

        //        UsuarioViewModel usuarioViewModel = response.Content.ReadAsAsync<UsuarioViewModel>().Result;

        //        return RedirectToAction("Details", new { id = usuarioViewModel.Idusuario });
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public ActionResult Edit(int id)
        //{
        //    ServiceRepository serviceObj = new ServiceRepository();
        //    HttpResponseMessage response = serviceObj.GetResponse("api/usuario/" + id.ToString());
        //    response.EnsureSuccessStatusCode();
        //    UsuarioViewModel usuarioViewModel = response.Content.ReadAsAsync<UsuarioViewModel>().Result;
        //    return View(usuarioViewModel);
        //}

        //// POST: CategoryController/Edit/5
        //[HttpPost]
        //public ActionResult Edit(UsuarioViewModel usuario)
        //{
        //    ServiceRepository serviceObj = new ServiceRepository();
        //    HttpResponseMessage response = serviceObj.PutResponse("api/usuario", usuario);
        //    response.EnsureSuccessStatusCode();
        //    return RedirectToAction("Details", new { id = usuario.Idusuario });
        //}

        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    ServiceRepository serviceObj = new ServiceRepository();
        //    HttpResponseMessage response = serviceObj.GetResponse("api/usuario/" + id.ToString());
        //    response.EnsureSuccessStatusCode();
        //    UsuarioViewModel usuarioViewModel = response.Content.ReadAsAsync<UsuarioViewModel>().Result;
        //    return View(usuarioViewModel);
        //}

        //[HttpPost]
        //public ActionResult Delete(UsuarioViewModel usuario)
        //{
        //    ServiceRepository serviceObj = new ServiceRepository();
        //    HttpResponseMessage response = serviceObj.DeleteResponse("api/usuario/" + usuario.Idusuario.ToString());
        //    response.EnsureSuccessStatusCode();
        //    bool Eliminado = response.Content.ReadAsAsync<bool>().Result;

        //    if (Eliminado)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        throw new Exception();
        //    }
        //}

    }
}
