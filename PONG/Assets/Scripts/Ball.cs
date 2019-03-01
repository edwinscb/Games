using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ball : MonoBehaviour
{
    //Managment
    public float ResetTime;
    //Won
    public Text Winner;
    //Movement
    int SpeedX;
    int SpeedY;
    public float Speed;
    
    //Score
    public Text ScorePlayerOne ;
    public Text ScorePlayerTwo;
    int Player1Score;
    int Player2Score;
    public int PointsWin;

    void Start() {
        ScorePlayerOne.text="0";
        ScorePlayerTwo.text = "0";

        MoveBall();
    }
    void MoveBall ()
    {
        

        SpeedX = Random.Range(0, 2);
        if (SpeedX == 0)
        {
            SpeedX = 1;
        }
        else
        {
            SpeedX = -1;
        }

        SpeedY = Random.Range(0, 2);
        if (SpeedY == 0)
        {
            SpeedY = 1;
        }
        else
        {
            SpeedY = -1;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(Speed * SpeedX, Speed * SpeedY);

    }

    // Update is called once per frame
    void Update()
    {
        
        ScorePlayerOne.text =Player1Score.ToString();
        ScorePlayerTwo.text = Player2Score.ToString();
        if (Player1Score==PointsWin) {
            Winner.text = "PLAYER 2 WON";
            Winner.gameObject.SetActive(true);
            ResetBall();
        }
        if (Player2Score ==PointsWin)
        {
            Winner.text = "PLAYER 1 WON";
            Winner.gameObject.SetActive(true);
            ResetBall();
        }
    }
    void ResetBall() {
        transform.localPosition =new Vector2(0,0);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

    }
    private void OnCollisionEnter2D(Collision2D thing)
    {
        if (thing.collider.tag=="Player1Goal") {
            Player1Score++;
            ResetBall();
            Invoke("MoveBall",ResetTime);
        }
        if (thing.collider.tag == "Player2Goal")
        {
            Player2Score++;
            ResetBall();
            Invoke("MoveBall", ResetTime);

        }
    }
}
