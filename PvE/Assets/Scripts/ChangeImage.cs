//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class ChangeImage : MonoBehaviour {
//    public GameObject nextImage;
//    public GameObject text;
//    private float Timestamp = 0.0f;
//    public float Delay = 1.0f; // Seconds to wait
//    // Use this for initialization
//    void Start () {
//        //back = GameObject.Find("GameOver_1");
//        //Timestamp = Time.realtimeSinceStartup + Delay;
//        StartCoroutine(YourFunctionName());
//    }

//    IEnumerator YourFunctionName()
//    {
//        while (true)
//        {
//            //DoSomething();
//            nextImage.SetActive(true);
//            text.SetActive(true);
//            if (Input.anyKey)
//            {
//                SceneManager.LoadScene(0);//back to main menu
//            }
//            yield return new WaitForSeconds(1);
//            nextImage.SetActive(false);
//            text.SetActive(false);
//            if (Input.anyKey)
//            {
//                SceneManager.LoadScene(0);//back to main menu
//            }
//            yield return new WaitForSeconds(1);
//        }
//    }


//    // Update is called once per frames
//    void Update () {
//        //back.SetActive(true);
//        //new WaitForSeconds(1);
//        // //if (Time.realtimeSinceStartup > Timestamp)
//        ////{
//        ////    //Timestamp = Time.realtimeSinceStartup;
//        //    back.SetActive(false);
//        ////}

//	}
//}
