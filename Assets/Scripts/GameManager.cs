using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static int Player1Score = 0;
    public static int Player2Score = 0;
    public static Transform ball;

    public GUISkin theSkin;
    //public Transform ball;

    public void Start()
    {
        ball = GameObject.FindGameObjectWithTag("ball").transform;
    }

    public static void Score (string wallName)
    {
	    if(wallName == "rightWall")
        {
            Player1Score += 1;
        }
        else if(wallName == "leftWall")
        {
            Player2Score += 1;
        }

        //Debug.Log("Player 1 score is " + Player1Score);
        //Debug.Log("Player 1 score is " + Player1Score);

    }

    public void OnGUI()
    {
        GUI.skin = theSkin;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 18, 25, 100, 100), "" + Player1Score);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 18, 25, 100, 100), "" + Player2Score);

        /* I'm going to do this different than the example
        if(GUI.Button(new Rect(Screen.width/2-121/2, 35, 121, 53), "RESET"))
        {
            Player1Score = 0;
            Player2Score = 0;
            GetComponent<GameSetup>().ball.GetComponent<BallController>().ResetBall();
        }
        */

        if (Player1Score > 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 25, Screen.height / 2, 100, 100), "PLAYER 1 WINS");
            Reset();
        }
        else if (Player2Score > 10)
        {
            GUI.Label(new Rect(Screen.width / 2 - 25, Screen.height / 2, 100, 100), "PLAYER 2 WINS");
            Reset();
        }
    }

    public static void Reset()
    {
            Player1Score = 0;
            Player2Score = 0;
            ball.GetComponent<BallController>().ResetBall(8f);
    }
}
