using UnityEngine;
using System.Collections;

public class CameraOffset : MonoBehaviour {

    [SerializeField]
    Transform Player;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = this.transform.position - Player.position;

    }
	
	// Update is called once per frame
	void Update () {
	}

    void LateUpdate()
    {
        this.transform.position = Player.position + offset;
    }
}
