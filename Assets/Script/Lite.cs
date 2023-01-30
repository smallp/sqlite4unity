using Mono.Data.Sqlite;
using System.IO;
using UnityEngine;

public class Lite
{
    static Lite obj = null;
    private SqliteConnection dbConnection;

    static public Lite getIns()
    {
        if (obj == null)
        {
            obj = new Lite();
        }
        return obj;
    }

    public Lite()
    {
        var path = Application.persistentDataPath+"/test.db";
        dbConnection = new SqliteConnection("URI=file:"+path);
        if (!File.Exists(path))
        {
            dbConnection.Open();
            var command = dbConnection.CreateCommand();
            command.CommandText =
            @"CREATE TABLE IF NOT EXISTS `country` (
  country_id INTEGER PRIMARY KEY AUTOINCREMENT,
  `country` VARCHAR(50) NOT NULL)
    ";
            command.ExecuteNonQuery();
        }
        else
        {
            Debug.Log(path);
            dbConnection.Open();
        }
    }
    public void getAll()
    {
        var command = dbConnection.CreateCommand();
        command.CommandText =
        @"
        SELECT country
        FROM country
    ";

        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var name = reader.GetString(0);

                Debug.Log($"Hello, {name}!");
            }
        }
    }

    public void insert(string name)
    {
        var command = dbConnection.CreateCommand();
        command.CommandText =
            @"insert into `country` (country) values (@name)";
        command.Parameters.Add("@name",System.Data.DbType.String).Value= name;
        command.ExecuteReader();
    }

    public void close()
    {
        dbConnection.Close();
    }
}
