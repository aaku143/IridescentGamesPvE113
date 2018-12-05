using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackGroud : MonoBehaviour {
    public GameObject image1;
    public GameObject image2;
    public GameObject text;
    public bool isImage1 = true;
    public float Timestamp;

    public float Delay = 1.0f; // Seconds to wait
                               // Use this for initialization

    void Start () {
        Timestamp = Time.realtimeSinceStartup;
    }
	
	// Update is called once per frame
	void Update () {
        float timeNow = Time.realtimeSinceStartup;
   		if(isImage1 && timeNow - Timestamp > Delay)
        {
            image1.SetActive(false);
            image2.SetActive(true);
            if (text)
            {
                text.SetActive(true);
            }
            Timestamp = timeNow;
            isImage1 = false;
        }
        if (!isImage1 && timeNow - Timestamp > Delay)
        {
            image1.SetActive(true);
            image2.SetActive(false);
            if (text)
            {
                text.SetActive(false);
            }
            Timestamp = timeNow;
            isImage1 = true;
        }
    }
}
