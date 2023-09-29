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
    public class ReservacioneDALImpl : IReservacionesDAL
    {
        SistemaReservacionHotelContext context;

        //Constructor
        public ReservacioneDALImpl() { 
            context = new SistemaReservacionHotelContext();
        }

        public ReservacioneDALImpl(SistemaReservacionHotelContext sistemaContext)
        {
            this.context = sistemaContext;
        }

        public bool Add(Reservacione entity)
        {
            try
            {
                using (UnidadDeTrabajo<Reservacione> unidad = new UnidadDeTrabajo<Reservacione>(context))
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

        public void AddRange(IEnumerable<Reservacione> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservacione> Find(Expression<Func<Reservacione, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Reservacione Get(int ReservacionId)
        {
            try
            {
                Reservacione reservacion;
                using (UnidadDeTrabajo<Reservacione> unidad = new UnidadDeTrabajo<Reservacione>(context))
                {
                    reservacion = unidad.genericDAL.Get(ReservacionId);
                }
                return reservacion;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Reservacione> GetAll()
        {
            try
            {
                IEnumerable<Reservacione> reservaciones;
                using (UnidadDeTrabajo<Reservacione> unidad = new UnidadDeTrabajo<Reservacione>(context))
                {
                    reservaciones = unidad.genericDAL.GetAll();
                }
                return reservaciones;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Reservacione entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Reservacione> unidad = new UnidadDeTrabajo<Reservacione>(context))
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

        public void RemoveRange(IEnumerable<Reservacione> entities)
        {
            throw new NotImplementedException();
        }

        public Reservacione SingleOrDefault(Expression<Func<Reservacione, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Reservacione reservacion)
        {
            bool result = false;

            try
            {
                using (UnidadDeTrabajo<Reservacione> unidad = new UnidadDeTrabajo<Reservacione>(context))
                {
                    unidad.genericDAL.Update(reservacion);
                    result = unidad.Complete();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return result;
        }
    }
}
