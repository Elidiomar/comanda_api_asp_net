using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Comanda.Domain.Models.Catalog;
using Comanda.Infra.Data.Context;
using Microsoft.AspNetCore.Authorization;

namespace Comanda.Service.API.Controllers
{

    public class ProductController : BaseApiController
    {
        private readonly ComandaDbContext _context;

        public ProductController(ComandaDbContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            //_context.Products.RemoveRange(_context.Products);
            //_context.SaveChanges();

            //IList<Product> products = new List<Product>();
            //products.Add(new Product { Name = "Arroz", Image = "defalt.png" , Description= "Arroz Tio João", Price = 123.45M, CategoryCod=1, Control=DateTime.Now});
            //products.Add(new Product { Name = "Feijão", Image = "defalt.png" , Description= "Feijão carioca", Price = 23.30M, CategoryCod=2, Control=DateTime.Now});
            //products.Add(new Product { Name = "Maionese", Image = "defalt.png" , Description= "Tomates frescos, plantados com exclusivas sementes Heinz, cuidadosamente cultivados ao sol são combinados com nossa paixão e conhecimento para proporcionar um sabor único a esta receita.", Price = 123.45M, CategoryCod=1, Control=DateTime.Now});
            //products.Add(new Product { Name = "Macarrão", Image = "defalt.png" , Description= "Ao dente", Price = 10.20M, CategoryCod=3, Control=DateTime.Now});
            //products.Add(new Product { Name = "Alface", Image = "defalt.png" , Description= "Americana", Price = 3.45M, CategoryCod=1, Control=DateTime.Now});
            //products.Add(new Product { Name = "Feijoada", Image = "defalt.png" , Description= "Completa", Price = 33.00M, CategoryCod=2, Control=DateTime.Now});
            //products.Add(new Product { Name = "Carne", Image = "defalt.png" , Description= "Bovina", Price = 5.78M, CategoryCod=1, Control=DateTime.Now});
            
            //_context.Products.AddRange(products);
            //_context.SaveChanges();

            return _context.Products.ToList();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute] Guid id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
            product.Control = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        private bool ProductExists(Guid id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}