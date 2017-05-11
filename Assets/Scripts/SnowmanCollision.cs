using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(UnityEngine.Collision collision)
    {

        if ((collision.gameObject.tag == "Snowman"))
        {
            Debug.Log("Weszlo do ifa");
            Destroy(collision.gameObject);
        }
    }
}
