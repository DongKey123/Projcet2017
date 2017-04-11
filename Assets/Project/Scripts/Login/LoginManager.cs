using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class LoginManager : MonoBehaviour {

    private static LoginManager _instance;
    string url = "http://localhost:8080";
    string test = "?user=hyejong&password=1234";
    public static LoginManager GetInstance()
    {
        return _instance;
    }

    void Start()
    {
        
    }

    void Awake()
    {
        _instance = this;
    }

	
    public void Login(string id,string password)
    {
        //Debug.Log("login test");
        //WWW www = new WWW(url + test);
        StartCoroutine(goLogin(id, password));
    }

    public void SuccessLogin(WWW www)
    {
        Debug.Log("success Login");
    }

    public void FailedLogin(WWW www)
    {
        Debug.Log("Fail Login");
    }

    IEnumerator goLogin(string id,string password)
    {
        WWW www = new WWW(url + "?user=" + id + "&password=" + password);
        StartCoroutine(WaitForRequest(www));

        yield return null;
    }

    IEnumerator WaitForRequest(WWW www)
    {
        while (!www.isDone)
        {
            Debug.Log("Call");
            yield return null;
        }

        if (www.error == null)
        {
            SuccessLogin(www);
        }
        else
        {
            FailedLogin(www);
        }

        yield return null;
    }
}
