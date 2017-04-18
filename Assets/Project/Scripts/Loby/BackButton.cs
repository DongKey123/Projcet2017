using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class BackButton : MonoBehaviour ,IPointerClickHandler {
	
	// Update is called once per frame
	void Update () {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                BackButtonClick();
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        BackButtonClick();
    }

    void BackButtonClick()
    {
        Debug.Log("Back");
    }
}
