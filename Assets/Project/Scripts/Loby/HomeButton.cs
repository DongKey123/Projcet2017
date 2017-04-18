using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class HomeButton : MonoBehaviour , IPointerClickHandler{

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("HomeButton");
    }
}
