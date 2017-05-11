using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelCollision : MonoBehaviour {

    public static int points = 0;
    public Text text;
    // Use this for initialization
    private void Awake()
    {
        
    }
    void Start () {
        text = GameObject.Find("Coins").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        
        if ((collision.gameObject.tag == "Coin"))
        {
            points++;
            Destroy(collision.gameObject);
            text.text = points.ToString();
        }
        if ((collision.gameObject.tag=="Snowman")|| (collision.gameObject.tag == "Object"))
        {
            GroundVariables.stop = true;
            Time.timeScale = 0;
        }
    }
}
