using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    
    private Rigidbody rb;
    private float STEP;
    private System.DateTime lastUpdateTime;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        lastUpdateTime = System.DateTime.Now;
        STEP = 1.56695f;
    }
	
	// Update is called once per frame
    void Update ()
    {
        System.DateTime tmp = System.DateTime.Now;
        double gap = (tmp - lastUpdateTime).TotalMilliseconds;
        lastUpdateTime = tmp;        
        Move(STEP * gap * 3.0 / 50.0 );
    }

	void Move (double step_)
    {
        Vector3 movement = new Vector3();
        movement.Set(rb.position.x, rb.position.y, rb.position.z-(float)(step_));
        rb.MovePosition(movement);
    }

    //publ
}
