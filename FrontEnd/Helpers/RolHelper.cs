using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class RolHelper
    {
        #region GetAll
        public List<RolViewModel> GetAll()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/Rol");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<RolViewModel> rol =
                    JsonConvert.DeserializeObject<List<RolViewModel>>(content);

                return rol;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Read
        public RolViewModel Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Rol/" + id.ToString());
                response.EnsureSuccessStatusCode();
                RolViewModel rolHelper = response.Content.ReadAsAsync<RolViewModel>().Result;

                return rolHelper;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Update

        public RolViewModel Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Rol/" + id.ToString());
                response.EnsureSuccessStatusCode();
                RolViewModel rolHelper = response.Content.ReadAsAsync<RolViewModel>().Result;

                return rolHelper;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Delete

        public RolViewModel Delete(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Rol/" + id.ToString());
                response.EnsureSuccessStatusCode();
                RolViewModel rolViewModel = response.Content.ReadAsAsync<RolViewModel>().Result;

                return rolViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
