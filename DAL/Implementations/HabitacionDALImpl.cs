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
    public class HabitacionDALImpl : IHabitacionDAL
    {
        private UnidadDeTrabajo<Habitacion> unidad;
        SistemaReservacionHotelContext context;

        //Constructor
        public HabitacionDALImpl() { 
            context = new SistemaReservacionHotelContext();
        }

        public HabitacionDALImpl(SistemaReservacionHotelContext context)
        {
            this.context = context;
        }

        #region Agregar
        public bool Add(Habitacion entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Habitacion>(context))
                {
                    unidad.genericDAL.Add(entity);
                    return unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        public void AddRange(IEnumerable<Habitacion> entities)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Habitacion> Find(Expression<Func<Habitacion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        #region Obtener
        public Habitacion Get(int id)
        {
            try
            {
                Habitacion habitacion = null;
                using (unidad = new UnidadDeTrabajo<Habitacion>(context))
                {
                    habitacion = unidad.genericDAL.Get(id);
                }
                return habitacion;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Habitacion> GetAll()
        {
            try
            {
                IEnumerable<Habitacion> habitaciones =null;
                using (unidad = new UnidadDeTrabajo<Habitacion>(context))
                {
                    habitaciones = unidad.genericDAL.GetAll();
                }
                return habitaciones;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Eliminar
        public bool Remove(Habitacion entity)
        {
            bool result = false;
            try
            {
                using (unidad = new UnidadDeTrabajo<Habitacion>(context))
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
        #endregion

        public void RemoveRange(IEnumerable<Habitacion> entities)
        {
            throw new NotImplementedException();
        }

        public Habitacion SingleOrDefault(Expression<Func<Habitacion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        #region
        public bool Update(Habitacion entity)
        {
            bool result = false;

            try
            {
                using (unidad = new UnidadDeTrabajo<Habitacion>(context))
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
        #endregion
    }
}
