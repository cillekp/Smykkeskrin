using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Smykkeskrin.model;
using Smykkeskrin.Model;
using Smykkeskrin.Pages;
using Smykkeskrin.model;

namespace Smykkeskrin.Repo;

public class JewleryRepository : IJewleryRepository
{
    private readonly string _connectionstring;
    public JewleryRepository(IConfiguration configuration)
    {
        _connectionstring = configuration.GetConnectionString("DefaultConnection");
    }
    public void AddJewlery(Jewlery jewlery)
    {
        throw new NotImplementedException();
    }

    public void DeleteJewlery(Jewlery jewlery)
    {
        throw new NotImplementedException();
    }

    public void UpdateJewlery(Jewlery jewlery)
    {
        throw new NotImplementedException();
    }

    public Jewlery GetJewlery(string jewleryId)
    {
        throw new NotImplementedException();
    }

    public Jewlery GetJewleryById(string jewleryId)
    {
        throw new NotImplementedException();
    }
    
    public List<Jewlery> GetJewleries()
    {
        var Jewleries = new List<Jewlery>();
        string sql = "SELECT jewleryId, Name, Material, Brand, Price, isActive, imgPth,type FROM Jewlery";
       
        using (SqlConnection connection = new SqlConnection(_connectionstring))
        {
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Jewlery jewlery = new Jewlery()
                        {
                            Jewleryid = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Material = reader.GetString(2),
                            Brand = reader.GetString(3),
                            Price = reader.GetDouble(4),
                            IsActive = reader.GetBoolean(5),
                            ImgPth= reader.GetString(6),
                            Type = (Jewlery.JewleryType)reader.GetInt32(7),
                        };
                        Jewleries.Add(jewlery);
                    }
                }
            }
        }
        return Jewleries;
    }
}