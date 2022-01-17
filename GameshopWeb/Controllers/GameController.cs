using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameshopWeb.Db;
using Microsoft.EntityFrameworkCore;

namespace GameshopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private MyDbContext context;
        public GameController(MyDbContext context)
        {
            this.context = context;
        }

        [HttpGet("genres")]
        public List<Genre> GetGenres()
        {
            return context.Genres.ToList();
        }

        [HttpGet("companies")]
        public List<Company> GetCompanies()
        {
            return context.Companies.ToList();
        }

        [HttpGet("bygenre/{id}")]
        public List<Game> GetByGenre(int id)
        {
            return context.Games.Where(g => g.IdGenre == id).ToList();
        }

        [HttpGet("bycompany/{id}")]
        public List<Game> GetByCompany(int id)
        {
            return context.Games.Where(g => g.IdDeveloper == id || g.IdPublisher == id).ToList();
        }

        [HttpGet("search/{query}")]
        public List<Game> Search(string query)
        {
            return context.Games.Include(g => g.Genre).Include(g => g.Developer)
                .Include(g => g.Publisher)
                .Where(g => g.Title.Contains(query) 
                    || g.Genre.Name.Contains(query)
                    || g.Developer.Name.Contains(query)
                    || g.Publisher.Name.Contains(query)
                    )
                .ToList();
        }

        [HttpGet("listModel")]
        public ListModel GetListModel()
        {
            return new ListModel
            {
                Games = context.Games.ToList(),
                Genres = context.Genres.ToList(),
                Companies = context.Companies.ToList()
            };
        }

    }

    public class ListModel
    {
        public List<Game> Games { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Company> Companies { get; set; }
    }
}
