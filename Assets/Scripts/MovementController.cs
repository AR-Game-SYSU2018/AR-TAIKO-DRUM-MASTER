using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    private GameObject theBall, scoreboard;
    private Rigidbody rb;
    private System.DateTime begintime;
    private float step;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        theBall = GameObject.Find("test4moving");
        scoreboard = GameObject.Find("ScoreBoard");
        theBall.GetComponent<TextMesh>().text = "***";
        begintime = System.DateTime.Now;
        step = 1.044f;
    }
	
	// Update is called once per frame
    void Update ()
    {
        Move();
    }

	void Move ()
    {
        if (rb.position.z < -7.5f)
        {
            System.DateTime tmp = System.DateTime.Now;
            scoreboard.GetComponent<TextMesh>().text = "" + ((tmp-begintime).TotalMilliseconds);
            //rb.MovePosition(new Vector3(-16.7f, 0f, 95.9f));
            GameObject.Destroy(theBall);
            //theBall.name.
        }
        Vector3 movement = new Vector3();
        movement.Set(rb.position.x, rb.position.y, rb.position.z-(step));
        rb.MovePosition(movement);
        //theBall.GetComponent<TextMesh>().text = movement.ToString();

        //theBall.GetComponent<TextMesh>().text = ""+(datetime.Millisecond-begintime);

    }
}
