using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public List<GameObject> coverObjects;
	public List<GameObject> enemyObjects;
	public GameObject player;
	// Use this for initialization
	void Start () {
		//Need to instantiate objects as gameobjects or you cannot get the individual position of each one, only the general position for the prefab
		createCover();
		createEnemies();
	}

	// Update is called once per frame
	void Update () {
		checkPlayerSeen();
	}

	private void createCover()
	{
		coverObjects[0] = Instantiate(coverObjects[0], new Vector3(25, 0, 0), coverObjects[0].transform.rotation) as GameObject;
		coverObjects[1] = Instantiate(coverObjects[1], new Vector3(15, 20, 0), coverObjects[1].transform.rotation) as GameObject;
		coverObjects[2] = Instantiate(coverObjects[2], new Vector3(-10, 5, 0), coverObjects[2].transform.rotation) as GameObject;
		coverObjects[3] = Instantiate(coverObjects[3], new Vector3(-10, -15, 0), coverObjects[3].transform.rotation) as GameObject;
	}

	private void createEnemies()
	{
		enemyObjects[0] = Instantiate(enemyObjects[0], new Vector3(20, 0, 0), enemyObjects[0].transform.rotation) as GameObject;
		enemyObjects[1] = Instantiate(enemyObjects[1], new Vector3(15, 25, 0), enemyObjects[1].transform.rotation) as GameObject;
		enemyObjects[2] = Instantiate(enemyObjects[2], new Vector3(-10, 10, 0), enemyObjects[2].transform.rotation) as GameObject;
		foreach(GameObject enemy in enemyObjects)
		{
			enemy.GetComponent<Enemy>().playerGameObj = player;
		}
	}

	private void checkPlayerSeen()
	{
		if(player.GetComponent<Player>().Visible)
		{
			foreach (GameObject enemy in enemyObjects)
			{
				enemy.GetComponent<Enemy>().checkPlayerVisibility();
			}
		}
	}
	
}
