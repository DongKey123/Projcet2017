using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Text;


public class TestAPI : MonoBehaviour {

    string url = "http://localhost:8080";
    string test = "?user=hyejong&password=1234";
    string test2 = "user=hyejong&password=1234";

    private bool IsGetUrl = false;

    // Use this for initialization
    void Start () {
        WWW www = new WWW(url+test);

        //StartCoroutine(PostIDPassword());
        //StartCoroutine(WaitForRequest(www));
        //StartCoroutine(GetResponseHeader(www));

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Send()
    {
        //StartCoroutine(WaitForRequest());
    }

    public void GetAll()
    {
        
    }

    IEnumerator PostIDPassword()
    {
        //Debug.Log("Post");
        //WWWForm form = new WWWForm();
        //form.AddField("user", "dongkey");
        //form.AddField("password", "12345");

        //Dictionary<string, string> headers = new Dictionary<string, string>();
        //headers.Add("Content-Type", "application/json");

        //byte[] pData = Encoding.ASCII.GetBytes(form.ToString());
        /////
        //Debug.Log(form);

        //WWW www = new WWW(url, pData, headers);

        /////
        ///Json Test
        JSONObject json = new JSONObject();
        json.AddField("user", "Dongkey5");
        json.AddField("password", "12345");
        Dictionary<string, string> jsonHeader = new Dictionary<string, string>();
        if (jsonHeader.ContainsKey("Content-Type"))
            jsonHeader["Content-Type"] = "application/json";
        else
            jsonHeader.Add("Content-Type", "application/json");

        byte[] data = Encoding.ASCII.GetBytes(json.ToString());
        WWW www = new WWW(url, data, jsonHeader);



        StartCoroutine(WaitForRequest(www));

        Debug.Log(json.ToString());


        ////WWW form Test
        WWWForm form = new WWWForm();
        form.AddField("user", "Dongkey");
        form.AddField("password", "12345");
        Dictionary<string, string> postHeader = form.headers;
        if (postHeader.ContainsKey("Content-Type"))
            postHeader["Content-Type"] = "application/json";
        else
            postHeader.Add("Content-Type", "application/json");

        Debug.Log(json);

        yield return null;
    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return null;
        
        if (www.error == null)
        {

            Debug.Log("WWW Ok!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }

    }
    IEnumerator GetResponseHeader(WWW www)
    {
        yield return www;

        //데이터 가져오기
        if(IsGetUrl)
        {
            if (www.responseHeaders.Count > 0)
            {
                //string date = www.responseHeaders["DATE"];
                //Debug.Log(date);
                foreach (KeyValuePair<string, string> entry in www.responseHeaders)
                {
                    Debug.Log(entry.Value + "=" + entry.Key);
                }
            }
        }
        else
        {
            Debug.Log("not Get");
        }
    }
}
