﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTranslate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!GroundVariables.stop)
            transform.Translate(0, 0, -GroundVariables.gameSpeed,Space.World);
	}
}
