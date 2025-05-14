using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Product_Inventory.Models;

namespace Product_Inventory.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly AppDbContext cs;
        public ProductController(AppDbContext c)
        {
            cs = c;
        }
        //retrive data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<product>>> getemployees()
        {
            return await cs.product.ToListAsync();
        }
        //get by id
        [HttpGet("{id}")]
        public async Task<ActionResult<product>> GetProductById(int id)
        {
            var product = await cs.product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }
        //to insert data
        [HttpPost]
        public async Task<ActionResult<product>> CreateProduct([FromBody] product product)
        {
            if (product == null)
            {
                return BadRequest("Product data is null.");
            }

            cs.product.Add(product);
            await cs.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProductById), new { id = product.id }, product);
        }
        //update product
        [HttpPut("{id}")]
        public async Task<IActionResult> updateproduct(int id, [FromBody] product updatedproduct)
        {
            if (id != updatedproduct.id)
            {
                return BadRequest("product is mismatch");
            }
            var existingproduct = await cs.product.FindAsync(id);
            if (existingproduct == null)
            {
                return NotFound("Product not found");
            }
            existingproduct.name = updatedproduct.name;
            existingproduct.price = updatedproduct.price;
            existingproduct.category = updatedproduct.category;
            existingproduct.quantity = updatedproduct.quantity;
            try
            {
                await cs.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "A concurrency error occurred");
            }
            return NoContent();
        }
        //delete employee
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteemployee(int id)
        {
            var pro = await cs.product.FindAsync(id);
            if (pro == null)
            {
                return NotFound("Product not found");
            }
            cs.product.Remove(pro);
            await cs.SaveChangesAsync();
            return NoContent();
        }
        //sorting products
        [HttpGet("sortbyprice")]
        public async Task<ActionResult<IEnumerable<product>>> sortproducts()
        {
            var products = await cs.product.OrderByDescending(e => e.price).ToListAsync();
            return Ok(products);

        }
        //filtering
        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<product>>> filterproducts()
        {
            return await cs.product.Where(e => e.quantity > 10).ToListAsync();
        }

        //product exist or not 
        [HttpGet("exisiting/{id}")]
        public async Task<ActionResult<product>> existingproduct(int id)
        {
            var pro = await cs.product.FindAsync(id);
            if (pro == null)
            {
                return NotFound("Product not found");
            }
            return CreatedAtAction(nameof(GetProductById), new { id = pro.id }, pro);
        }
    }
}

