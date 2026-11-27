using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Smykkeskrin.model;

namespace Smykkeskrin.Repo
{
    public class FeedRepository : IFeedRepository
    {
        private readonly string _connectionString;

        public FeedRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SmykkeskrinDB");
        }

        public IEnumerable<Feed> GetAll()
        {
            var feeds = new List<Feed>();
            // HER ER ÆNDRINGEN: Tilføjet INNER JOIN og u.Username
            string query = @"
                SELECT f.postId, f.Description, f.CreatedOn, f.UserId, u.Username 
                FROM feed f
                INNER JOIN Users u ON f.UserId = u.Id
                ORDER BY f.CreatedOn DESC";

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            feeds.Add(new Feed
                            {
                                postId = reader.GetInt32(reader.GetOrdinal("postId")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? string.Empty : reader.GetString(reader.GetOrdinal("Description")),
                                CreatedOn = reader.GetDateTime(reader.GetOrdinal("CreatedOn")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                // HER ER ÆNDRINGEN: Læser Username ind i modellen
                                UserName = reader.IsDBNull(reader.GetOrdinal("Username")) ? "Ukendt" : reader.GetString(reader.GetOrdinal("Username"))
                            });
                        }
                    }
                }
            }
            return feeds;
        }

        public Feed GetById(int id)
        {
            Feed feed = null;
            // HER ER ÆNDRINGEN OGSÅ: Tilføjet INNER JOIN her for en sikkerheds skyld
            string query = @"
                SELECT f.postId, f.Description, f.CreatedOn, f.UserId, u.Username 
                FROM feed f
                INNER JOIN Users u ON f.UserId = u.Id
                WHERE f.postId = @postId";

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@postId", id);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            feed = new Feed
                            {
                                postId = reader.GetInt32(reader.GetOrdinal("postId")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? string.Empty : reader.GetString(reader.GetOrdinal("Description")),
                                CreatedOn = reader.GetDateTime(reader.GetOrdinal("CreatedOn")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                UserName = reader.IsDBNull(reader.GetOrdinal("Username")) ? "Ukendt" : reader.GetString(reader.GetOrdinal("Username"))
                            };
                        }
                    }
                }
            }
            return feed;
        }

        public Feed Add(Feed feed)
        {
            if (feed.CreatedOn == default)
            {
                feed.CreatedOn = DateTime.Now;
            }

            string query = "INSERT INTO feed (Description, CreatedOn, UserId) OUTPUT INSERTED.postId VALUES (@Description, @CreatedOn, @UserId)";

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Description", (object)feed.Description ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedOn", feed.CreatedOn);
                    command.Parameters.AddWithValue("@UserId", feed.UserId);

                    connection.Open();
                    int newId = (int)command.ExecuteScalar();
                    feed.postId = newId;
                }
            }
            return feed;
        }

        public void Update(Feed feed)
        {
            string query = "UPDATE feed SET Description = @Description, CreatedOn = @CreatedOn, UserId = @UserId WHERE postId = @postId";

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@postId", feed.postId);
                    command.Parameters.AddWithValue("@Description", (object)feed.Description ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CreatedOn", feed.CreatedOn);
                    command.Parameters.AddWithValue("@UserId", feed.UserId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM feed WHERE postId = @postId";

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@postId", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}