using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelCollision : MonoBehaviour {

    public static int points = 0;
    public Text text;
    CharacterControlScript controlScript;
    // Use this for initialization
    private void Awake()
    {
        
    }
    void Start () {
        text = GameObject.Find("Coins").GetComponent<Text>();
        GameObject thePlayer = GameObject.Find("model1");
        controlScript = thePlayer.GetComponent<CharacterControlScript>();
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
            controlScript.collided = true;
        }
        if ((collision.gameObject.tag == "Wall"))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            controlScript.collided = true;
        }
    }
}
