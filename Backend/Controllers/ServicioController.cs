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
    public class ServicioController : ControllerBase
    {
        private IServicioDAL servicioDAL;

        public ServicioController()
        {
            servicioDAL = new ServicioDALImpl(new Entities.SistemaReservacionHotelContext());
        }

        ServicioModel Convertir(Servicio servicio)
        {
            return new ServicioModel
            {
                Idservicio = servicio.Idservicio,
                NombreServicio = servicio.NombreServicio,
                CostoServicio = servicio.CostoServicio
            };
        }

        Servicio Convertir(ServicioModel servicio)
        {
            return new Servicio
            {
                Idservicio = servicio.Idservicio,
                NombreServicio = servicio.NombreServicio,
                CostoServicio = servicio.CostoServicio
            };
        }

        // GET: api/<ServicioController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Servicio> servicios;
            servicios = servicioDAL.GetAll();

            List<ServicioModel> result = new List<ServicioModel>();
            foreach (Servicio servicio in servicios)
            {
                result.Add(Convertir(servicio));
            }
            return new JsonResult(result);
        }

        // GET api/<ServicioController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Servicio servicio = servicioDAL.Get(id);

            ServicioModel model = Convertir(servicio);

            return new JsonResult(model);
        }

        // POST api/<ServicioController>
        [HttpPost]
        public JsonResult Post([FromBody] Servicio servicio)
        {
            try
            {
                servicioDAL.Add(servicio);
                return new JsonResult(Convertir(servicio));
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT api/<ServicioController>/5
        [HttpPut]
        public JsonResult Put(int id, [FromBody] ServicioModel servicio)
        {
            try
            {
                servicioDAL.Update(Convertir(servicio));
                return new JsonResult(servicio);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE api/<ServicioController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                Servicio servicio = new Servicio { Idservicio = id };

                servicioDAL.Remove(servicio);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
