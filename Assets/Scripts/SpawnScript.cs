using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{
    public GameObject rock;
    public GameObject tree;
    public GameObject fallenTree;
    public GameObject powerup;

    float timeElapsed = 0;
    float spawnCycle = 1.0f;
	bool alreadySpawned;

    void Update()
    {
        timeElapsed += Time.deltaTime;
		if (timeElapsed > spawnCycle) {

			alreadySpawned = false;
			for (int i = 0; i < 3; i++) {
				GameObject temp;
				int objectType = Random.Range (0, 4);
				if (!alreadySpawned && i == 2) {

				} else if (objectType == 0) { //spawn powerup
					alreadySpawned = true;
					temp = (GameObject)Instantiate (powerup);
					Vector3 pos = temp.transform.position;
					temp.transform.position = new Vector3 (3 * (i - 1), pos.y, pos.z);
				} else if (objectType == 1) { //spawn obstacle 1
					temp = (GameObject)Instantiate (rock);
					Vector3 pos = temp.transform.position;
					temp.transform.position = new Vector3 (3 * (i - 1), pos.y, pos.z);
				} else if (objectType == 2) {//spawn obstacle 2
					temp = (GameObject)Instantiate (rock);//tree);
					Vector3 pos = temp.transform.position;
					temp.transform.position = new Vector3 (3 * (i - 1), pos.y, pos.z);
				} else if (objectType == 3) {//spawn obstacle 3
					temp = (GameObject)Instantiate (rock);//fallenTree);
					Vector3 pos = temp.transform.position;
					temp.transform.position = new Vector3 (3 * (i - 1), pos.y, pos.z);
				} else {
					alreadySpawned = true;
				}

				timeElapsed -= spawnCycle;
			}
		}
    }
}
