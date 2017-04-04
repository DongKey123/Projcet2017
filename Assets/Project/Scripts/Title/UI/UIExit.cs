using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UIExit : MonoBehaviour , IPointerClickHandler
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        Application.Quit();
    }
}
