using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour {
    public Renderer rend;
   // public GameObject gameObject;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    //Material texture offset rate
    
    
    //Offset the material texture at a constant rate
    void FixedUpdate()
    {
        float speed = (float)(GroundVariables.gameSpeed * 2.285 + 0.013);

        float offset = Time.time * speed;
        rend.material.mainTextureOffset = new Vector2(0, -offset);
    }
}
