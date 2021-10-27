using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MYVB2 : MonoBehaviour, IVirtualButtonEventHandler {

    // Use this for initialization
    public GameObject Offbutton;
    public WebStreem webstreemdata;
    void Start() {
        Offbutton = GameObject.Find("OFF_Button");
        Offbutton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

    }


    // Update is called once per frame
    void Update() {

    }
    //void getdata0()
    //{
        //webstreemdata.Send0();
    //}

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        webstreemdata.Send0();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        
    }
}


