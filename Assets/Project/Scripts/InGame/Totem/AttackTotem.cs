using UnityEngine;
using System.Collections;

public class AttackTotem : Totem {

    public float m_AttackPower;
    public int m_CriticalChance;            //치명타확률

    public float m_RotateSpeed;

    public float TestRange = 3f;
    public GameObject HeadPart;
    public GameObject TestUnit;
    public GameObject TestObject;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        //기획자용 사정거리 보여주기용도
        //TestObject.transform.localScale = new Vector3(0.2f, 0, 0.2f) * TestRange;


        //적 발견 시 회전
        Vector3 remoteUnitPos = TestUnit.transform.position;
        float distacne = Vector3.Distance(this.transform.position, remoteUnitPos);
        if (distacne < TestRange)
        {
            Vector3 moveDir = ( remoteUnitPos- this.transform.position ).normalized;
            Quaternion look = Quaternion.LookRotation(moveDir);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, look, m_RotateSpeed * Time.deltaTime);
        }
    }

    public override void playAction()
    {
        
    }
}
