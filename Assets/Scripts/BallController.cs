using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float x_force = 80f;
    public float y_force = 10f;

    private Rigidbody2D rBody;

	// Use this for initialization
	void Start () {
        rBody = this.GetComponent<Rigidbody2D>();

        var randomNumber = Random.Range(0, 1+1); // max exclusive
        if(randomNumber <= 0.5f)
        {
            //Debug.Log("Shoot right");
            rBody.AddForce(new Vector2(x_force, y_force));
        }
        else
        {
            //Debug.Log("Shoot left");
            rBody.AddForce(new Vector2(-x_force, -y_force));
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            //Debug.Log("It's working");
            var velY = rBody.velocity.y/2 
                + collision.collider.GetComponent<Rigidbody2D>().velocity.y/3;
            rBody.velocity = new Vector2(rBody.velocity.x, velY);
        }
    }
}
