using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    Image thisImage;
    public List<Sprite> healthList;
    public Player player;

	// Use this for initialization
	void Start () {
        thisImage = GetComponent<Image>();
        Debug.Log(thisImage.sprite.name);
	}
	
	// Update is called once per frame
	void Update () {
        thisImage.sprite = healthList[player.GetHealth() - 1];
        
    }
}
