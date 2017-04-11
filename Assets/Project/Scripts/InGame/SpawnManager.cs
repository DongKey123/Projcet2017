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
    float m_spawnDelay = 1.0f;

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
        yield return null;
    }

    void Spawn()
    {
        GameObject ele0 = (GameObject)Instantiate(m_Elementalprefab[0], m_Spawns[0].position,Quaternion.identity);
        GameObject ele1 = (GameObject)Instantiate(m_Elementalprefab[1], m_Spawns[1].position, Quaternion.identity);
        GameObject ele2 = (GameObject)Instantiate(m_Elementalprefab[2], m_Spawns[2].position, Quaternion.identity);

        GameObject hpbar0 = (GameObject)Instantiate(m_HUDHpBarprefab,m_HUDPanel);
        hpbar0.GetComponent<HUDHpBar>().m_type = UnitType.ELEMENTAL;
        hpbar0.GetComponent<HUDHpBar>().m_Unit = ele0;
        hpbar0.GetComponent<HUDHpBar>().m_HeadUpPosition = ele0.transform.FindChild("HeadUpPosition");

        GameObject hpbar1 = (GameObject)Instantiate(m_HUDHpBarprefab, m_HUDPanel);
        hpbar1.GetComponent<HUDHpBar>().m_type = UnitType.ELEMENTAL;
        hpbar1.GetComponent<HUDHpBar>().m_Unit = ele1;
        hpbar1.GetComponent<HUDHpBar>().m_HeadUpPosition = ele1.transform.FindChild("HeadUpPosition");

        GameObject hpbar2 = (GameObject)Instantiate(m_HUDHpBarprefab, m_HUDPanel);
        hpbar2.GetComponent<HUDHpBar>().m_type = UnitType.ELEMENTAL;
        hpbar2.GetComponent<HUDHpBar>().m_Unit = ele2;
        hpbar2.GetComponent<HUDHpBar>().m_HeadUpPosition = ele2.transform.FindChild("HeadUpPosition");


    }
}
