using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Web.Util;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        [HttpPost("Logar")]
        public IActionResult Logar([FromBody]Usuarios u)
        {
            try
            {

                var context = new postgresContext();
                var usuario = context.Usuarios.Where(x => x.Email == u.Email).FirstOrDefault();
                context.Dispose();
                if (usuario == null || usuario.Senha != u.Senha)
                {
                    throw new Exception("Senha ou usuário incorretos.");
                }
                usuario.Senha = "";
                return new ObjectResult(usuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[error] ConfigController - GetFurnaces - {0} - {1}",
                    ex.Message,
                    ex.StackTrace.Replace(Environment.NewLine, " "));
                return new ResultWithBody
                {
                    Code = System.Net.HttpStatusCode.Unauthorized,
                    Body = ex.Message,
                };
            }
        }

        [HttpPut("")]
        public IActionResult CriarUsuario([FromBody]Usuarios u)
        {
            try
            {

                var context = new postgresContext();
                context.Usuarios.Add(u);
                context.SaveChanges();
                context.Dispose();

                return new ResultWithBody
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Body = "Inclusão de Usuário - Usuário Inserido",
                };


            }
            catch (Exception ex)
            {
                Console.WriteLine("[error] ConfigController - GetFurnaces - {0} - {1}",
                    ex.Message,
                    ex.StackTrace.Replace(Environment.NewLine, " "));
                return new ResultWithBody
                {
                    Code = System.Net.HttpStatusCode.Unauthorized,
                    Body = ex.Message,
                };
            }
        }

        [HttpPost("")]
        public IActionResult EditarUsuario([FromBody]Usuarios u)
        {
            try
            {

                var context = new postgresContext();
                u.IdTipoUsuarioNavigation = null;
                u.Senha = context.Usuarios.FirstOrDefault(x => x.IdUsuario == u.IdUsuario).Senha;
                context.Usuarios.Update(u);
                context.SaveChanges();
                context.Dispose();

                return new ResultWithBody
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Body = "Alteração de Usuário - Usuário Alterado",
                };


            }
            catch (Exception ex)
            {
                Console.WriteLine("[error] ConfigController - GetFurnaces - {0} - {1}",
                    ex.Message,
                    ex.StackTrace.Replace(Environment.NewLine, " "));
                return new ResultWithBody
                {
                    Code = System.Net.HttpStatusCode.Unauthorized,
                    Body = ex.Message,
                };
            }
        }


        [HttpDelete("")]
        public IActionResult DeletarUsuario(int idUsuario)
        {
            try
            {

                var context = new postgresContext();
                var usuario = context.Usuarios.FirstOrDefault(x => x.IdUsuario == idUsuario);
                context.Remove(usuario);
                context.SaveChanges();
                context.Dispose();

                return new ResultWithBody
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Body = "Exclusão de Usuário - Usuário Excluído",
                };


            }
            catch (Exception ex)
            {
                Console.WriteLine("[error] ConfigController - GetFurnaces - {0} - {1}",
                    ex.Message,
                    ex.StackTrace.Replace(Environment.NewLine, " "));
                return new ResultWithBody
                {
                    Code = System.Net.HttpStatusCode.Unauthorized,
                    Body = ex.Message,
                };
            }
        }


        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            try
            {

                var context = new postgresContext();
                var usrs = context.Usuarios.Include(x=>x.IdTipoUsuarioNavigation).ToList();
                context.Dispose();
                if(usrs!=null)
                   usrs = usrs.Select(e=>{
                    var ret = e;
                    e.Senha = "";
                    return e;
                }).ToList();

                return new ObjectResult(usrs);


            }
            catch (Exception ex)
            {
                Console.WriteLine("[error] ConfigController - GetFurnaces - {0} - {1}",
                    ex.Message,
                    ex.StackTrace.Replace(Environment.NewLine, " "));
                return new ResultWithBody
                {
                    Code = System.Net.HttpStatusCode.Unauthorized,
                    Body = ex.Message,
                };
            }
        }


    }
}