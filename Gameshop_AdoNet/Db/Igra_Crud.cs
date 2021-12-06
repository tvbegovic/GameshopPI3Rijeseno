using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Gameshop_AdoNet.Db
{
	public class Igra_Crud
	{
		public List<Game> GetAll()
		{
			var rezultat = new List<Game>();
			using(var conn = new SqlConnection(Properties.Settings.Default.connString))
            {
				conn.Open();
				var cmd = new SqlCommand("SELECT * FROM Game", conn);
				var dr = cmd.ExecuteReader();
				while(dr.Read())
                {
					var game = new Game();
					game.Id = (int)dr["id"];
					game.Title = (string) dr["title"];
					game.IdGenre = (int?)dr["idGenre"];
					game.IdPublisher = (int?)dr["idPublisher"];
					game.IdDeveloper = (int?)dr["idDeveloper"];
					game.Price = (decimal?)dr["price"];
					game.ReleaseDate = (DateTime?)dr["releaseDate"];
					game.Image = (string)dr["image"];
					rezultat.Add(game);
                }
				dr.Close();

            }
			
			return rezultat;
		}

		public Game GetById(int id)
		{
			Game rezultat = null;
			using (var conn = new SqlConnection(Properties.Settings.Default.connString))
			{
				conn.Open();
				var cmd = new SqlCommand("SELECT * FROM Game WHERE id = @id", conn);
				cmd.Parameters.AddWithValue("@id", id);
				var dr = cmd.ExecuteReader();
				if(dr.Read())
                {
					var game = new Game();
					game.Id = (int)dr["id"];
					game.Title = (string)dr["title"];
					game.IdGenre = (int?)dr["idGenre"];
					game.IdPublisher = (int?)dr["idPublisher"];
					game.IdDeveloper = (int?)dr["idDeveloper"];
					game.Price = (decimal?)dr["price"];
					game.ReleaseDate = (DateTime?)dr["releaseDate"];
					game.Image = (string)dr["image"];
					rezultat = game;
				}
				return rezultat;
			}			
		}

		public int Insert(Game igra)
		{
			
		}

		public int Update(Game igra)
		{
			
		}

		public void Delete(int id)
		{
			
		}
	}
	
}
