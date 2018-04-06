using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static int Player1Score = 0;
    public static int Player2Score = 0;

    public GUISkin theSkin;
	
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

        Debug.Log("Player 1 score is " + Player1Score);
        Debug.Log("Player 1 score is " + Player1Score);
    }

    public void OnGUI()
    {
        GUI.skin = theSkin;
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 25, 100, 100), "" + Player1Score);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 25, 100, 100), "" + Player2Score);
    }
}
