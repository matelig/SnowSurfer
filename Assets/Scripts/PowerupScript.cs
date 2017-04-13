using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour
{
    public float objectSpeed = -.1f;

    void Update()
    {
        transform.Translate(0, 0, objectSpeed);
    }
}