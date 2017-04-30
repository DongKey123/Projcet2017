using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class W_Stage0_In : MonoBehaviour ,IPointerClickHandler{

	public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("button").GetComponent<AudioSource>().Play();
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.3f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("InGame");
        yield return null;
    }
}
