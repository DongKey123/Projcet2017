using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class GoTitle : MonoBehaviour , IPointerClickHandler{

    public void OnPointerClick(PointerEventData eventData)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Title");
    }
}
