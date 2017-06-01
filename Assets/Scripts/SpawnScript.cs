using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour
{
    public GameObject rock;
    public GameObject snowman;
    public GameObject fallenTree;
    public GameObject coin;

    float timeElapsed = 0;
    float coinSpawnCycle = 0.5f;

	float[] positions = {-3,-1.5f,0,1.5f,3};
	static int coinPosition = -1;
	static int spawnObstacle= 0;
	bool higher=false;

    void Update()
    {
		if (coinPosition == -1) {
			coinPosition = Random.Range (0, 5);
		}
        timeElapsed += Time.deltaTime;
		if (timeElapsed > coinSpawnCycle) {
			spawnObstacle++;
			GameObject temp;
				
			int positionDelta;
			positionDelta = Random.Range (0, 3);
			if (positionDelta == 0) {
				if (coinPosition != 0) {
					coinPosition--;
				}
			} else if (positionDelta == 2) {
				if (coinPosition != 4) {
					coinPosition++;
				}
			}

			if (spawnObstacle>3) {
				GameObject tempObstacle;
				int numberOfObstacles = Random.Range (1, 5);
				if (numberOfObstacles > 1){// == 3||numberOfObstacles==2) {
					int skipPosition = Random.Range(0, 3);
					higher = true;
					for (int i = 0; i < 3; i++) {
						if (numberOfObstacles == 3 || skipPosition != i) {
							int obstacleType = Random.Range (0, 2);
							if (obstacleType == 0 || (positions[i * 2] >= positions[coinPosition] - 2 && positions[i * 2] <= positions[coinPosition] + 2))
								tempObstacle = (GameObject)Instantiate (rock);
							else
								tempObstacle = (GameObject)Instantiate (snowman);
							Vector3 pos = tempObstacle.transform.position;
							tempObstacle.transform.position = new Vector3 (positions [i * 2], pos.y, pos.z);
						}
					}
				} else if (numberOfObstacles == 1) {
					int obstaclePosition = Random.Range (-1, 2)*3;
					if (obstaclePosition > coinPosition - 2 && obstaclePosition < coinPosition + 2) {//spawn under coin
						higher = true;
						tempObstacle = (GameObject)Instantiate (rock);
						Vector3 pos = tempObstacle.transform.position;
						tempObstacle.transform.position = new Vector3 (positions[coinPosition], pos.y, pos.z);
					} else {
						int obstacleType = Random.Range (0, 2);
						if(obstacleType==0)
							tempObstacle = (GameObject)Instantiate (rock);
						else
							tempObstacle = (GameObject)Instantiate (snowman);
						Vector3 pos = tempObstacle.transform.position;
						if(coinPosition<2)
							tempObstacle.transform.position = new Vector3 (3, pos.y, pos.z);
						else
							tempObstacle.transform.position = new Vector3 (-3, pos.y, pos.z);
					}
				}
				spawnObstacle = 0;
			}

			temp = (GameObject)Instantiate (coin);
			Vector3 coinPos = temp.transform.position;
			if(higher==true)
				temp.transform.position = new Vector3 (positions[coinPosition], coinPos.y+2, coinPos.z);
			else
				temp.transform.position = new Vector3 (positions[coinPosition], coinPos.y, coinPos.z);
			higher=false;

			timeElapsed -= coinSpawnCycle;
		}

    }
}

