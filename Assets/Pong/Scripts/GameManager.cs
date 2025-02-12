using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Transform ball;
    public float startSpeed = 3f;
    public GoalTrigger leftGoalTrigger;
    public GoalTrigger rightGoalTrigger;
    public Renderer floor;

    public TextMeshProUGUI leftscore;
    public TextMeshProUGUI rightscore;
    public TextMeshProUGUI winner;

    public Material lefty;
    public Material righty;

    int leftPlayerScore;
    int rightPlayerScore;
    Vector3 ballStartPos;
    

    const int scoreToWin = 11;

    //---------------------------------------------------------------------------
    void Start()
    {
        ballStartPos = ball.position;
        Rigidbody ballBody = ball.GetComponent<Rigidbody>();
        ballBody.linearVelocity = new Vector3(1f, 0f, 0f) * startSpeed;
    }

    //---------------------------------------------------------------------------
    public void OnGoalTrigger(GoalTrigger trigger)
    {
        // If the ball entered a goal area, increment the score, check for win, and reset the ball


        if (trigger == leftGoalTrigger)
        {
            rightPlayerScore++;
            Debug.Log($"Right player scored: {rightPlayerScore}");
            rightscore.text ="score "+rightPlayerScore.ToString();
            StartCoroutine(ColorChange(rightscore));
            floor.material = lefty;
            

            if (rightPlayerScore == scoreToWin)
            {
                
                Debug.Log("Right player wins!");
                winner.text = "Right player wins!";
                rightscore.color = Color.yellow;
            }
            else
                ResetBall(-1f);
        }
        else if (trigger == rightGoalTrigger)
        {
            leftPlayerScore++;
            Debug.Log($"Left player scored: {leftPlayerScore}");
            leftscore.text = "score " + leftPlayerScore.ToString();
            floor.material = righty;
           
            StartCoroutine(ColorChange(leftscore));

            if (leftPlayerScore == scoreToWin)
            {
                Debug.Log("Left player wins!");
                leftscore.color = Color.yellow;
                winner.text = "Left player wins!";
            }
                
            else
                ResetBall(1f);
        }
    }

    //---------------------------------------------------------------------------
    void ResetBall(float directionSign)
    {
        ball.position = ballStartPos;

        // Start the ball within 20 degrees off-center toward direction indicated by directionSign
        directionSign = Mathf.Sign(directionSign);
        Vector3 newDirection = new Vector3(directionSign, 0f, 0f) * startSpeed;
        newDirection = Quaternion.Euler(0f, Random.Range(-20f, 20f), 0f) * newDirection;

        var rbody = ball.GetComponent<Rigidbody>();
        rbody.linearVelocity = newDirection;
        rbody.angularVelocity = new Vector3();

        // We are warping the ball to a new location, start the trail over
        ball.GetComponent<TrailRenderer>().Clear();
    }

    //=============================================================================
    private IEnumerator ColorChange(TextMeshProUGUI temp)
    {
        temp.color = Color.yellow;
        yield return new WaitForSeconds(1f);
        float elapsedTime = 0f;
        float duration = 1f;
        while (elapsedTime < duration) 
        { 
            temp.color=Color.Lerp(Color.yellow,Color.white,elapsedTime/duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        temp.color=Color.white;

    }
}
