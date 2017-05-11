using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour
{
    public float objectSpeed = -.1f;

    void Update()
    {
        if (!GroundVariables.stop)
            transform.Translate(0, objectSpeed, 0);
    }
}