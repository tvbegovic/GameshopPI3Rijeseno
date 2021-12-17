﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameshopWeb.Db;

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

        [HttpGet("bygenre")]
        public List<Game> GetByGenre(int id)
        {
            return context.Games.Where(g => g.IdGenre == id).ToList();
        }

    }
}
