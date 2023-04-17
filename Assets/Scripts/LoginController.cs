using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class LoginController : MonoBehaviour {


    [SerializeField]
    public TMP_InputField firstNameInputField;
    [SerializeField]
    public TMP_InputField lastNameInputField;
    [SerializeField]
    public TMP_InputField DOBInputField;
    [SerializeField]
    public GameObject userManager;


    // Start is called before the first frame update
    void Start() {



    }

    // Update is called once per frame
    void Update() {

    }

    public void getInputValues() {

        string firstName = firstNameInputField.text.Trim();
        print(firstName);
        string lastName = lastNameInputField.text.Trim();
        print(lastName);
        string grade = DOBInputField.text.Trim();
        print(grade);

        userManager.GetComponent<UserManager>().setFirstName(firstName);
        userManager.GetComponent<UserManager>().setLastName(lastName);
        userManager.GetComponent<UserManager>().setGrade(Int32.Parse(grade));

        userManager.GetComponent<UserManager>().Login();
        //database.GetComponent<SQLiteTest>().RegisterUser(firstName, lastName, DOB);
        //SceneManager.LoadScene("Vehicles selcetion");
        SceneManager.LoadScene("LoggedInMenu");

    }
}
