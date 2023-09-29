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
    public class TipoHabitacionController : ControllerBase
    {

        private ITipoHabitacionDAL tipohabitacionDAL;

        public TipoHabitacionController()
        {
            tipohabitacionDAL = new TipoHabitacionDALImpl(new SistemaReservacionHotelContext());
        }


        TipoHabitacion Convertir(TipoHabitacionModel habitacion)
        {

            return new TipoHabitacion
            {
                IdtipoHabitacion = habitacion.IdtipoHabitacion,
                NombreTipoHabitacion = habitacion.NombreTipoHabitacion,
                CostoTipoHabitacion = habitacion.CostoTipoHabitacion
            };

        }



        TipoHabitacionModel Convertir(TipoHabitacion habitacion)
        {
            return new TipoHabitacionModel
            {

                IdtipoHabitacion = habitacion.IdtipoHabitacion,
                NombreTipoHabitacion = habitacion.NombreTipoHabitacion,
                CostoTipoHabitacion = habitacion.CostoTipoHabitacion
            };
        }





        #region Agregar Tipo Habitacion
        // POST api/<TipoHabitacionController>
        [HttpPost]
        public JsonResult Post([FromBody] TipoHabitacionModel habitacion)
        {

            try
            {
                TipoHabitacion nuevo = Convertir(habitacion);
                tipohabitacionDAL.Add(nuevo);

                return new JsonResult(Convertir(nuevo));

            }
            catch (Exception)
            {

                throw;
            }


        }


        #endregion


        #region Obtener Tipo Habitacion

        // GET: api/<TipoHabitacionController>
        [HttpGet]
        public JsonResult Get()
        {


            IEnumerable<TipoHabitacion> habitaciones;
            habitaciones = tipohabitacionDAL.GetAll();

            List<TipoHabitacionModel> result = new List<TipoHabitacionModel>();
            foreach (TipoHabitacion habitacion in habitaciones)
            {
                result.Add(Convertir(habitacion));
            }


            return new JsonResult(result);
        }

        // GET api/<TipoHabitacionController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {

            TipoHabitacion habitacion;
            habitacion = tipohabitacionDAL.Get(id);

            return new JsonResult(Convertir(habitacion));
        }



        #endregion


        #region Actualizar Tipo Habitacion
        // PUT api/<TipoHabitacionController>/5
        [HttpPut] //("{id}")
        public JsonResult Put([FromBody] TipoHabitacionModel habitacion)
        {

            try
            {
                TipoHabitacion hab = Convertir(habitacion);
                tipohabitacionDAL.Update(hab);

                return new JsonResult(Convertir(hab));

            }
            catch (Exception)
            {

                throw;
            }

        }


        #endregion



        #region Eliminar Tipo Habitacion

        // DELETE api/<TipoHabitacionController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {

                TipoHabitacion habitacion = new TipoHabitacion { IdtipoHabitacion = id };
                //category = categoryDAL.Get(id);

                tipohabitacionDAL.Remove(habitacion);
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
