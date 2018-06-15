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
    public class CarrinhoController : Controller
    {

        [HttpGet("{idUsuario}")]
        public IActionResult GetCarrinho(int idUsuario)
        {
            try
            {

                var context = new postgresContext();
                var obj = context.CarrinhoCompras.Include(x => x.IdProdutoNavigation).Include(x => x.IdUsuarioNavigation).Where(x => x.IdUsuario == idUsuario && x.Finalizado == false).ToList();
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

        [HttpPost("ProdutoCarrinho")]
        public IActionResult ProdutoCarrinho([FromBody] CarrinhoCompras carrinho)
        {
            try
            {

                var context = new postgresContext();
                var carrinhoExiste = context.CarrinhoCompras.FirstOrDefault(x => x.IdProduto == carrinho.IdProduto && x.Finalizado == false && x.IdUsuario == carrinho.IdUsuario);
                var produto = context.Produtos.FirstOrDefault(x => x.IdProduto == carrinho.IdProduto);
                if (carrinhoExiste != null)
                {


                    carrinhoExiste.Quantidade = carrinho.Quantidade;
                    if (carrinhoExiste.Quantidade > produto.Quantidade)
                        throw new Exception($"Quantidade Máxima excedida! - Total Disponível: {produto.Quantidade}");

                    //produto.Quantidade -= carrinhoExiste.Quantidade;
                    //context.Produtos.Update(produto);
                    context.CarrinhoCompras.Update(carrinhoExiste);
                }
                else
                {
                    if (carrinho.Quantidade > produto.Quantidade)
                        throw new Exception($"Quantidade Máxima excedida! - Total Disponível: {produto.Quantidade}");

                   // produto.Quantidade -= carrinho.Quantidade;
                    //context.Produtos.Update(produto);

                    carrinho.Finalizado = false;
                    context.CarrinhoCompras.Add(carrinho);
                }
                context.SaveChanges();
                context.Dispose();

                return new ResultWithBody
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Body = "",
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
                    Body = ex.Message,
                };
            }

        }


        [HttpDelete("ProdutoCarrinho")]
        public IActionResult DeleteCarrinho(int idcarrinho, int idUsuario)
        {
            try
            {

                var context = new postgresContext();
                var carrinhoExiste = context.CarrinhoCompras.FirstOrDefault(x => x.IdCarrinhoCompras == idcarrinho && x.Finalizado == false && x.IdUsuario == idUsuario);
                
                if (carrinhoExiste != null)
                {
                    var produto = context.Produtos.FirstOrDefault(x => x.IdProduto == carrinhoExiste.IdProduto);
                    produto.Quantidade += carrinhoExiste.Quantidade;
                    context.Produtos.Update(produto);
                    context.CarrinhoCompras.Remove(carrinhoExiste);
                    context.SaveChanges();
                }


                context.Dispose();

                return new ResultWithBody
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Body = "Produto Apagado",
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

        [HttpPost("Finalizar")]
        public IActionResult FinlizarCarrinho([FromBody]Usuarios usuario)
        {
            try
            {

                var context = new postgresContext();
                var objs = context.CarrinhoCompras.Where(x => x.IdUsuario == usuario.IdUsuario && x.Finalizado == false).ToList();
                foreach (CarrinhoCompras c in objs)
                {
                    c.Finalizado = true;
                    context.CarrinhoCompras.Update(c);
                    var prod = context.Produtos.FirstOrDefault(a => a.IdProduto == c.IdProduto);
                    prod.Quantidade -= c.Quantidade;
                    context.Produtos.Update(prod);
                }
                context.SaveChanges();
                context.Dispose();

                return new ResultWithBody
                {
                    Code = System.Net.HttpStatusCode.OK,
                    Body = "Compra Realizada!",
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