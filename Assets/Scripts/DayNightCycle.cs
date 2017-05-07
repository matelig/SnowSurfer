using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public float secondsPerMinute = 0.05f;
    public float startTime = 12.0f;
    public Transform orbitAngle;
    public MeshFilter stars;
    private float smoothMin;
    private float angle;
    private float textureOffset;
    private Material skyMaterial;
    private Transform orbit;

    // Use this for initialization
    void Start()
    {
        skyMaterial = GetComponent<Renderer>().sharedMaterial;
        orbit = orbitAngle.GetChild(0);
        orbitAngle.eulerAngles = new Vector3(90, 15, 0);
        stars.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        smoothMin = (Time.time / secondsPerMinute) + (startTime * 60);
        smoothMin = smoothMin - (Mathf.Floor(smoothMin / 1440) * 1440); //clamp smoothMin between 0-1440
        angle = smoothMin / 4;
        if (angle > 260f || angle < 90f)
        {
            stars.gameObject.SetActive(true);
        }
        else if (angle > 90f && angle < 260f)
        {
            stars.gameObject.SetActive(false);
        }
        orbit.localEulerAngles = new Vector3(angle, 0, 0);
        textureOffset = Mathf.Cos((((smoothMin) / 1440) * 2) * Mathf.PI) * 0.25f + 0.25f;
        skyMaterial.mainTextureOffset = new Vector2(Mathf.Round((textureOffset - (Mathf.Floor(textureOffset / 360) * 360)) * 1000) / 1000, 0);
    }
}
