using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum UnitType
{
    AVATAR,
    RE_AVATAR,
    ELEMENTAL,
    RE_ELEMENTAL,
    TOWER,
    MAX
};

public class HUDHpBar : MonoBehaviour {
    
    public UnitType m_type;

    public GameObject m_Unit;
    public Slider m_UIHpBar;
    public Transform m_HeadUpPosition;

    private float _CurHp;
    private float _MaxHp;

    private GameObject Unit;
    

	// Use this for initialization
	void Start () {

	    
	}
	
	// Update is called once per frame
	void Update () {

        if (m_HeadUpPosition == null)
        {
            this.gameObject.SetActive(false);
            DestroyObject(this);
        }
        else
        {
            switch (m_type)
            {
                case UnitType.AVATAR:
                    {
                        _CurHp = m_Unit.GetComponent<Avatar>().m_curHp;
                        _MaxHp = m_Unit.GetComponent<Avatar>().m_maxHp;
                        break;
                    }
                case UnitType.ELEMENTAL:
                    {
                        _CurHp = m_Unit.GetComponent<Elemental>().m_curHp;
                        _MaxHp = m_Unit.GetComponent<Elemental>().m_maxHp;
                        break;
                    }
                case UnitType.RE_AVATAR:
                    {
                        _CurHp = m_Unit.GetComponent<RemoteAvatar>().m_curHp;
                        _MaxHp = m_Unit.GetComponent<RemoteAvatar>().m_maxHp;
                        break;
                    }
                case UnitType.RE_ELEMENTAL:
                    {
                        break;
                    }
                case UnitType.TOWER:
                    {
                        Debug.Log(m_Unit.name);
                        _CurHp = m_Unit.GetComponent<Tower>().m_curHp;
                        _MaxHp = m_Unit.GetComponent<Tower>().m_maxHp;
                        break;
                    }
            }

            this.transform.position = m_HeadUpPosition.position;
            m_UIHpBar.value = Mathf.Clamp01(_CurHp / _MaxHp);
        }

    }


}
