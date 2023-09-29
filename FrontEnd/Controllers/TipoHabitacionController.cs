using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    public class TipoHabitacionController : Controller
    {

        #region Constructor
        TipoHabitacionHelper _TipoHabitacionHelper;

        public TipoHabitacionController()
        {
            _TipoHabitacionHelper = new TipoHabitacionHelper();
        }

        #endregion


        #region Create
        // GET: TbProveedorController/Create
        public ActionResult Create()
        {
            try
            {
                TipoHabitacionViewModel tipoHab = new TipoHabitacionViewModel { };
                return View(tipoHab);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbProveedorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TipoHabitacionViewModel tipoHab)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/TipoHabitacion", tipoHab);
                response.EnsureSuccessStatusCode();
                TipoHabitacionViewModel TipoHabitacionViewModel = response.Content.ReadAsAsync<TipoHabitacionViewModel>().Result;
                return RedirectToAction("Details", new { id = TipoHabitacionViewModel.IdtipoHabitacion });
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
        // GET: TbProveedorController
        public ActionResult Index()
        {
            try
            {
                List<TipoHabitacionViewModel> TipoHab = _TipoHabitacionHelper.GetAll();

                return View(TipoHab);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: TbProveedorController/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            try
            {
                TipoHabitacionViewModel TipoHabitacionViewModel = _TipoHabitacionHelper.Details(id);
                return View(TipoHabitacionViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        #region Update
        // GET: TbProveedorController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                TipoHabitacionViewModel TipoHabitacionViewModel = _TipoHabitacionHelper.Edit(id);

                return View(TipoHabitacionViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbProveedorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoHabitacionViewModel TipoHab)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/TipoHabitacion", TipoHab);
                response.EnsureSuccessStatusCode();
                return RedirectToAction("Details", new { id = TipoHab.IdtipoHabitacion });
            }
            catch
            {
                return View();
            }
        }
        #endregion


        #region Delete
        //GET: TbProveedorController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                TipoHabitacionViewModel TipoHabitacionViewModel = _TipoHabitacionHelper.Delete(id);

                return View(TipoHabitacionViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbProveedorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TipoHabitacionViewModel TipoHab)
        {
            try
            {
                int id = TipoHab.IdtipoHabitacion;
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/TipoHabitacion/" + id.ToString());
                response.EnsureSuccessStatusCode();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion



        ////// GET: TipoHabitacionController
        ////public ActionResult Index()
        ////{
        ////    try
        ////    {
        ////        ServiceRepository serviceObj = new ServiceRepository();
        ////        HttpResponseMessage response = serviceObj.GetResponse("api/TipoHabitacion/");
        ////        response.EnsureSuccessStatusCode();
        ////        var content = response.Content.ReadAsStringAsync().Result;
        ////        List<TipoHabitacionViewModel> artitipoHabitacionculo = JsonConvert.DeserializeObject<List<TipoHabitacionViewModel>>(content);

        ////        ViewBag.Title = "Todas las habitaciones";
        ////        return View(artitipoHabitacionculo);
        ////    }
        ////    catch (Exception)
        ////    {
        ////        throw;
        ////    }
        ////}

        //// GET: TipoHabitacionController/Details/5
        //public ActionResult Details(int id)
        //{
        //    ServiceRepository serviceObj = new ServiceRepository();
        //    HttpResponseMessage response = serviceObj.GetResponse("api/TipoHabitacion/" + id.ToString());
        //    response.EnsureSuccessStatusCode();
        //    TipoHabitacionViewModel tipoHabitacionViewModel = response.Content.ReadAsAsync<TipoHabitacionViewModel>().Result;

        //    return View(tipoHabitacionViewModel);
        //}

        //// GET: TipoHabitacionController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: TipoHabitacionController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(TipoHabitacionViewModel tipoHabitacion)
        //{
        //    try
        //    {
        //        ServiceRepository serviceObj = new ServiceRepository();
        //        HttpResponseMessage response = serviceObj.PostResponse("api/TipoHabitacion", tipoHabitacion);
        //        response.EnsureSuccessStatusCode();
        //        TipoHabitacionViewModel tipoHabitacionViewModel = response.Content.ReadAsAsync<TipoHabitacionViewModel>().Result;
        //        return RedirectToAction("Details", new { id = tipoHabitacionViewModel.IdtipoHabitacion });
        //    }
        //    catch (HttpRequestException)
        //    {
        //        return RedirectToAction("Error", "Home");
        //    }
        //}


        //// GET: TipoHabitacionController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    try
        //    {
        //        ServiceRepository serviceObj = new ServiceRepository();
        //        HttpResponseMessage response = serviceObj.GetResponse("api/TipoHabitacion/" + id.ToString());
        //        response.EnsureSuccessStatusCode();
        //        TipoHabitacionViewModel tipoHabitacionViewModel = response.Content.ReadAsAsync<TipoHabitacionViewModel>().Result;

        //        return View(tipoHabitacionViewModel);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //// POST: TipoHabitacionController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(TipoHabitacionViewModel tipoHabitacion)
        //{
        //    try
        //    {
        //        ServiceRepository serviceObj = new ServiceRepository();
        //        HttpResponseMessage response = serviceObj.PutResponse("api/TipoHabitacion", tipoHabitacion);
        //        response.EnsureSuccessStatusCode();
        //        TipoHabitacionViewModel tipoHabitacionViewModel = response.Content.ReadAsAsync<TipoHabitacionViewModel>().Result;
        //        return RedirectToAction("Details", new { id = tipoHabitacionViewModel.IdtipoHabitacion });
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TipoHabitacionController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        ServiceRepository serviceObj = new ServiceRepository();
        //        HttpResponseMessage response = serviceObj.GetResponse("api/TipoHabitacion/" + id.ToString());
        //        response.EnsureSuccessStatusCode();
        //        TipoHabitacionViewModel tipoHabitacionViewModel = response.Content.ReadAsAsync<TipoHabitacionViewModel>().Result;

        //        return View(tipoHabitacionViewModel);

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //// POST: TipoHabitacionController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(TipoHabitacionViewModel tipoHabitacion)
        //{
        //    try
        //    {
        //        int id = tipoHabitacion.IdtipoHabitacion;
        //        ServiceRepository serviceObj = new ServiceRepository();
        //        HttpResponseMessage response = serviceObj.DeleteResponse("api/TipoHabitacion/" + id.ToString());
        //        response.EnsureSuccessStatusCode();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
