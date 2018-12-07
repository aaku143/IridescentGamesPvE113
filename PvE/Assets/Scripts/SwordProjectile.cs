using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordProjectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void OnBecameInvisible () {
        Destroy(this.gameObject);
	}
}
