using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class W_BackBtn : MonoBehaviour, IPointerClickHandler
{

    // Use this for initialization
    void Update()
    {
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
        GameObject.Find("button").GetComponent<AudioSource>().Play();
        BackButtonClick();
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.3f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
        yield return null;
    }

    void BackButtonClick()
    {
        StartCoroutine(LoadScene());
    }
}
