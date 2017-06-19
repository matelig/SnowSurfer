using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpeed : MonoBehaviour {

    private int i = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        i++;
        if (i==600)
        {
            if (!GroundVariables.stop)
            {
                i = 0;
                GroundVariables.gameSpeed += .02f;
            }
            
        }
        
	}

    
}
