using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SettingButton : MonoBehaviour , IPointerClickHandler{

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Setting");
    }
}
