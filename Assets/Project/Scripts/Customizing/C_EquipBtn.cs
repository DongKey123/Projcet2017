using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class C_EquipBtn : MonoBehaviour ,IPointerClickHandler{

    // Use this for initializationS
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("button").GetComponent<AudioSource>().Play();
    }
}
