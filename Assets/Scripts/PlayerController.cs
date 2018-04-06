using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public KeyCode up;
    public KeyCode down;
    public float speed = 10.0f;

    private Rigidbody2D rBody;

    public void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(up))
        {
            rBody.velocity = new Vector2(0, speed);
        }
        else if (Input.GetKey(down))
        {
            rBody.velocity = new Vector2(0, -speed);
        }
        else
        {
            rBody.velocity = new Vector2(0, 0);
        }
	}
}
