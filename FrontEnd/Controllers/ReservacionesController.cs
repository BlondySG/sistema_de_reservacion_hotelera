using FrontEnd.Helpers;
using FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ReservacionesController : Controller
    {

        #region Constructor
        ReservacionesHelper _reservacionHelper;
        HabitacionHelper _habitacionHelper;
        UsuarioHelper _usuarioHelper;


        public ReservacionesController()
        {
            _reservacionHelper = new ReservacionesHelper();
            _habitacionHelper = new HabitacionHelper();
            _usuarioHelper = new UsuarioHelper();
        }
        #endregion


        #region ObtieneHabitacion
        private HabitacionViewModel GetHabitacion(int id)
        {
            try
            {
                HabitacionViewModel habitacionViewModel = _habitacionHelper.Details(id);

                return habitacionViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Obtiene Lista Habitaciones
        private List<HabitacionViewModel> GetHabitaciones()
        {
            List<HabitacionViewModel> Habitaciones = _habitacionHelper.GetAll();

            return Habitaciones;

        }
        #endregion

        #region ObtieneUsuario
        private UsuarioViewModel GetUsuario(int id)
        {
            try
            {
                UsuarioViewModel usuarioViewModel = _usuarioHelper.Details(id);

                return usuarioViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Obtiene Lista Usuarios
        private List<UsuarioViewModel> GetUsuarios()
        {
            List<UsuarioViewModel> Usuarios = _usuarioHelper.GetAll();

            return Usuarios;

        }
        #endregion

        #region Create
        // GET: TbArticulosController/Create
        public ActionResult Create()
        {
            try
            {
                ReservacionesViewModel reservacion = new ReservacionesViewModel { };
                reservacion.Habitaciones = this.GetHabitaciones();
                reservacion.Usuarios = this.GetUsuarios();

                return View(reservacion);

            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: TbArticulosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReservacionesViewModel reservacion)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PostResponse("api/Reservaciones", reservacion);
                response.EnsureSuccessStatusCode();
                ReservacionesViewModel reservacionesViewModel = response.Content.ReadAsAsync<ReservacionesViewModel>().Result;
                return RedirectToAction("Details", new { id = reservacionesViewModel.Idreservacion });
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
                List<ReservacionesViewModel> reservaciones = _reservacionHelper.GetAll();

                foreach (var item in reservaciones)
                {
                    item.Habitacion = _habitacionHelper.Details(item.Idhabitacion);
                    item.Usuario = _usuarioHelper.Details(item.Idusuario);
                }
                return View(reservaciones);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: TbArticulosController/Details/5
        public ActionResult Details(int id)
        {
            ReservacionesViewModel reservacionesViewModel = _reservacionHelper.Details(id);

            return View(reservacionesViewModel);

        }
        #endregion

        #region Update
        // GET: ReservacionesController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ReservacionesViewModel reservacionesViewModel = _reservacionHelper.Edit(id);
                return View(reservacionesViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: ReservacionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ReservacionesViewModel reservacion)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.PutResponse("api/Reservaciones", reservacion);
                response.EnsureSuccessStatusCode();
                ReservacionesViewModel reservacionesViewModel = response.Content.ReadAsAsync<ReservacionesViewModel>().Result;
                return RedirectToAction("Details", new { id = reservacionesViewModel.Idreservacion });
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
                ReservacionesViewModel reservacionesViewModel = _reservacionHelper.Delete(id);

                return View(reservacionesViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: TbArticulosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ReservacionesViewModel reservacion)
        {
            try
            {
                int id = reservacion.Idreservacion;
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.DeleteResponse("api/Reservaciones/" + id.ToString());
                response.EnsureSuccessStatusCode();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        #endregion

    }
}
