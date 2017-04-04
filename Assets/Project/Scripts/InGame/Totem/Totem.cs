using UnityEngine;
using System.Collections;

public enum TotemType
{
    ATTACK,
    BUFF,
    HEAL,
    MAX
}

public class Totem : MonoBehaviour {

    protected float m_Cost;
    protected float m_ActionDelay;
    protected float m_Range = 3f;
    protected bool m_IsTakingAction = false;

    public float Cost
    {
        set
        {
            m_Cost = value;
        }
        get
        {
            return m_Cost;
        }
    }

    public float ActionDelay
    {
        set
        {
            m_ActionDelay = value;
        }
        get
        {
            return m_ActionDelay;
        }
    }

    public virtual void playAction()
    {
        m_IsTakingAction = true;
    }
}
