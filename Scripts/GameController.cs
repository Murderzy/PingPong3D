using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Starting starting;
    [SerializeField]
    private TextMeshProUGUI scoreTextLeft;
    [SerializeField]
    private TextMeshProUGUI scoreTextRight;
    [SerializeField]
    private GameObject ball;

    private Ball ball_controller;

    private bool started = false;
    private int scoreLeft = 0;
    private int scoreRight = 0;
    private Vector3 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        this.ball_controller = this.ball.GetComponent<Ball>();
        this.startingPosition = this.ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Quite");
            Application.Quit();
            //this.ball_controller.Stop();

        }
        if (this.started) return;

        if(Input.GetKey(KeyCode.Space))
        {
            this.started = true;
            this.starting.StartCountdown();
        }

        
    }

    public void ScoreGoalLeft()
    {
        Debug.Log("ScoreGoalLeft");
        this.scoreRight += 1;
        updateUI();
        ResetBalll();
    }

    public void ScoreGoalRight()
    {
        Debug.Log("ScoreGoalRight");
        this.scoreLeft += 1;
        updateUI();
        ResetBalll();
    }

    private void updateUI()
    {
        this.scoreTextLeft.text = this.scoreLeft.ToString();
        this.scoreTextRight.text = this.scoreRight.ToString();
    }

    private void ResetBalll()
    {
        this.ball_controller.Stop();
        this.ball.transform.position = this.startingPosition;
        this.starting.StartCountdown();
    }

    public void StartGame()
    {
        this.ball_controller.Go();
    }
}
