using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserManager : MonoBehaviour
{
    public static UserManager Instance;

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

}
