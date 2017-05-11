using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GroundVariables.stop)
        transform.Translate(Vector3.back * GroundVariables.gameSpeed);
    }
}
