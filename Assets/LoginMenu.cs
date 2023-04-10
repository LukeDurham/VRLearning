using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class LoginMenu : MonoBehaviour
{
    private Button _button;
    public Hand currentHand;



    void Awake() {
        //);

    }

    
   /* public void NewUser(Hand hand) {
        if (_button != null && currentHand.onHand) {
            
        }




    }*/

    public void LoadLogin() {
        UserManager.Instance.LoadLogin();
    }
}
