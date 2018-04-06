using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float x_force = 100f;
    public float y_force = 10f;

    private Rigidbody2D rBody;

	// Use this for initialization
	public void Start () {
        StartCoroutine(throwBall(2));
	}

    public void Update()
    {
        float xVel = rBody.velocity.x;
        if(xVel < 18 && xVel > -18 && xVel != 0)
        {
            if(xVel > 0)
            {
                rBody.velocity = new Vector2(20, rBody.velocity.y);
            }
            else if (xVel < 0)
            {
                rBody.velocity = new Vector2(-20, rBody.velocity.y);
            }
        }
        Debug.Log("velocity before: " + xVel);
        Debug.Log("Velocity after: " + rBody.velocity.x);
    }

    private IEnumerator throwBall(float delay)
    {
        rBody = this.GetComponent<Rigidbody2D>();

        yield return new WaitForSeconds(delay);

        var randomNumber = Random.Range(0, 1 + 1); // max exclusive
        if (randomNumber <= 0.5f)
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

            //play sound
        }
    }

    public void ResetBall()
    {
        rBody.velocity = new Vector2(0, 0);
        transform.position = new Vector3(0, 0, 0);

       StartCoroutine(throwBall(0.5f));
    }

}
