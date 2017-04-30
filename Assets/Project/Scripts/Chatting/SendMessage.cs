using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SendMessage : MonoBehaviour ,IPointerClickHandler{

    public void OnPointerClick(PointerEventData eventData)
    {
        NetManager.GetInstance().SendChattingMessage();
    }
}
