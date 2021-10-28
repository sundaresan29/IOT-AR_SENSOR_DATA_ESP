//Created By    : Sundaresan S
//Project       : Virtual Button for Publish data 
//Date          : 16 OCT 2021
//Description   :This code will Publish json data("1") to cloud via api by pressing virtual button ("ON_Button")

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class MYVB : MonoBehaviour, IVirtualButtonEventHandler{

    // Use this for initialization
    public GameObject Onbutton;
    public WebStreem webstreem;
   // public GameObject animation;
    public Animator cubani;
    void Start ()
    {
        Onbutton=GameObject.Find("ON_Button");
        Onbutton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        cubani.GetComponent<Animator>();

	}
	
	// Update is called once per frame
    void getdata1()
    {
        webstreem.Send1();
    }
   // void getdata0()
   // {
    //    webstreem.Send0();
    //}
    void Update () {
		
	}
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        getdata1();
        cubani.Play("New Animation");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        
    }

}
