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

        [HttpGet("editModel/{id}")]
        public EditModel GetEditModel(int id)
        {
            var editModel = new EditModel
            {
                Genres = context.Genres.ToList(),
                Companies = context.Companies.ToList()
            };
            if(id > 0)
            {
                editModel.Game = context.Games.FirstOrDefault(g => g.Id == id);
            }
            else
            {
                editModel.Game = new Game();
            }
            return editModel;
        }

        [HttpPost("")]
        public Game Create(Game game)
        {
            context.Games.Add(game);
            context.SaveChanges();
            return game;
        }

        [HttpPut("")]
        public Game Update(Game game)
        {
            context.Games.Update(game);
            context.SaveChanges();
            return game;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //EF core bez sql-a - brisanje
            //Nedostatak - jedno viška čitanje iz baze (SELECT)
            /*var game = context.Games.FirstOrDefault(g => g.Id == id);
            context.Remove(game);
            context.SaveChanges();*/

            //bolje i efikasnije - jedan poziv baze
            context.Database.ExecuteSqlInterpolated
                ($"DELETE FROM Game WHERE id = {id}");

        }

    }

    public class ListModel
    {
        public List<Game> Games { get; set; }
        public List<Genre> Genres { get; set; }
        public List<Company> Companies { get; set; }
    }

    public class EditModel
    {
        public List<Genre> Genres { get; set; }
        public List<Company> Companies { get; set; }
        public Game Game { get; set; }
    }
}
