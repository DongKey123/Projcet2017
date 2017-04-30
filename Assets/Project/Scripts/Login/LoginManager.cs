using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class LoginManager : MonoBehaviour {

    private static LoginManager _instance;
    string url = "http://13.124.98.25:8080";
    string test = "?user=hyejong&password=1234";

    string _id;

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
        NetManager.GetInstance().m_userName = _id;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
    }

    public void FailedLogin(WWW www)
    {
        Debug.Log("Fail Login");
    }

    IEnumerator goLogin(string id,string password)
    {
        WWW www = new WWW(url + "?user=" + id + "&password=" + password);
        _id = id;
        StartCoroutine(WaitForRequest(www));

        yield return null;
    }

    IEnumerator WaitForRequest(WWW www)
    {
        while (!www.isDone)
        {
            yield return null;
        }

        if (www.error == null)
        {
            if (www.responseHeaders.ContainsKey("SET-COOKIE"))
            {
                PlayerPrefs.SetString("COOKIE", www.responseHeaders["SET-COOKIE"]);
            }
            SuccessLogin(www);
        }
        else
        {
            FailedLogin(www);
        }

        yield return null;
    }
}
