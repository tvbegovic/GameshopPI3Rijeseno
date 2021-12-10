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
			using (var conn = new SqlConnection(Properties.Settings.Default.connString))
            {
				conn.Open();
				var cmd = new SqlCommand(
					@"INSERT INTO [Game]([title],[idGenre],[idPublisher],[price],[idDeveloper],
						[releaseDate],[image]) VALUES
					(@title, @idGenre, @idPublisher, @price, @idDeveloper, @releaseDate, @image)",
					conn);
				cmd.Parameters.AddWithValue("@title", igra.Title);
				cmd.Parameters.AddWithValue("@idGenre", igra.IdGenre);
				cmd.Parameters.AddWithValue("@idPublisher", igra.IdPublisher);
				cmd.Parameters.AddWithValue("@price", igra.Price);
				cmd.Parameters.AddWithValue("@idDeveloper", igra.IdDeveloper);
				cmd.Parameters.AddWithValue("@releaseDate", igra.ReleaseDate);
				cmd.Parameters.AddWithValue("@image", igra.Image);
				cmd.ExecuteNonQuery();
				return 1;
			}
		}

		public int Update(Game igra)
		{
			using (var conn = new SqlConnection(Properties.Settings.Default.connString))
            {
				conn.Open();
				var cmd = new SqlCommand(
				  @"UPDATE [Game]
					   SET [title] = @title
						  ,[idGenre] = @idGenre
						  ,[idPublisher] = @idPublisher
						  ,[price] = @price
						  ,[idDeveloper] = @idDeveloper
						  ,[releaseDate] = @releaseDate
						  ,[image] = @image
					 WHERE id = @id", conn);
				cmd.Parameters.AddWithValue("@title", igra.Title);
				cmd.Parameters.AddWithValue("@idGenre", igra.IdGenre);
				cmd.Parameters.AddWithValue("@idPublisher", igra.IdPublisher);
				cmd.Parameters.AddWithValue("@price", igra.Price);
				cmd.Parameters.AddWithValue("@idDeveloper", igra.IdDeveloper);
				cmd.Parameters.AddWithValue("@releaseDate", igra.ReleaseDate);
				cmd.Parameters.AddWithValue("@image", igra.Image);
				cmd.Parameters.AddWithValue("@id", igra.Id);
				return cmd.ExecuteNonQuery();
			}
		}

		public void Delete(int id)
		{
			using (var conn = new SqlConnection(Properties.Settings.Default.connString))
            {
				conn.Open();
				var cmd = new SqlCommand("DELETE FROM Game WHERE id = @id", conn);
				cmd.Parameters.AddWithValue("@id", id);
				cmd.ExecuteNonQuery();
			}
		}
	}
	
}
