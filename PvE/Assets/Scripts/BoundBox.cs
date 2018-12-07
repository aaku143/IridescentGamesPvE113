using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundBox : MonoBehaviour {

    public GameObject player;

    private float movespeed = 2.0f;

	// Use this for initialization
	void Start () {
        transform.position = player.transform.position;
        //Debug.Log("width" + GetComponent<Camera>().pixelWidth + "Height" + GetComponent<Camera>().pixelHeight);
	}
	
	// Update is called once per frame
	void Update () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (Vector3.Distance(player.transform.position, this.gameObject.transform.position) >= 2.5f) {
            this.gameObject.transform.position = Vector3.Lerp(this.gameObject.transform.position, player.transform.position, movespeed * Time.deltaTime);
        }
	}
}
