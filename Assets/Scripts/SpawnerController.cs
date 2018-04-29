using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnerController : MonoBehaviour {

    public GameObject[] Ones;
    private Queue<GameObject> notes;
    private Transform TOfFather;
    private const float BOTTOM_LINE = -14.1025f;

    //private GameObject scoreboard;

    // Use this for initialization
    void Start () {
        notes = new Queue<GameObject>();
        TOfFather = GameObject.Find("ImageTarget").GetComponent<Transform>();

        //scoreboard = GameObject.Find("ScoreBoard");
    }
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject tmpGO in notes)
        {
            if ((tmpGO.GetComponent<Transform>().position.z) < BOTTOM_LINE)
            {/*
                int tmpInt = 0;
                if (tmpGO.GetComponent<Transform>().position.x < 0)
                {
                    tmpInt = 1;
                }
                else if (tmpGO.GetComponent<Transform>().position.x > 0)
                {
                    tmpInt = 3;
                }
                else
                {
                    tmpInt = 2;
                }
                scoreboard.GetComponent<TextMesh>().text = "" + tmpInt;
                */
                Destroy(notes.Dequeue());
                continue;
            }
        }
	}

    public bool spawnOn(int n)
    {
        if (n > 3 || n < 0)
        {
            return false;
        }
        GameObject tmpGO = Instantiate(Ones[n-1], TOfFather);
        notes.Enqueue(tmpGO);
        return true;
    }

}
