using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

    [SerializeField]
    Transform[] m_Spawns;

    [SerializeField]
    GameObject[] m_Elementalprefab;

    [SerializeField]
    Transform m_HUDPanel;

    [SerializeField]
    GameObject m_HUDHpBarprefab;


    [SerializeField]
    float m_spawnDelay = 3.0f;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnElemental());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SpawnElemental()
    {
        while(true)
        {
            Spawn();
            yield return new WaitForSeconds(m_spawnDelay);
        }
    }

    void Spawn()
    {
        GameObject ele = (GameObject)Instantiate(m_Elementalprefab[0], this.transform.position,Quaternion.identity);
        ele.GetComponent<Elemental>().m_UnitAct = ElementalACT.MOVE;
        ele.transform.LookAt(ele.transform.position - Vector3.right);
        ele.GetComponent<Elemental>().m_HUDTr = GameObject.Find("Panel HUD").transform;

        //GameObject hpbarObj = (GameObject)Instantiate(m_HUDHpBarprefab,m_HUDPanel);
        //HUDHpBar hpbar = hpbarObj.GetComponent<HUDHpBar>();
        //hpbar.GetComponent<HUDHpBar>().m_type = UnitType.ELEMENTAL;
        //hpbar.GetComponent<HUDHpBar>().m_Unit = ele;
        //hpbar.GetComponent<HUDHpBar>().m_HeadUpPosition = ele.transform.FindChild("HeadUpPosition");



    }
}
