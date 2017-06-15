using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawnScript : MonoBehaviour {

    public GameObject bonus;
	// Use this for initialization
    private bool isSpawning = false;
	void Update () {
        if (!isSpawning)
        {
            var spawnPos = Random.Range(-4.5f, 4.5f);
            isSpawning = true;
            bonus.transform.position = new Vector3(spawnPos, 0.94f, 40.0f);
            StartCoroutine(waitForSeconds());
            
        }         
	}
	
    IEnumerator waitForSeconds()
    {
        yield return new WaitForSeconds(Random.Range(1, 2));
        Instantiate(bonus);
        isSpawning = false;
    }
	// Update is called once per frame
	void Start () {
		
	}
}
