using A.Data;
using A.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace A.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    public AppDbContext Context { get; set; }

    public ProductController(AppDbContext dbContext)
    {
        // Context = new AppDbContext();
        // Context.Database.EnsureCreated();

        Context = dbContext;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var products = Context.Products.ToList();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var product = Context.Products.FirstOrDefault(x => x.Id == id);
        if (product is null)
        {
            return NotFound();
        }
    
        return Ok(product);
    }

    [HttpPost]
    public IActionResult Create([FromBody] ProductEntity product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Context.Products.Add(product);
        Context.SaveChanges();

        return Ok(product);
    }
    
    [HttpPut("{id}")]

    public IActionResult Update([FromRoute] int id, [FromBody] ProductEntity product)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var dbProduct = Context.Products.FirstOrDefault(a => a.Id == id);
        
        if (product is null)
        {
            return NotFound();
        }

        dbProduct.Id = product.Id;
        dbProduct.Description = product.Description;
        dbProduct.Name = product.Name;
        dbProduct.Stock = product.Stock;

        Context.SaveChanges();

        return Ok(dbProduct);

    }
    
    [HttpDelete("{id}")]

    public IActionResult Delete([FromRoute] int id)
    {
        
        var dbProduct = Context.Products.FirstOrDefault(x => x.Id == id);

        if (dbProduct is null)
        {
            return NotFound();
        }

        Context.Products.Remove(dbProduct);
        Context.SaveChanges();
        
        return Ok();


    }
}