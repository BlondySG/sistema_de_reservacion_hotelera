using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class TipoHabitacionDALImpl : ITipoHabitacionDAL
    {
        SistemaReservacionHotelContext context;

        public TipoHabitacionDALImpl() // vacio en done instancia un nuevo objeto.
        {
            context = new SistemaReservacionHotelContext();
        }


        public TipoHabitacionDALImpl(SistemaReservacionHotelContext sistemaReservacionHotelContext)  //recibe por parametro la conexión
        {
            this.context = sistemaReservacionHotelContext;
        }

        public bool Add(TipoHabitacion entity)
        {
            try
            {
                using (UnidadDeTrabajo<TipoHabitacion> unidad = new UnidadDeTrabajo<TipoHabitacion>(context))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        public TipoHabitacion Get(int habitacionId)
        {
            try
            {
                TipoHabitacion habitacion;
                using (UnidadDeTrabajo<TipoHabitacion> unidad = new UnidadDeTrabajo<TipoHabitacion>(context))
                {
                    habitacion = unidad.genericDAL.Get(habitacionId);
                }
                return habitacion;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<TipoHabitacion> GetAll()
        {
            try
            {
                IEnumerable<TipoHabitacion> habitacion;
                using (UnidadDeTrabajo<TipoHabitacion> unidad = new UnidadDeTrabajo<TipoHabitacion>(context))
                {
                    habitacion = unidad.genericDAL.GetAll();
                }
                return habitacion;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool Remove(TipoHabitacion entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<TipoHabitacion> unidad = new UnidadDeTrabajo<TipoHabitacion>(context))
                {
                    unidad.genericDAL.Remove(entity);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                result = false;
            }

            return result;
        }




        public bool Update(TipoHabitacion entity)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<TipoHabitacion> unidad = new UnidadDeTrabajo<TipoHabitacion>(context))
                {
                    unidad.genericDAL.Update(entity);
                    result = unidad.Complete();
                }

            }
            catch (Exception)
            {

                return false;
            }

            return result;
        }











        public void AddRange(IEnumerable<TipoHabitacion> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoHabitacion> Find(Expression<Func<TipoHabitacion, bool>> predicate)
        {
            throw new NotImplementedException();
        }



  
        public void RemoveRange(IEnumerable<TipoHabitacion> entities)
        {
            throw new NotImplementedException();
        }

        public TipoHabitacion SingleOrDefault(Expression<Func<TipoHabitacion, bool>> predicate)
        {
            throw new NotImplementedException();
        }


    }
}
