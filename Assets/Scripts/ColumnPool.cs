﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {

    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-14, 0);
    private float timeSinceLastSpawned;
    public float spwanRate;
    public float columnMin = -2.9f;
    public float columnMax = 1.4f;
    private float spawnXPosition = 10;
    private int currentColumn = 0;
	// Use this for ini tialization
	void Start () {
        columns = new GameObject[columnPoolSize];

        for (int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawned += Time.deltaTime;

        if (!GameController.instance.gameOver && timeSinceLastSpawned >= spwanRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;

            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
	}
}
