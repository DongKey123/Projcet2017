using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PVEButton : MonoBehaviour , IPointerClickHandler{

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("PVE");
    }
}
