using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using WebApplicationTestWeb.Models;



namespace WebApplicationTestWeb.Controllers
{
    public class SearchController : Controller
    {
        private readonly AppDbContext _context;

        public SearchController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("/search")]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return Json(new List<string>());
            }

            var results = await _context.Item
                .Where(item => EF.Functions.Like(item.Word, $"%{query}%"))
                .Select(item => item.Word)
                .ToListAsync();

            return Json(results);
        }
    }
}
