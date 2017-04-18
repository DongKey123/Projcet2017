using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ShopButton : MonoBehaviour ,IPointerClickHandler {

	public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Shop Button");
    }
}
