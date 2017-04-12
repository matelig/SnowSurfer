using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundControl : MonoBehaviour {
    public Renderer rend;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    //Material texture offset rate
    float speed = .2f;

    //Offset the material texture at a constant rate
    void Update()
    {
        float offset = Time.time * speed;
        rend.material.mainTextureOffset = new Vector2(0, -offset);
    }
}
