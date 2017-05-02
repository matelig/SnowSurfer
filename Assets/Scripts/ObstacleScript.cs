using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour
{
    public float objectSpeed = -.1f;

    void Update()
    {
        transform.Translate(0, objectSpeed, 0);
    }
}