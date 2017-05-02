using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Debug.Log("Weszlo do procedury");
        if ((collision.gameObject.tag=="Object")||(collision.gameObject.tag=="Powerup"))
        {
            Debug.Log("Weszlo do ifa");
            Destroy(collision.gameObject);
        }
    }
}
