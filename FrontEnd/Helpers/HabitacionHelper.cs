using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class HabitacionHelper
    {
        #region Obtiene TipoHabitacion 
        public TipoHabitacionViewModel GetTipoHabitacion(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/TipoHabitacion/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TipoHabitacionViewModel TipoHabitacionViewModel = response.Content.ReadAsAsync<TipoHabitacionViewModel>().Result;
                return TipoHabitacionViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Obtiene Lista TipoHabitaciones
        public List<TipoHabitacionViewModel> GetTipoHabitaciones()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/TipoHabitacion/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<TipoHabitacionViewModel> tipohabitaciones = JsonConvert.DeserializeObject<List<TipoHabitacionViewModel>>(content);

            return tipohabitaciones;

        }
        #endregion

        #region GetAll
        public List<HabitacionViewModel> GetAll()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/Habitacion");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<HabitacionViewModel> habitaciones = JsonConvert.DeserializeObject<List<HabitacionViewModel>>(content);

                return habitaciones;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        public HabitacionViewModel Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Habitacion/" + id.ToString());
                response.EnsureSuccessStatusCode();
                HabitacionViewModel habitacionViewModel = response.Content.ReadAsAsync<HabitacionViewModel>().Result;
                habitacionViewModel.TipoHabitacion = this.GetTipoHabitacion(habitacionViewModel.IdtipoHabitacion);
                return habitacionViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update

        public HabitacionViewModel Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Habitacion/" + id.ToString());
                response.EnsureSuccessStatusCode();
                HabitacionViewModel habitacionViewModel = response.Content.ReadAsAsync<HabitacionViewModel>().Result;
                habitacionViewModel.tipoHabitaciones = this.GetTipoHabitaciones();
                return habitacionViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete

        public HabitacionViewModel Delete(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Habitacion/" + id.ToString());
                response.EnsureSuccessStatusCode();
                HabitacionViewModel habitacionViewModel = response.Content.ReadAsAsync<HabitacionViewModel>().Result;
                habitacionViewModel.TipoHabitacion = this.GetTipoHabitacion(habitacionViewModel.IdtipoHabitacion);
                return habitacionViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
