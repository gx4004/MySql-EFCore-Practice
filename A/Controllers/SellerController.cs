using A.Data;
using A.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace A.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SellerController : Controller
{
    public AppDbContext Context { get; set; }

    public SellerController(AppDbContext dbContext)
    {
        // Context = new AppDbContext();
        // Context.Database.EnsureCreated();

        Context = dbContext;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var sellers = Context.Sellers.ToList();

        return Ok(sellers);
    }

    [HttpGet("{id}")]
    public IActionResult GetSeller(int id)
    {
        var seller = Context.Sellers.FirstOrDefault(a => a.Id == id);
        if (seller is null)
        {
            return NotFound("Seller is not found");
        }

        return Ok(seller);
    }

    [HttpPost]
    public IActionResult Create([FromBody] SellerEntity seller)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        Context.Sellers.Add(seller);
        Context.SaveChanges();

        return Ok(seller);

    }

    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] SellerEntity seller)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        var dbSeller = Context.Sellers.FirstOrDefault(a => a.Id == id);

        if (seller is null)
        {
            return NotFound("seller not found");
        }

        dbSeller.Id = seller.Id;
        dbSeller.Name = seller.Name;
        dbSeller.Surname = seller.Surname;

        Context.SaveChanges();

        return Ok();
    }

    [HttpDelete("{id}")]

    public IActionResult Delete([FromRoute] int id)
    {
        var seller = Context.Sellers.FirstOrDefault(a => a.Id == id);

        if (seller is null)
        {
            return NotFound();
        }

        Context.Sellers.Remove(seller);
        Context.SaveChanges();

        return Ok();
    }



}