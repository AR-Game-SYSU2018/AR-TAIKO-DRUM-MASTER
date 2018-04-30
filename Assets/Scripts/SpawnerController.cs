using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnerController : MonoBehaviour {

    public GameObject[] Ones;
    public GameObject ShockWave;
    private List<GameObject> notes;
    private Transform TOfFather;
    private const float BOTTOM_LINE = -14.1025f;
    private const float tmp_BOTTOM_LINE = 0;
    private List<int> dieYoung;

    //private GameObject scoreboard;

    // Use this for initialization
    void Start () {
        notes = new List<GameObject>();
        dieYoung = new List<int>();
        TOfFather = GameObject.Find("ImageTarget").GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < dieYoung.Count; i++)
        {
            dieYoung[i]--;
            if (dieYoung[i] < 1)
            {
                GameObject nevermind = notes[0];
                notes.RemoveAt(0);
                Destroy(nevermind);
                dieYoung.RemoveAt(i);
                i--;
            }
        }
		foreach (GameObject tmpGO in notes)
        {
            if ((tmpGO.GetComponent<Transform>().position.z) < BOTTOM_LINE)
            {
                GameObject nevermind = notes[0];
                notes.RemoveAt(0);
                Destroy(nevermind);
                if (dieYoung.Count > 0)
                {
                    dieYoung.RemoveAt(0);
                }
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
        tmpGO.GetComponent<Transform>().SetParent(TOfFather);
        notes.Add(tmpGO);
        return true;
    }

    public bool faceDeath()
    {
        if (notes.Count > dieYoung.Count)
        {
            GameObject tmpGO = notes[dieYoung.Count];
            Instantiate(ShockWave, tmpGO.GetComponent<Rigidbody>().position, new Quaternion(), tmpGO.GetComponent<Transform>());
            int lifeLeft = 15;          //frames left to destroy the head of the notes
            dieYoung.Add(lifeLeft);
            return true;
        }
        return false;
    }

}
