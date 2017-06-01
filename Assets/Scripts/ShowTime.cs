using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTime : MonoBehaviour {

    public Text timeText;
    public static int playTime = 0; // to manipulate time - used to store later in playerprefs
    private int seconds = 0;
    private int minutes = 0;
    private int hours = 0;

	// Use this for initialization
	void Start ()
    {
        timeText = GameObject.Find("Timestamp").GetComponent<Text>();
        StartCoroutine("Playtimer");
	}

    private IEnumerator Playtimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            playTime += 1;
            seconds = (playTime % 60);
            minutes = (playTime / 60) % 60;
            hours = (playTime / 3600) % 24;
        }
    }

    void Update()
    {
        timeText.text = hours.ToString() + ":" + minutes.ToString() + ":" + seconds.ToString();
    }


}
