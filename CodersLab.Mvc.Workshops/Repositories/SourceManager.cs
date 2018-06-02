using CodersLab.Mvc.Workshops.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CodersLab.Mvc.Workshops.Repositories
{
	public class SourceManager
	{
		private const string connectionString = "Server=.;Database=CodersLab;Integrated Security=true;";

		public List<PersonModel> Get()
		{
			var sql = "SELECT * FROM dbo.People";

			var modelList = new List<PersonModel>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				try
				{
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						var reader = command.ExecuteReader();

						while (reader.Read())
						{
							var model = new PersonModel();

							model.Id = reader.GetInt32(0);
							model.FirstName = reader.GetString(1);
							model.LastName = reader.GetString(2);
							model.Phone = reader.GetString(3);
							model.Email = reader.GetString(4);
							model.Created = reader.GetDateTime(5);
							model.Updated = reader.GetDateTime(6);

							modelList.Add(model);
						}
					}

					return modelList;
				}
				catch (Exception ex)
				{
					throw new Exception($"Error: {ex}");
				}
			}
		}

		public PersonModel GetById(int id)
		{
			var model = new PersonModel();

			var sql = $"SELECT * FROM dbo.People WHERE Id = {id}";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				try
				{
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						var reader = command.ExecuteReader();

						while (reader.Read())
						{
							model.Id = reader.GetInt32(0);
							model.FirstName = reader.GetString(1);
							model.LastName = reader.GetString(2);
							model.Phone = reader.GetString(3);
							model.Email = reader.GetString(4);
							model.Created = reader.GetDateTime(5);
							model.Updated = reader.GetDateTime(6);
						}
					}

					return model;
				}
				catch (Exception ex)
				{
					throw new Exception($"Error: {ex}");
				}
			}
		}

		public void Add(PersonModel model)
		{
			var sqlBuilder = new StringBuilder();
			sqlBuilder.Append($"INSERT INTO dbo.People (FirstName, LastName, Phone, Email, Created, Updated) ");
			sqlBuilder.Append($"VALUES ('{model.FirstName}', '{model.LastName}', '{model.Phone}', '{model.Email}', '{model.Created}', '{model.Updated}')");

			var sql = sqlBuilder.ToString();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				try
				{
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						command.ExecuteNonQuery();
					}
				}
				catch (Exception ex)
				{
					throw new Exception($"Error: {ex}");
				}
			}
		}

		public void Update(PersonModel model)
		{
			var sqlBuilder = new StringBuilder();
			sqlBuilder.Append($"UPDATE dbo.People ");
			sqlBuilder.Append($"SET FirstName = '{model.FirstName}', LastName = '{model.LastName}', Phone = '{model.Phone}', Email = '{model.Email}', Updated = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' ");
			sqlBuilder.Append($"WHERE Id = '{model.Id}'");

			var sql = sqlBuilder.ToString();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				try
				{
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						command.ExecuteNonQuery();
					}
				}
				catch (Exception ex)
				{
					throw new Exception($"Error: {ex}");
				}
			}
		}

		public void Remove(int id)
		{
			var sql = $"DELETE FROM dbo.People WHERE Id = {id}";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				try
				{
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						command.ExecuteNonQuery();
					}
				}
				catch (Exception ex)
				{
					throw new Exception($"Error: {ex}");
				}
			}
		}
	}
}
