using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Backendy.Models;

namespace backendy_v2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RandomItemController : Controller
    {
        private readonly backendDBContext _dbContext;
        private readonly Random _random;

        public RandomItemController(backendDBContext dbContext)
        {
            _dbContext = dbContext;
            _random = new Random();
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetRandomItem()
        {
            double randomValue = _random.NextDouble();
            Console.WriteLine(randomValue);

            if (randomValue < 0.9)
            {
                var treasures = await _dbContext.treasure_table.ToListAsync();
                if (treasures.Any())
                {
                    int randomIndex = _random.Next(0, treasures.Count);
                    return treasures[randomIndex];
                }
                else
                    return NotFound("No treasures found.");
            }
            else
            {
                var fishes = await _dbContext.fish_table.ToListAsync();
                if (fishes.Any())
                {
                    int randomIndex = _random.Next(0, fishes.Count);
                    return fishes[randomIndex];
                }
                else
                    return NotFound("No fishes found.");
            }
        }

        [HttpGet("{counting}")]
        public async Task<ActionResult<List<object>>> GetRandomItems(int counting)
        {
            if (counting <= 0)
                return BadRequest("Count must be a positive number.");

            var randomItems = new List<object>();

            for (int i = 0; i < counting; i++)
            {
                double randomValue = _random.NextDouble();
                Console.WriteLine(randomValue);

                if (randomValue < 0.9)
                {
                    var treasures = await _dbContext.treasure_table.ToListAsync();
                    if (treasures.Any())
                    {
                        int randomIndex = _random.Next(0, treasures.Count);
                        randomItems.Add(treasures[randomIndex]);
                    }
                }
                else
                {
                    var fishes = await _dbContext.fish_table.ToListAsync();
                    if (fishes.Any())
                    {
                        int randomIndex = _random.Next(0, fishes.Count);
                        randomItems.Add(fishes[randomIndex]);
                    }
                }
            }

            if (randomItems.Any())
                return randomItems;
            else
                return NotFound("No items found.");
        }
    }
}
