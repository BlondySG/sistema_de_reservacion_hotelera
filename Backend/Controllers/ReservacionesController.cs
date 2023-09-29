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
    public class ReservacionesController : ControllerBase
    {
        private IReservacionesDAL reservacionDAL;

        public ReservacionesController()
        {
            reservacionDAL = new ReservacioneDALImpl(new SistemaReservacionHotelContext());
        }

        ReservacionesModel Convertir(Reservacione reservacion)
        {
            return new ReservacionesModel
            {
                Idreservacion = reservacion.Idreservacion,
                FechaInicio = reservacion.FechaInicio,
                CantidadNoches = reservacion.CantidadNoches,
                NombreCliente = reservacion.NombreCliente,
                CedulaCliente = reservacion.CedulaCliente,
                Idhabitacion = reservacion.Idhabitacion,
                Idusuario = reservacion.Idusuario,
                Idservicio = reservacion.Idservicio
            };
        }

        Reservacione Convertir(ReservacionesModel reservacion) 
        {
            return new Reservacione
            {
                Idreservacion = reservacion.Idreservacion,
                FechaInicio = reservacion.FechaInicio,
                CantidadNoches = reservacion.CantidadNoches,
                NombreCliente = reservacion.NombreCliente,
                CedulaCliente = reservacion.CedulaCliente,
                Idhabitacion = reservacion.Idhabitacion,
                Idusuario = reservacion.Idusuario,
                Idservicio = reservacion.Idservicio
            };
        }

        // GET: api/<ReservacionesController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Reservacione> reservaciones;
            reservaciones = reservacionDAL.GetAll();

            List<ReservacionesModel> result = new List<ReservacionesModel>();
            foreach (Reservacione reservacion in reservaciones)
            {
                result.Add(Convertir(reservacion));
            }
            return new JsonResult(result);
        }

        // GET api/<ReservacionesController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Reservacione reservacion = reservacionDAL.Get(id);

            ReservacionesModel model = Convertir(reservacion);

            return new JsonResult(model);
        }

        // POST api/<ReservacionesController>
        [HttpPost]
        public JsonResult Post([FromBody] ReservacionesModel reservacion)
        {
            try
            {
                Reservacione nuevo = Convertir(reservacion);
                reservacionDAL.Add(nuevo);

                return new JsonResult(Convertir(nuevo));
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT api/<ReservacionesController>/5
        [HttpPut]
        public JsonResult Put([FromBody] ReservacionesModel reservacion)
        {
            try
            {
                reservacionDAL.Update(Convertir(reservacion));
                return new JsonResult(reservacion);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE api/<ReservacionesController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                Reservacione reservacion = new Reservacione { Idreservacion = id };

                reservacionDAL.Remove(reservacion);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
