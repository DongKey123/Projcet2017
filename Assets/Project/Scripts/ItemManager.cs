using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemManager : MonoBehaviour {

    public Avatar m_Avatar;

    public List<int> m_Items;

    private static ItemManager _instance;
    string url = "http://13.124.98.25:8080";

    public static ItemManager GetInstance()
    {
        return _instance;
    }

    void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator GetEquipList()
    {
        WWWForm form = new WWWForm();
        form.headers.Add("Cookie", PlayerPrefs.GetString("COOKIE"));

        Dictionary<string, string> headers = form.headers;
        if (headers.ContainsKey("Content-Type"))
            headers["Content-Type"] = "application/json";
        else
            headers.Add("Content-Type", "application/json");

        yield return null;
    }
}
