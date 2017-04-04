using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class UICustomize : MonoBehaviour,IPointerClickHandler {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene("CustomizingScene");
    }
}
