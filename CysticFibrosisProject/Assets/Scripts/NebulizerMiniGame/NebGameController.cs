using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebGameController : MonoBehaviour {

    public GameObject monster;
    public GameObject target;
    public int monsterCount;
    public float spawnWave;
    public float startWait;
    public float waveWait;

    public Vector3 spawnValues;
    


	// Use this for initialization
	void Start () {

        StartCoroutine( SpawnWaves());
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true) {
            for (int i = 0; i < monsterCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                //Quaternion spawnRotation = Quaternion.identity;
                Quaternion spawnRotation = Quaternion.AngleAxis(180.0f, Vector3.up);
                Instantiate(monster, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWave);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }



}
