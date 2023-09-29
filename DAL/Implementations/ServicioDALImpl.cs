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
    public class ServicioDALImpl : IServicioDAL
    {
        SistemaReservacionHotelContext context;

        //Constructor
        public ServicioDALImpl()
        {
            context = new SistemaReservacionHotelContext();
        }

        public ServicioDALImpl(SistemaReservacionHotelContext sistemaContext)
        {
            this.context = sistemaContext;
        }

        public bool Add(Servicio entity)
        {
            try
            {
                using (UnidadDeTrabajo<Servicio> unidad = new UnidadDeTrabajo<Servicio>(context))
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

        public void AddRange(IEnumerable<Servicio> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Servicio> Find(Expression<Func<Servicio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Servicio Get(int ServicioId)
        {
            try
            {
                Servicio servicio;
                using (UnidadDeTrabajo<Servicio> unidad = new UnidadDeTrabajo<Servicio>(context))
                {
                    servicio = unidad.genericDAL.Get(ServicioId);
                }
                return servicio;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Servicio> GetAll()
        {
            try
            {
                IEnumerable<Servicio> servicios;
                using (UnidadDeTrabajo<Servicio> unidad = new UnidadDeTrabajo<Servicio>(context))
                {
                    servicios = unidad.genericDAL.GetAll();
                }
                return servicios;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Remove(Servicio entity)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Servicio> unidad = new UnidadDeTrabajo<Servicio>(context))
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

        public void RemoveRange(IEnumerable<Servicio> entities)
        {
            throw new NotImplementedException();
        }

        public Servicio SingleOrDefault(Expression<Func<Servicio, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Servicio servicio)
        {
            bool result = false;
            try
            {
                using (UnidadDeTrabajo<Servicio> unidad = new UnidadDeTrabajo<Servicio>(context))
                {
                    unidad.genericDAL.Update(servicio);
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
