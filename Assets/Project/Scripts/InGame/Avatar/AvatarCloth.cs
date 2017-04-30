using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarCloth : MonoBehaviour {

    public GameObject headPrefab;
    public GameObject clothPrefab;
    public GameObject leftWeaponPrefab;
    public GameObject rightWeaponPrefab;
    public GameObject shoesPrefab;

	// Use this for initialization
	void Start () {
        //PlayerPrefs.SetInt("head", 0);
        //PlayerPrefs.SetInt("cloth", 0);
        //PlayerPrefs.SetInt("left", 0);
        //PlayerPrefs.SetInt("right", 0);
        //PlayerPrefs.SetInt("shoes", 0);


        int head = PlayerPrefs.GetInt("head");
        int cloth = PlayerPrefs.GetInt("cloth");
        int left = PlayerPrefs.GetInt("left");
        int right = PlayerPrefs.GetInt("right");
        int shoes = PlayerPrefs.GetInt("shoes");

        if(head == 1)
        {
            headPrefab.SetActive(true);
        }

        if (cloth == 1)
        {
            clothPrefab.SetActive(true);
        }

        if (left == 1)
        {
            leftWeaponPrefab.SetActive(true);
        }

        if (right == 1)
        {
            rightWeaponPrefab.SetActive(true);
        }

        if (shoes == 1)
        {
            shoesPrefab.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
