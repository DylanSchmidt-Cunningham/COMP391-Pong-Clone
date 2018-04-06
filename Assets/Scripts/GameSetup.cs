using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour {

    public Camera mainCamera;

    public BoxCollider2D topWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;

    public Transform Player1;
    public Transform Player2;

    public Transform net;
    public Transform ball;
	
	void Start () {
        //set up walls
        topWall.size = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        topWall.offset = new Vector2(0f, mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y + 0.5f);

        bottomWall.size = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width * 2f, 0f, 0f)).x, 1f);
        bottomWall.offset = new Vector2(0f, mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).y - 0.5f);

        leftWall.size = new Vector2(1f, mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        leftWall.offset = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x - 0.5f, 0f);

        rightWall.size = new Vector2(1f, mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height * 2f, 0f)).y);
        rightWall.offset = new Vector2(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x + 0.5f, 0f);

        Player1.position = new Vector3(mainCamera.ScreenToWorldPoint(new Vector3(50f, 0f, 0f)).x, 0f, 0f);
        Player2.position = new Vector3(mainCamera.ScreenToWorldPoint(new Vector3(Screen.width - 50f, 0f, 0f)).x, 0f, 0f);

        // find the screen's ratio compared to the assets and scale everything
        float screenToNetRatio = mainCamera.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y / net.GetComponent<SpriteRenderer>().sprite.bounds.extents.y;

        net.localScale  = new Vector3(screenToNetRatio, screenToNetRatio, 0f);
        ball.localScale = new Vector3(screenToNetRatio, screenToNetRatio, 0f);
        ball.GetComponent<BallController>().x_force *= screenToNetRatio;
        ball.GetComponent<BallController>().y_force *= screenToNetRatio;
        Player1.localScale = new Vector3(screenToNetRatio * Player1.localScale.x, screenToNetRatio * Player1.localScale.y, 0f);
        Player2.localScale = new Vector3(screenToNetRatio * Player2.localScale.x, screenToNetRatio * Player2.localScale.y, 0f);
        //GetComponent<GameManager>().theSkin.label.fontSize = (int) Mathf.Ceil(GetComponent<GameManager>().theSkin.label.fontSize * screenToNetRatio);


    }
}
