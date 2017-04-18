using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PVPButton : MonoBehaviour ,IPointerClickHandler {

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("PVPButton");
    }
}
