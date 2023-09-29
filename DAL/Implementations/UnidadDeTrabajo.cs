using DAL.Implementations;
using DAL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo<T> : IDisposable where T : class
    {
        private readonly SistemaReservacionHotelContext context;

        public IDALGenerico<T> genericDAL;

        public UnidadDeTrabajo(SistemaReservacionHotelContext _context)
        {
            context = _context;
            genericDAL = new DALGenericoImpl<T>(context);
          
        }

        //Guarda cambios en la base de datos. Pueden brincar los "constraints".
        public bool Complete()
        {
            try
            {
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                string msj = e.Message;
                return false;
            }

        }

        //Desconectar la base de datos.
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
