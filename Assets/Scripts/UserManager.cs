using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserManager : MonoBehaviour
{
    public static UserManager Instance;
    public static string firstName;
    public static string lastName;
    public static int Grade;
    [SerializeField] public GameObject database;
    public static int ID;
    private void Awake() {
        Instance = this;
    }

    public enum Scene {
        LoggedInMenu,
        MainMenu,
        SampleScene
    }

    public void LoadScene(Scene scene) {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadLogin() {
        SceneManager.LoadScene(Scene.LoggedInMenu.ToString());
    }

    public void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.D)) {

            DisplayCurrentUserInConsole();

        }
        if (Input.GetKeyDown(KeyCode.P)) {

            SceneManager.LoadScene("endLevel");



        }


        //  vehicle.transform.position = transform.position + new Vector3(461, (float)0.86, 330);


    }



    void DisplayCurrentUserInConsole() {

        print("ID:" + getID() + "\nFirst Name: " + getFirstName() + "\nLast Name: " + getLastName() + "\nGrade: " + getGrade());

    }

    public void Login() {


        setID(database.GetComponent<SQLiteDB>().RegisterUser(getFirstName(), getLastName(), getGrade())); //Calls the database registerUser method, which creates and returns the user ID
        print("Logging in with " + getFirstName() + " " + getLastName() + " as ID: " + getID());
    }

    public void addScoreToDatabase(int level) {

        database.GetComponent<SQLiteDB>().addCompletionofLevel(level, getID());


    }
    public static string getFirstName() {
        return firstName;
    }

    public void setFirstName(string fName) {
        firstName = fName;
    }

    public static string getLastName() {
        return lastName;
    }

    public void setLastName(string lName) {
        lastName = lName;
    }
    public static int getGrade() {
        return Grade;
    }

    public void setGrade(int grade) {
        Grade = grade;
    }

    public int getID() {
        return ID;
    }

    public void setID(int id) {
        ID = id;
    }

}
