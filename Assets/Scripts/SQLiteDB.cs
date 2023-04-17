using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using Mono.Data.Sqlite;
using System.IO;
using System;

public class SQLiteDB : MonoBehaviour
{




    public static SQLiteDB instance;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(this);
        } else {
            Destroy(this.gameObject);
        }
    }
    void Start() {






    }

    void Update() {



    }


    private IDbConnection CreateAndOpenDatabase() { // Opens (or Creates) the database and returns it

        string dbUri = "URI = file:VRLearningLevelScores.sqlite";
        IDbConnection dbConnection = new SqliteConnection(dbUri);
        dbConnection.Open();

        IDbCommand dbCommandCreateTable = dbConnection.CreateCommand();
        dbCommandCreateTable.CommandText = "CREATE TABLE IF NOT EXISTS progress (id INTEGER PRIMARY KEY AUTOINCREMENT, firstName TEXT, lastName TEXT, grade TEXT, completed INTEGER)";
        dbCommandCreateTable.ExecuteReader();

        return dbConnection;
    }

    public int RegisterUser(string firstName, string lastName, int grade) { //Registers the User

        string fName = firstName;
        string lName = lastName;
        int Grade = grade;
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommandInsertValue = dbConnection.CreateCommand();

        if (!hasUser(fName, lName, Grade)) { //if the user doesn't exist within the database, create them


            dbCommandInsertValue.CommandText = "INSERT OR REPLACE INTO progress (firstName, lastName, grade) VALUES ('" + fName + "' , '" + lName + "', '" + Grade + "' )";

            dbCommandInsertValue.ExecuteNonQuery();
            dbConnection.Close();
            print("User doesn't exits, creating now... ");

        } else { //otherwise, return continue

            print("User exists inside database, returning ID...");

        }

        int ID = getID(fName, lName, Grade);
        print("ID of user is " + ID);
        return ID;


    }
    public bool hasUser(string firstName, string lastName, int grade) { //returns true if the user already exists inside the database


        if (getID(firstName, lastName, grade) == -1) {
            return false;
        }
        return true;


    }

    public int getID(string firstName, string lastName, int grade) { //returns the ID of a user. If user doesn't exist, it returns -1

        int id = -1;
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommandSelectValue = dbConnection.CreateCommand();

        dbCommandSelectValue.CommandText = "SELECT id FROM progress WHERE firstName='" + firstName + "' AND lastName='" + lastName + "' AND grade='" + grade + "' ";
        IDataReader dataReader = dbCommandSelectValue.ExecuteReader();
        while (dataReader.Read()) {

            id = dataReader.GetInt32(0);

        }

        dbConnection.Close();
        dataReader.Close();


        return id;
    }


    public void addCompletionofLevel(int completedLevel, int userID) { //Adds whether this user has completed a level.
        IDbConnection dbConnection = CreateAndOpenDatabase();
        IDbCommand dbCommandInsertValue = dbConnection.CreateCommand();




            dbCommandInsertValue.CommandText = "UPDATE progress SET lvl" + completedLevel + " = '" + 1 + "'  WHERE ID =  '" + userID + "'";

            dbCommandInsertValue.ExecuteNonQuery();
            dbConnection.Close();
            print("Added level " + completedLevel + " completion");
            
        




    }
}


