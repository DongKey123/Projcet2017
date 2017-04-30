using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEvent : MonoBehaviour {

    public Tutorial m_tutorial;
    public GameObject m_firstEventObj;

    public GameObject m_LeftPoint;
    public GameObject m_RightPoint;
    public GameObject m_SkillPoint;

    public GameObject m_SecondEventObj;
    public Skill1Button m_Skillbtn;

    public GameObject m_SpawnManager;
    public Tower m_Tower;

    public GameObject m_ResultPanel;

    public AudioSource m_VictoryAudio;

    int eventNum = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		switch(eventNum)
        {
            case 0:
                {
                    if (!m_tutorial.gameObject.activeSelf)
                    {
                        m_LeftPoint.SetActive(true);
                        m_RightPoint.SetActive(true);
                    }

                    if (m_firstEventObj == null)
                    {
                        m_LeftPoint.SetActive(false);
                        m_RightPoint.SetActive(false);
                        eventNum++;
                        m_tutorial.gameObject.SetActive(true);
                        m_Skillbtn.GetComponent<Skill1Button>().enabled = true;
                        m_SecondEventObj.SetActive(true);
                    }
                    break;
                }
            case 1:
                {
                    if(!m_tutorial.gameObject.activeSelf)
                    {
                        m_SkillPoint.SetActive(true);
                    }

                    if(m_SecondEventObj == null)
                    {
                        m_SkillPoint.SetActive(false);
                        eventNum++;
                        m_tutorial.gameObject.SetActive(true);
                    }
                    break;
                }
            case 2:
                {
                    if (!m_tutorial.gameObject.activeSelf)
                    {
                        m_SpawnManager.SetActive(true);
                    }

                    if (m_Tower.m_curHp <= 0)
                    {
                        m_SpawnManager.SetActive(false);
                        eventNum++;
                        m_tutorial.gameObject.SetActive(true);
                    }
                }
                break;
            case 3:
                {
                    if (!m_tutorial.gameObject.activeSelf)
                    {
                        eventNum++;
                        m_ResultPanel.SetActive(true);
                        m_VictoryAudio.Play();
                    }
                }
                break;
        }
	}
}
