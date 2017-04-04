using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitManager : MonoBehaviour {

    static UnitManager _instance;

    public static UnitManager GetInstance()
    {
        return _instance;
    }

    public RemoteAvatar m_RomteAvatar;
    public List<UnitBase> myUnits;
    public List<UnitBase> enemyUnits;
 
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
}
