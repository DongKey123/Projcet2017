using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_FireBall : MonoBehaviour {
    
    List<GameObject> list;
    
    public ParticleSystem m_SubParticleExplosion;

    public float m_Speed = 10f;
    public bool AttackOn = true;

    public AudioSource m_ExplosionAudio;

	// Use this for initialization
	void Start () {
        list = new List<GameObject>();        
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnParticleCollision(GameObject other)
    {
        if (other.transform.tag == "Elemental")
        {
            if (list.Contains(other))
            {

            }
            else
            {
                Debug.Log(m_ExplosionAudio);
                m_ExplosionAudio.Play();
                other.GetComponent<Elemental>().m_curHp -= 5;
                list.Add(other);
            }

        }
        else if (other.transform.tag == "Tower")
        {
            m_ExplosionAudio.Play();
            other.GetComponent<Tower>().m_curHp -= 5;
        }
    }
}
