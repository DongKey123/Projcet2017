using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum ItemType
{
    MASK,
    CLOTH,
    WEAPON,
    SHOES
};

public class Item : MonoBehaviour , IPointerClickHandler  {

    public int ItemNum;
    public ItemType m_ItemType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        this.GetComponentInParent<Inventory>().m_nowSelectedItem = this;
    }

    void Select()
    {
        
    }
}
