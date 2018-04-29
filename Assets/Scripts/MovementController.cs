using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    private GameObject theBall, scoreboard;
    private Rigidbody rb;
    private System.DateTime begintime;
    private float step;
    private System.DateTime lastUpdateTime;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        theBall = GameObject.Find("test4moving");
        scoreboard = GameObject.Find("ScoreBoard");
        theBall.GetComponent<TextMesh>().text = "***";
        begintime = System.DateTime.Now;
        step = 1.56695f;
        lastUpdateTime = System.DateTime.Now;
    }
	
	// Update is called once per frame
    void Update ()
    {
        System.DateTime tmp = System.DateTime.Now;
        double gap = (tmp - lastUpdateTime).TotalMilliseconds;
        lastUpdateTime = tmp;        
        Move(step * gap * 3.0 / 50.0 );
    }

	void Move (double step_)
    {
        if (rb.position.z < -14.1025f)
        {
            System.DateTime tmp = System.DateTime.Now;
            scoreboard.GetComponent<TextMesh>().text = "" + ((tmp-begintime).TotalMilliseconds);
            rb.MovePosition(new Vector3(-16.7f, 0f, 133.5225f));
            //GameObject.Destroy(theBall);
            //theBall.name.
        }
        Vector3 movement = new Vector3();
        movement.Set(rb.position.x, rb.position.y, rb.position.z-(float)(step_));
        rb.MovePosition(movement);
        theBall.GetComponent<TextMesh>().text = movement.ToString();

        //theBall.GetComponent<TextMesh>().text = ""+(datetime.Millisecond-begintime);

    }
}
