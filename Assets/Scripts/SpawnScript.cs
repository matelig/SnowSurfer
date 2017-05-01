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
    bool spawnPowerup = true;

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > spawnCycle)
        {
            GameObject temp;
            if (spawnPowerup)
            {
                temp = (GameObject)Instantiate(powerup);
                Vector3 pos = temp.transform.position;
                switch (Random.Range(0, 3))
                {
                    case 0:
                        temp.transform.position = new Vector3(-3, pos.y, pos.z);
                        break;
                    case 1:
                        temp.transform.position = new Vector3(0, pos.y, pos.z);
                        break;
                    case 2:
                        temp.transform.position = new Vector3(3, pos.y, pos.z);
                        break;
                }
            }
            else
            {
                temp = (GameObject)Instantiate(rock);
                Vector3 pos = temp.transform.position;
                switch (Random.Range(0,3))
                {
                    case 0: temp.transform.position = new Vector3(-3, pos.y, pos.z);
                        break;
                    case 1: temp.transform.position = new Vector3(0, pos.y, pos.z);
                        break;
                    case 2: temp.transform.position = new Vector3(3, pos.y, pos.z);
                        break;
                }
                
                        
                
            }

            timeElapsed -= spawnCycle;
            spawnPowerup = !spawnPowerup;
        }
    }
}