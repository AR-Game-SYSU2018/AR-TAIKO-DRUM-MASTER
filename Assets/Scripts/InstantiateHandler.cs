using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateHandler : MonoBehaviour {

    public int[,] array;

    // Use this for initialization
    void Start () {
        StartInstantiate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    int[,] CreateRandomArray()
    {
        int[,] array = new int[100, 2];
        System.Random rd = new System.Random();
        for (int i = 0; i < 100; i++)
        {
            array[i, 0] = rd.Next(500, 1501);
            array[i, 1] = rd.Next(1, 4);
        }
        return array;
    }

    void StartInstantiate()
    {
        array = CreateRandomArray();
        InstantiatePrefabs(array, 0);
    }

    IEnumerator InstantiatePrefab(int [,]array, int currentIndex)
    {
        if (currentIndex < array.GetLength(0))
        {
            yield return new WaitForSeconds(((float)array[currentIndex, 0]) / 1000);
            FindObjectOfType<SpawnerController>().spawnOn(array[currentIndex, 1]);
            currentIndex++;
            InstantiatePrefabs(array, currentIndex);
        }
    }

    void InstantiatePrefabs(int[,] array, int currentIndex)
    {
        if (currentIndex < array.GetLength(0))
        {
            StartCoroutine(InstantiatePrefab(array, currentIndex));
        }
    }
}
