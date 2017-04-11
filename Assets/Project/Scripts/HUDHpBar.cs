using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum UnitType
{
    AVATAR,
    RE_AVATAR,
    ELEMENTAL,
    RE_ELEMENTAL,
    MAX
};

public class HUDHpBar : MonoBehaviour {
    
    public UnitType m_type;

    public GameObject m_Unit;
    public Slider m_UIHpBar;
    public Transform m_HeadUpPosition;

    private float _CurHp;
    private float _MaxHp;
    
    

	// Use this for initialization
	void Start () {

	    switch(m_type)
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
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (m_HeadUpPosition == null)
        {
            this.gameObject.SetActive(false);
            DestroyObject(this);
        }
        this.transform.position = m_HeadUpPosition.position;

        m_UIHpBar.value = _CurHp / _MaxHp;
    }
}
