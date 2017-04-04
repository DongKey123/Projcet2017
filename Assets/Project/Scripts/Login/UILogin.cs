using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UILogin : MonoBehaviour ,IPointerClickHandler {

    public Text m_ID;
    public InputField m_Password;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnPointerClick(PointerEventData eventData)
    {
        LoginManager.GetInstance().Login(m_ID.text, m_Password.text);
    }
}
