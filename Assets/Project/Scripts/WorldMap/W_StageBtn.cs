using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class W_StageBtn : MonoBehaviour ,IPointerClickHandler {

    public GameObject m_StagePanel;

	public void OnPointerClick(PointerEventData eventData)
    {
        m_StagePanel.SetActive(true);
    }
}
