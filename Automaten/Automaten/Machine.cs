﻿

using Npgsql;
using System.Data.SqlClient;

namespace Automaten
{
    internal class Machine : IMachine, IMachineAdmin
    {
        
        private List<Item> items { get; set; } = new List<Item>();


        string connectionString = "Host=127.0.0.1;Port=5432;Database=postgres;Username=postgres;Password=Kode1234!";

        public List<Item> GetAllItems()
        {
            return items;
        }

        public void RemoveOneAmount(int slot)
        {
            items[slot].Amount = (byte)(items[slot].Amount - Convert.ToByte(1));
            DecrementOneDatabase(items[slot].Id);
            FetchProducts();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public Item ReadItem(byte slot) { 
            return items[slot]; 
        }

        public void UpdateItem(byte slot, Item item)
        {
            items[slot] = item;
        } 

        public void DeleteItem(byte slot)
        {
            items.RemoveAt(slot);
        }

        public void UpdateAmount(byte slot, byte amount) {
            items[slot].Amount = amount;
        }

        private void FetchProducts()
        {
            NpgsqlConnection _dbConnection = new NpgsqlConnection(connectionString);
            items.Clear();

            _dbConnection.Open();
            using (NpgsqlConnection connection = _dbConnection)
            {
                try
                {
                    using (NpgsqlCommand command = new NpgsqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT * FROM read_items_automat($1)";
                        command.Parameters.Add(new NpgsqlParameter() { Value = 1 });

                        using (NpgsqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                items.Add(new Item(reader.GetInt32(0), reader.GetString(1), (byte)reader.GetInt32(2), reader.GetInt32(3)));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        private void DecrementOneDatabase(int id)
        {
            NpgsqlConnection _dbConnection = new NpgsqlConnection(connectionString);
            _dbConnection.Open();
            using (NpgsqlConnection connection = _dbConnection)
            {
                try
                {
                    using (NpgsqlCommand command = new NpgsqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "call decrement_quantity($1)";
                        command.Parameters.Add(new NpgsqlParameter() { Value = id });

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public Machine()
        {
            FetchProducts();

            


        }
    }
}
