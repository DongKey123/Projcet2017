using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class W_HomeBtn : MonoBehaviour, IPointerClickHandler
{

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("button").GetComponent<AudioSource>().Play();
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.3f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Lobby");
        yield return null;
    }
}
