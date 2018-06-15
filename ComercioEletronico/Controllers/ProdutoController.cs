using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Web.Util;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {

        [HttpPut("")]
        public IActionResult AdicionarProduto([FromBody]Produtos p)
        {
            try
            {

                var context = new postgresContext();
                context.Add<Produtos>(p);
                context.SaveChanges();
                context.Dispose();

                return new ResultWithBody
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Body = "Inserção de Produto - Produto Inserido",
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("[error] ConfigController - GetFurnaces - {0} - {1}",
                    ex.Message,
                    ex.StackTrace.Replace(Environment.NewLine, " "));
                return new ResultWithBody
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Body = "GetFurnaces - Fatal error retrieving furnaces configuration",
                };
            }

        }

        [HttpPost("")]
        public IActionResult EditarProduto([FromBody]Produtos p)
        {
            try
            {

                var context = new postgresContext();
                context.Produtos.Update(p);
                context.SaveChanges();
                context.Dispose();

                return new ResultWithBody
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Body = "Edição de Produto - Produto Editado!",
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("[error] ConfigController - GetFurnaces - {0} - {1}",
                    ex.Message,
                    ex.StackTrace.Replace(Environment.NewLine, " "));
                return new ResultWithBody
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Body = "GetFurnaces - Fatal error retrieving furnaces configuration",
                };
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetProduto(int id)
        {
            try
            {

                var context = new postgresContext();
                var obj = context.Produtos.FirstOrDefault(x=> x.IdProduto == id);
                context.Dispose();

                return new ObjectResult(obj);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("[error] ConfigController - GetFurnaces - {0} - {1}",
                    ex.Message,
                    ex.StackTrace.Replace(Environment.NewLine, " "));
                return new ResultWithBody
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Body = "GetFurnaces - Fatal error retrieving furnaces configuration",
                };
            }

        }


        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            try
            {

                var context = new postgresContext();
                var objs = context.Produtos.ToList();
                context.Dispose();

                return new ObjectResult(objs);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[error] ConfigController - GetFurnaces - {0} - {1}",
                    ex.Message,
                    ex.StackTrace.Replace(Environment.NewLine, " "));
                return new ResultWithBody
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Body = "GetFurnaces - Fatal error retrieving furnaces configuration",
                };
            }

        }

        [HttpGet("Comentarios/{idproduto}")]
        public IActionResult GetComentarios(int idproduto)
        {
            try
            {

                var context = new postgresContext();
                var objs = context.Comentarios.Include(x=>x.IdUsuarioNavigation).Where(x => x.IdProduto == idproduto).ToList();
                context.Dispose();

                return new ObjectResult(objs);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[error] ConfigController - GetFurnaces - {0} - {1}",
                    ex.Message,
                    ex.StackTrace.Replace(Environment.NewLine, " "));
                return new ResultWithBody
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Body = "GetFurnaces - Fatal error retrieving furnaces configuration",
                };
            }

        }

       
        [HttpPost("Comentario")]
        public IActionResult Comentarios([FromBody] Comentarios comentario)
        {
            try
            {

                var context = new postgresContext();
                context.Comentarios.Add(comentario);
                context.SaveChanges();
                context.Dispose();

                return new ResultWithBody
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Body = "Inserção de Cometarios - Comentario Inserido!",
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("[error] ConfigController - GetFurnaces - {0} - {1}",
                    ex.Message,
                    ex.StackTrace.Replace(Environment.NewLine, " "));
                return new ResultWithBody
                {
                    Code = System.Net.HttpStatusCode.InternalServerError,
                    Body = "GetFurnaces - Fatal error retrieving furnaces configuration",
                };
            }

        }

       

    }
}