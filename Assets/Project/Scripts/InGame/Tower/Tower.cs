using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    public GameObject m_HUDHpBarPrefab;
    public Transform m_HeadUpPosition;
    public Transform m_HUDTR;

    public float m_curHp;
    public float m_maxHp;
    public GameObject m_Particle;

    public AudioSource m_BreakAudio1;
    public AudioSource m_BreakAudio0;
    private bool SoundCk = true;

	// Use this for initialization
	void Start () {
        CreateHpBar();

    }
	
	// Update is called once per frame
	void Update () {
		if(m_curHp<0)
        {
            m_Particle.SetActive(true);
            if(SoundCk)
            {
                m_BreakAudio1.Play();
                m_BreakAudio0.Play();
                SoundCk = false;
            }
        }
	}

    void CreateHpBar()
    {
        GameObject Gobj = Instantiate(m_HUDHpBarPrefab, m_HUDTR);
        HUDHpBar hpBar = Gobj.GetComponent<HUDHpBar>();
        hpBar.transform.localScale = new Vector3(0.04f, 0.04f, 1);
        hpBar.m_type = UnitType.TOWER;
        hpBar.m_Unit = this.gameObject;
        hpBar.m_HeadUpPosition = this.m_HeadUpPosition;
    }
}
