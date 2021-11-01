using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste.Loja.Domain.Core.Entities;
using Teste.Loja.Infra.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teste.Loja.API.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly MercadoContext _context;

        public ProdutoController(MercadoContext context)
        {
            _context = context;
        }



        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var sabonete = new Produto() { Nome = "Sabonete", ValorUnitario = 1.50M };

            var itemSabonete = new ItemPedido() { Quantidade = 3, Produto = sabonete };

            var pedido = new Pedido();

            pedido.Itens.Add(itemSabonete);

            _context.Pedidos.Add(pedido);

            _context.SaveChanges();
                                   
            return null;
        }


        // GET: api/values
        [HttpGet]
        [Route("{id}")]
        public Produto Delete([FromRoute] Guid id)
        {

            var produto = _context.Produtos.Include(x => x.Itens).Single(x => x.Id == id);

                       

            return null;
            
        }



    }
}
