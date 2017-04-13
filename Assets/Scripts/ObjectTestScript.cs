using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTestScript : MonoBehaviour {
    public float objectSpeed = -.2f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0,0, objectSpeed);
    }
}
