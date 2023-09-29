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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioDAL usuarioDAL;

        public UsuarioController()
        {
            usuarioDAL = new UsuarioDALImpl(new Entities.SistemaReservacionHotelContext());
        }

        UsuarioModel Convertir(Usuario usuario)
        {
            return new UsuarioModel
            {
                Idusuario = usuario.Idusuario,
                PrimerNombre = usuario.PrimerNombre,
                SegundoNombre = usuario.SegundoNombre,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido,
                Username = usuario.Username,
                Contrasena = usuario.Contrasena,
                Idrol = usuario.Idrol
            };
        }

        Usuario Convertir(UsuarioModel usuario)
        {
            return new Usuario
            {
                Idusuario = usuario.Idusuario,
                PrimerNombre = usuario.PrimerNombre,
                SegundoNombre = usuario.SegundoNombre,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido,
                Username = usuario.Username,
                Contrasena = usuario.Contrasena,
                Idrol = usuario.Idrol
            };
        }

        // GET: api/<UsuarioController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Usuario> usuarios;
            usuarios = usuarioDAL.GetAll();

            List<UsuarioModel> result = new List<UsuarioModel>();
            foreach (Usuario usuario in usuarios)
            {
                result.Add(Convertir(usuario));
            }
            return new JsonResult(result);
        }

        // GET api/<UsuarioController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Usuario usuario = usuarioDAL.Get(id);

            UsuarioModel model = Convertir(usuario);

            return new JsonResult(model);
        }

        // POST api/<UsuarioController>
        [HttpPost]
        public JsonResult Post([FromBody] UsuarioModel usuario)
        {
            try
            {
                Usuario nuevo = Convertir(usuario);
                usuarioDAL.Add(nuevo);

                return new JsonResult(Convertir(nuevo));
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut]
        public JsonResult Put(int id, [FromBody] UsuarioModel usuario)
        {
            try
            {
                usuarioDAL.Update(Convertir(usuario));
                return new JsonResult(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                Usuario usuario = new Usuario { Idusuario = id };

                usuarioDAL.Remove(usuario);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
