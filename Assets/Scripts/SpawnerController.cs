using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnerController : MonoBehaviour {

    public GameObject[] Ones;
    public GameObject ShockWave;
    private List<GameObject> notes;
    private Transform TOfFather;
    private const float BOTTOM_LINE = -14.1025f;
    private const float HEAD_LINE = 17.0f;
    private const float tmp_BOTTOM_LINE = 0;

    private List<GameObject> shockwaves;
    private List<int> dieYoung;

    private int whichRoad = -1;

    private bool isHit = false;

    private const float BEGIN_TO_FADE_LINE = 7f;
    private const float FADING_RATE = 0.1f;

    //private GameObject scoreboard;

    // Use this for initialization
    void Start () {
        notes = new List<GameObject>();
        dieYoung = new List<int>();
        TOfFather = GameObject.Find("ImageTarget").GetComponent<Transform>();
        shockwaves = new List<GameObject>();
    }
	
	// Update is called once per frame
	void Update () {



        for (int i = 0; i < dieYoung.Count; i++)
        {
            dieYoung[i]--;
            if (dieYoung[i] < 1)
            {
                GameObject nevermind = shockwaves[0];
                shockwaves.RemoveAt(0);
                Destroy(nevermind);
                whichRoad = -1;
                dieYoung.RemoveAt(i);
                i--;
            }
        }
        if ((notes[0].GetComponent<Transform>().position.z) < HEAD_LINE)
        {
            if (notes[0].GetComponent<Transform>().position.x == 0)
                whichRoad = 2;
            else if (notes[0].GetComponent<Transform>().position.x < 0)
                whichRoad = 1;
            else
                whichRoad = 3;
            GameObject.Find("ImageTarget").GetComponent<DrumVBHandler>().setIsHitFalse();
        }
        if ((notes[0].GetComponent<Transform>().position.z) < BEGIN_TO_FADE_LINE)
        {
            if (!isHit)
            {
                Color tmpC = notes[0].GetComponent<Renderer>().material.color;
                if (tmpC.a > 0)
                {
                    notes[0].GetComponent<Renderer>().material.color = new Color(tmpC.r, tmpC.g, tmpC.b, tmpC.a - FADING_RATE);
                }
            }
        }
        if ((notes[0].GetComponent<Transform>().position.z) < BOTTOM_LINE)
        {
            destroyHead();
            if (dieYoung.Count > 0)
            {
                dieYoung.RemoveAt(0);
            }
            whichRoad = -1;
            isHit = false;
        }        
	}
    public void setIsHit()
    {
        isHit = true;
    }    
    public int WhichArrived()
    {        
        return whichRoad;
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
        if ((notes[0].GetComponent<Transform>().position.z) < HEAD_LINE) {
            if (notes.Count > dieYoung.Count)
            {
                GameObject tmpTI = GameObject.Find("ImageTarget");
                shockwaves.Add(Instantiate(ShockWave, notes[0].GetComponent<Rigidbody>().position, new Quaternion(), tmpTI.GetComponent<Transform>()));
                destroyHead();
                int lifeLeft = 15;          //frames left to destroy the head of the shockwaves
                dieYoung.Add(lifeLeft);
                return true;
            }
        }
        return false;
    }

    private void destroyHead()
    {
        GameObject nevermind = notes[0];
        notes.RemoveAt(0);
        Destroy(nevermind);
    }

}
