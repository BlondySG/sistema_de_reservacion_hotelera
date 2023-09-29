using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers
{
    //[Authorize]
    public class HabitacionController : Controller
    {
        #region Constructor

        HabitacionHelper _habitacionHelper;
        TipoHabitacionHelper _tipoHabitacionHelper;

        public HabitacionController()
        {
            _habitacionHelper = new HabitacionHelper();
            _tipoHabitacionHelper = new TipoHabitacionHelper();
        }
        #endregion

        #region Obtiene TipoHabitacion
        private TipoHabitacionViewModel GetTipoHabitacion(int id)
        {
            try
            {
                TipoHabitacionViewModel tipoHabitacionViewModel = _tipoHabitacionHelper.Details(id);

                return tipoHabitacionViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Obtiene Lista TiposHabitaciones
        private List<TipoHabitacionViewModel> GetTipoHabitaciones()
        {
            List<TipoHabitacionViewModel> tiposHabitaciones = _tipoHabitacionHelper.GetAll();

            return tiposHabitaciones;

        }
        #endregion

        #region Create
        // GET: TbArticulosController/Create
        public ActionResult Create()
        {
            try
            {
                HabitacionViewModel habitacion = new HabitacionViewModel { };
                habitacion.tipoHabitaciones = this.GetTipoHabitaciones();

                return View(habitacion);

            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: TbArticulosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HabitacionViewModel articulo)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Habitacion", articulo);
                response.EnsureSuccessStatusCode();
                HabitacionViewModel habitacionViewModel = response.Content.ReadAsAsync<HabitacionViewModel>().Result;
                return RedirectToAction("Details", new { id = habitacionViewModel.Idhabitacion });
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
                List<HabitacionViewModel> habitaciones = _habitacionHelper.GetAll();

                foreach (var item in habitaciones)
                {
                    item.TipoHabitacion = _tipoHabitacionHelper.Details(item.IdtipoHabitacion);
                }
                return View(habitaciones);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: TbArticulosController/Details/5
        public ActionResult Details(int id)
        {
            HabitacionViewModel habitacionViewModel = _habitacionHelper.Details(id);

            return View(habitacionViewModel);

        }
        #endregion

        #region Update
        // GET: TbArticulosController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                HabitacionViewModel habitacionViewModel = _habitacionHelper.Edit(id);
                return View(habitacionViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbArticulosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HabitacionViewModel habitacion)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/Habitacion", habitacion);
                response.EnsureSuccessStatusCode();
                HabitacionViewModel habitacionViewModel = response.Content.ReadAsAsync<HabitacionViewModel>().Result;
                return RedirectToAction("Details", new { id = habitacionViewModel.Idhabitacion });
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
                HabitacionViewModel habitacionViewModel = _habitacionHelper.Delete(id);

                return View(habitacionViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbArticulosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(HabitacionViewModel habitacion)
        {
            try
            {
                int id = habitacion.Idhabitacion;
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Habitacion/" + id.ToString());
                response.EnsureSuccessStatusCode();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

        //private List<TipoHabitacionViewModel> GetTipoHabitaciones()
        //{
        //    try
        //    {
        //        ServiceRepository serviceObj = new ServiceRepository();
        //        HttpResponseMessage response = serviceObj.GetResponse("api/tipohabitacion/");
        //        response.EnsureSuccessStatusCode();
        //        var content = response.Content.ReadAsStringAsync().Result;
        //        List<TipoHabitacionViewModel> tipohabitaciones =
        //            JsonConvert.DeserializeObject<List<TipoHabitacionViewModel>>(content);

        //        return tipohabitaciones;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        //// GET: HabitacionController
        //public ActionResult Index()
        //{
        //    try
        //    {
        //        ServiceRepository serviceObj = new ServiceRepository();
        //        HttpResponseMessage response = serviceObj.GetResponse("api/habitacion/");
        //        response.EnsureSuccessStatusCode();
        //        var content = response.Content.ReadAsStringAsync().Result;
        //        List<HabitacionViewModel> habitaciones =
        //            JsonConvert.DeserializeObject<List<HabitacionViewModel>>(content);

        //        return View(habitaciones);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //// GET: HabitacionController/Details/5
        //public ActionResult Details(int id)
        //{
        //    try
        //    {
        //        ServiceRepository serviceObj = new ServiceRepository();
        //        HttpResponseMessage response = serviceObj.GetResponse("api/habitacion/" + id.ToString());
        //        response.EnsureSuccessStatusCode();
        //        HabitacionViewModel HabitacionViewModel = response.Content.ReadAsAsync<HabitacionViewModel>().Result;
        //        return View(HabitacionViewModel);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //// GET: HabitacionController/Create
        //public ActionResult Create()
        //{
        //    try
        //    {
        //        HabitacionViewModel habitacion = new HabitacionViewModel { };
        //        //habitacion.TipoHabitacions = this.GetTipoHabitaciones();

        //        return View(habitacion);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //// POST: HabitacionController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(HabitacionViewModel habitacion)
        //{
        //    try
        //    {
        //        ServiceRepository serviceObj = new ServiceRepository();
        //        HttpResponseMessage response = serviceObj.PostResponse("api/habitacion", habitacion);
        //        response.EnsureSuccessStatusCode();
        //        HabitacionViewModel habitacionViewModel = response.Content.ReadAsAsync<HabitacionViewModel>().Result;
        //        return RedirectToAction("Details", new { id = habitacionViewModel.Idhabitacion });
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: HabitacionController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    try
        //    {
        //        ServiceRepository serviceObj = new ServiceRepository();
        //        HttpResponseMessage response = serviceObj.GetResponse("api/habitacion/" + id.ToString());
        //        response.EnsureSuccessStatusCode();
        //        HabitacionViewModel HabitacionViewModel = response.Content.ReadAsAsync<HabitacionViewModel>().Result;

        //        //habitacion.TipoHabitacions = this.GetTipoHabitaciones();
        //        return View(HabitacionViewModel);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //// POST: HabitacionController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(HabitacionViewModel habitacion)
        //{
        //    try
        //    {
        //        ServiceRepository serviceObj = new ServiceRepository();
        //        HttpResponseMessage response = serviceObj.PutResponse("api/habitacion", habitacion);
        //        response.EnsureSuccessStatusCode();
        //        HabitacionViewModel habitacionViewModel = response.Content.ReadAsAsync<HabitacionViewModel>().Result;
        //        return RedirectToAction("Details", new { id = habitacionViewModel.Idhabitacion });
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: HabitacionController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        ServiceRepository serviceObj = new ServiceRepository();
        //        HttpResponseMessage response = serviceObj.GetResponse("api/habitacion/" + id.ToString());
        //        response.EnsureSuccessStatusCode();
        //        HabitacionViewModel HabitacionViewModel = response.Content.ReadAsAsync<HabitacionViewModel>().Result;

        //        return View(HabitacionViewModel);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //// POST: HabitacionController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(HabitacionViewModel habitacion)
        //{
        //    try
        //    {
        //        int id = habitacion.Idhabitacion;
        //        ServiceRepository serviceObj = new ServiceRepository();
        //        HttpResponseMessage response = serviceObj.DeleteResponse("api/habitacion/" + id.ToString());
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
