using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class QuitButton : MonoBehaviour ,IPointerClickHandler{

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Quit Button");
    }
}
