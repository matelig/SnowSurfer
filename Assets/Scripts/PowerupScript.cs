using UnityEngine;
using System.Collections;

public class PowerupScript : MonoBehaviour
{
    

    void Update()
    {
        transform.Translate(0, 0, -GroundVariables.gameSpeed);
    }
}