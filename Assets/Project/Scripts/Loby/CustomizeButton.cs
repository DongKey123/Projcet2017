using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class CustomizeButton : MonoBehaviour ,IPointerClickHandler{

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Customize Scene");
    }
}
