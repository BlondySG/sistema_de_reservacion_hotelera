using Backend.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private IRolDAL rolDAL;

        public RolController()
        {
            rolDAL = new RolDALImpl(new SistemaReservacionHotelContext());
        }

        #region Conversiones
        RolModel Convertir(Rol rol)
        {
            return new RolModel
            {

                Idrol = rol.Idrol,
                NombreRol = rol.NombreRol
            };
        }

        Rol Convertir(RolModel rol) 
        {
            return new Rol
            {
                Idrol = rol.Idrol,
                NombreRol = rol.NombreRol
            };
        }
        #endregion

        #region Consultar
        // GET: api/<RolController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<Rol> roles;
                roles = rolDAL.GetAll();

                List<RolModel> result = new List<RolModel>();
                foreach (Rol rol in roles)
                {
                    result.Add(Convertir(rol));
                }
                return new JsonResult(result);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        // GET api/<RolController>/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            try
            {
                Rol rol;
                rol = rolDAL.Get(id);

                return new JsonResult(Convertir(rol));
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        #endregion

        #region Agregar
        // POST api/<RolController>
        [HttpPost]
        public JsonResult Post([FromBody] RolModel rol)
        {
            try
            {
                Rol nuevo = Convertir(rol);
                rolDAL.Add(nuevo);

                return new JsonResult(Convertir(nuevo));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Actualizar
        // PUT api/<RolController>/5
        [HttpPut]
        public JsonResult Put([FromBody] RolModel rol)
        {
            try
            {
                rolDAL.Update(Convertir(rol));
                return new JsonResult(rol);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Eliminar
        // DELETE api/<RolController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Rol rol = new Rol { Idrol = id };

                rolDAL.Remove(rol);
                return new JsonResult(rol);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
