//Created By    : Sundaresan S
//Project       : To Send and Recive Data from adafruit io cloud 
//Date          : 10 April 2019
//Description   :This is a code to recive any data from cloud and also publish 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;

public class WebStreem : MonoBehaviour {

    // Use this for initialization
    public string Uri;
    public string Uri1;
    public string Uri2;
    public Text TempValueText;
    public Text MagValueText;
    public TextMesh dateandtime;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ReadMydata();

    }
    void ReadMydata()
    {
        StartCoroutine(ReadData1());
        StartCoroutine(ReadData2());
        dateandtime.text = System.DateTime.Now.ToString();
    }

    public void Send1()
    {
        StartCoroutine(SendDataToCloud1());
    }
    public void Send0()
    {
        StartCoroutine(SendDataToCloud0());
    }
    IEnumerator ReadData1()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(Uri))
        {
            yield return www.SendWebRequest();
            //checking for the network
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("Network error");
            }
            else
            {
                JSONNode iotardata = JSON.Parse(System.Text.Encoding.UTF8.GetString(www.downloadHandler.data));
                if (iotardata == null)
                {
                    Debug.Log("********No Data Found*********");
                }
                else
                {
                    Debug.Log("+++++++++++ Data Found ++++++++++++++");
                    Debug.Log("jsonData.Count:" + iotardata.Count);

                    TempValueText.text = iotardata["last_value"] +  "°C";
                }

            }
        }
    }
    IEnumerator ReadData2()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(Uri1))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("NetworkError");

            }
            else
            {
                JSONNode Iotardata = JSON.Parse(System.Text.Encoding.UTF8.GetString(www.downloadHandler.data));
                if (Iotardata == null)
                {
                    Debug.Log("********No Data Found*********");
                }
                else
                {
                    Debug.Log("+++++++++++ Data Found ++++++++++++++");
                    Debug.Log("jsonData.Count:" + Iotardata.Count);
                    MagValueText.text = Iotardata["last_value"];

                }
            }
        }
       
    }
    IEnumerator SendDataToCloud1()
    {
        WWWForm DATA = new WWWForm();
        DATA.AddField("value", "1");
        using (UnityWebRequest www = UnityWebRequest.Post(Uri2, DATA))
        {
            yield return www.SendWebRequest();
        }
    }
    IEnumerator SendDataToCloud0()
    {
        WWWForm Data = new WWWForm();
        Data.AddField("value", "0");
        using (UnityWebRequest www = UnityWebRequest.Post(Uri2, Data))
        {
            yield return www.SendWebRequest();
        }

    }

}
