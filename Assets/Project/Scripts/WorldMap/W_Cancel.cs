using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class W_Cancel : MonoBehaviour , IPointerClickHandler{

    public GameObject Panel;

	public void OnPointerClick(PointerEventData eventData)
    {
        Panel.SetActive(false);
    }
}
