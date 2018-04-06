using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "ball")
        {
            GameManager.Score(transform.name); // this wall's name
            collision.GetComponent<BallController>().ResetBall();
        }
    }
}
