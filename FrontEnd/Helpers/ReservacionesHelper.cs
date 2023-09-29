using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    #region Obtiene Habitacion 
    public class ReservacionesHelper
    {
        public HabitacionViewModel GetHabitacion(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Habitacion/" + id.ToString());
                response.EnsureSuccessStatusCode();
                HabitacionViewModel habitacionViewModel = response.Content.ReadAsAsync<HabitacionViewModel>().Result;
                return habitacionViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


    #region Obtiene Lista Habitaciones
        public List<HabitacionViewModel> GetHabitaciones()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Habitacion/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<HabitacionViewModel> habitaciones = JsonConvert.DeserializeObject<List<HabitacionViewModel>>(content);

            return habitaciones;

        }
        #endregion

    #region Obtiene Usuario 
            public UsuarioViewModel GetUsuario(int id)
            {
                try
                {
                    ServiceRepository serviceObj = new ServiceRepository();
                    HttpResponseMessage response = serviceObj.GetResponse("api/Usuario/" + id.ToString());
                    response.EnsureSuccessStatusCode();
                UsuarioViewModel usuarioViewModel = response.Content.ReadAsAsync<UsuarioViewModel>().Result;
                    return usuarioViewModel;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        #endregion

    #region Obtiene Lista Usuarios
        public List<UsuarioViewModel> GetUsuarios()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Usuario/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<UsuarioViewModel> usuarios = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(content);

            return usuarios;

        }
        #endregion

   #region GetAll
        public List<ReservacionesViewModel> GetAll()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/Reservaciones");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<ReservacionesViewModel> reservaciones = JsonConvert.DeserializeObject<List<ReservacionesViewModel>>(content);

                return reservaciones;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

   #region Read
        public ReservacionesViewModel Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Reservaciones/" + id.ToString());
                response.EnsureSuccessStatusCode();
                ReservacionesViewModel reservacionesViewModel = response.Content.ReadAsAsync<ReservacionesViewModel>().Result;
                reservacionesViewModel.Habitacion = this.GetHabitacion(reservacionesViewModel.Idhabitacion);
                reservacionesViewModel.Usuario = this.GetUsuario(reservacionesViewModel.Idusuario);
                return reservacionesViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        
   #region Update

        public ReservacionesViewModel Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Reservaciones/" + id.ToString());
                response.EnsureSuccessStatusCode();
                ReservacionesViewModel reservacionesViewModel = response.Content.ReadAsAsync<ReservacionesViewModel>().Result;
                reservacionesViewModel.Habitaciones = this.GetHabitaciones();
                reservacionesViewModel.Usuarios = this.GetUsuarios();
                return reservacionesViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

   #region Delete
        public ReservacionesViewModel Delete(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Reservaciones/" + id.ToString());
                response.EnsureSuccessStatusCode();
                ReservacionesViewModel reservacionesViewModel = response.Content.ReadAsAsync<ReservacionesViewModel>().Result;
                reservacionesViewModel.Habitacion = this.GetHabitacion(reservacionesViewModel.Idhabitacion);
                reservacionesViewModel.Usuario = this.GetUsuario(reservacionesViewModel.Idusuario);
                return reservacionesViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
#endregion

    }
}
