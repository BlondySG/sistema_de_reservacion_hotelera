using Backend.Models;
using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HabitacionController : ControllerBase
    {
        private IHabitacionDAL habitacionDAL;

        public HabitacionController()
        {
            habitacionDAL = new HabitacionDALImpl(new SistemaReservacionHotelContext());
        }

        #region Conversiones
        HabitacionModel Convertir(Habitacion habitacion)
        {
            return new HabitacionModel
            {
                Idhabitacion = habitacion.Idhabitacion,
                PisoHabitacion = habitacion.PisoHabitacion,
                IdtipoHabitacion = habitacion.IdtipoHabitacion
            };
        }

        Habitacion Convertir(HabitacionModel habitacion) 
        {
            return new Habitacion
            {
                Idhabitacion = habitacion.Idhabitacion,
                PisoHabitacion = habitacion.PisoHabitacion,
                IdtipoHabitacion = habitacion.IdtipoHabitacion
            };
        }
        #endregion

        #region Consultar
        // GET: api/<HabitacionController>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                IEnumerable<Habitacion> habitaciones;
                habitaciones = habitacionDAL.GetAll();

                List<HabitacionModel> result = new List<HabitacionModel>();
                foreach (Habitacion habitacion in habitaciones)
                {
                    result.Add(Convertir(habitacion));
                }
                return new JsonResult(result);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        // GET api/<HabitacionController>/5
        [HttpGet("{id}", Name = "Get")]
        public JsonResult Get(int id)
        {
            try
            {
                Habitacion habitacion;
                habitacion = habitacionDAL.Get(id);

                return new JsonResult(Convertir(habitacion));
            }
            catch (Exception)
            {

                throw;
            }
            
        }
        #endregion

        #region Agregar
        
        // POST api/<HabitacionController>
        [HttpPost]
        public JsonResult Post([FromBody] HabitacionModel habitacion)
        {

            try
            {
                Habitacion nuevo = Convertir(habitacion);
                habitacionDAL.Add(nuevo);

                return new JsonResult(Convertir(nuevo));

            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region Actualizar
        // PUT api/<HabitacionController>/5
        [HttpPut]
        public JsonResult Put([FromBody] HabitacionModel habitacion)
        {
            try
            {
                habitacionDAL.Update(Convertir(habitacion));
                return new JsonResult(habitacion);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Eliminar
        // DELETE api/<HabitacionController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                Habitacion habitacion = new Habitacion { Idhabitacion = id };

                habitacionDAL.Remove(habitacion);
                return new JsonResult(habitacion);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
