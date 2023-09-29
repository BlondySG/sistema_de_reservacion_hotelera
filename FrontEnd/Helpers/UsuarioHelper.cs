using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers
{
    public class UsuarioHelper
    {

        #region Obtiene Rol 
        public RolViewModel GetRol(int id)
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


        #region Obtiene Lista TipoHabitaciones
        public List<RolViewModel> GetRoles()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse("api/Rol/");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            List<RolViewModel> rolViewModel = JsonConvert.DeserializeObject<List<RolViewModel>>(content);

            return rolViewModel;

        }
        #endregion


        #region GetAll
        public List<UsuarioViewModel> GetAll()
        {
            try
            {
                ServiceRepository Repository = new ServiceRepository();
                HttpResponseMessage responseMessage = Repository.GetResponse("api/Usuario");
                responseMessage.EnsureSuccessStatusCode();
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                List<UsuarioViewModel> Usuario = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(content);

                return Usuario;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        #region Read
        public UsuarioViewModel Details(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Usuario/" + id.ToString());
                response.EnsureSuccessStatusCode();
                UsuarioViewModel usuarioViewModel = response.Content.ReadAsAsync<UsuarioViewModel>().Result;
                usuarioViewModel.Rol = this.GetRol(usuarioViewModel.Idrol);
                return usuarioViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        #region Update

        public UsuarioViewModel Edit(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Usuario/" + id.ToString());
                response.EnsureSuccessStatusCode();
                UsuarioViewModel usuarioViewModel = response.Content.ReadAsAsync<UsuarioViewModel>().Result;
                usuarioViewModel.Roles = this.GetRoles();

                return usuarioViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion


        #region Delete
        public UsuarioViewModel Delete(int id)
        {
            try
            {
                ServiceRepository serviceObj = new ServiceRepository();
                HttpResponseMessage response = serviceObj.GetResponse("api/Usuario/" + id.ToString());
                response.EnsureSuccessStatusCode();
                UsuarioViewModel usuarioViewModel = response.Content.ReadAsAsync<UsuarioViewModel>().Result;
                usuarioViewModel.Rol = this.GetRol(usuarioViewModel.Idrol);
                return usuarioViewModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
#endregion
    }
}
