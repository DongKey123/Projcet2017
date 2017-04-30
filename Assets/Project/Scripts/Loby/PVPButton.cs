using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PVPButton : MonoBehaviour ,IPointerClickHandler {

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("button").GetComponent<AudioSource>().Play();
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.3f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("PVP");
        yield return null;
    }
}
