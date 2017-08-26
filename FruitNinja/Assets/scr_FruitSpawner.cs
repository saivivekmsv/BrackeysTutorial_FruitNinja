﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_FruitSpawner : MonoBehaviour {

    public GameObject fruitPrefab;
    public Transform[] spawnPoints;

    public float minDelay = 1f;
    public float maxDelay = 1f;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnFruits());
	}

    IEnumerator SpawnFruits()
    {
        while(true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(fruitPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);

        }
    }

}
