using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowScoreText : MonoBehaviour {
    public GameObject obj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowText()
    {
        GameObject scoreboard = GameObject.Find("ScoreBoard");
        string score = scoreboard.GetComponentInChildren<TextMesh>().text;

        Vector3 TempPos = new Vector3(0f, 0f, 0f);
        GameObject scoreText = Instantiate(obj);
        scoreText.GetComponent<TextMesh>().text = "Your Score: " + score;

        scoreText.transform.SetParent(GameObject.Find("Canvas").GetComponent<Transform>(), false);
    }
}
