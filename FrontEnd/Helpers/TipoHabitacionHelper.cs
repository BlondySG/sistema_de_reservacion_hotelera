using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class TipoHabitacionHelper
    {
        #region GetAll
        public List<TipoHabitacionViewModel> GetAll()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/TipoHabitacion");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<TipoHabitacionViewModel> THabitacion =
                    JsonConvert.DeserializeObject<List<TipoHabitacionViewModel>>(content);

                return THabitacion;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        public TipoHabitacionViewModel Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/TipoHabitacion/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TipoHabitacionViewModel tipoHabitacionViewModel = response.Content.ReadAsAsync<TipoHabitacionViewModel>().Result;

                return tipoHabitacionViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        #region Update

        public TipoHabitacionViewModel Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/TipoHabitacion/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TipoHabitacionViewModel tipoHabitacionViewModel = response.Content.ReadAsAsync<TipoHabitacionViewModel>().Result;

                return tipoHabitacionViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete

        public TipoHabitacionViewModel Delete(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/TipoHabitacion/" + id.ToString());
                response.EnsureSuccessStatusCode();
                TipoHabitacionViewModel tipoHabitacionViewModel = response.Content.ReadAsAsync<TipoHabitacionViewModel>().Result;

                return tipoHabitacionViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
