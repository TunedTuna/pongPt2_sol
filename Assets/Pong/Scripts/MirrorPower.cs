using UnityEngine;

public class MirrorPower : MonoBehaviour
{
    //figure out what side ur on and change side
    public GameObject left;
    public GameObject right;
    public Paddle ll;
    public Paddle rr;
    private string side;
    private string affectedSide;

    private float timer = 5f;
    private bool isActive = false;

    public Renderer leftRend;
    public Renderer rightRend;

    public Material effect;
    public Material original;

    void Start()
    {
        left = GameObject.Find("Left Paddle");
        ll = left.GetComponent<Paddle>();
        right = GameObject.Find("Right Paddle");
        rr = right.GetComponent<Paddle>();

        //material stuff
        leftRend = left.GetComponent<Renderer>();
        rightRend = right.GetComponent<Renderer>();

    }
    void Update()
    {
        if (isActive)
        {
            timer -= Time.deltaTime; // Count down
            Debug.Log(timer);

            if (timer <= 0)
            {
                EndPowerUp();

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (transform.position.x < 0) // If the power-up is on the left side
        {
            side = "left";
        }
        else
        {
            side = "right";
        }
        //if spawn on left, affect right

        StartPowerUp();
        // put out of scene to keep script running
        transform.position = new Vector3(10, 10, 10);


    }
    void StartPowerUp()
    {
        isActive = true;
        if (side.Equals("right"))
        {
            ll.inputAxis = "Mirror";
            leftRend.material = effect;

        }
        else
        {
            rr.inputAxis = "Mirror";
            rightRend.material = effect;
        }

    }

    void EndPowerUp()
    {
        Debug.Log("power over");
        isActive = false;
        if (side.Equals("right"))
        {
            ll.inputAxis = "LeftPaddle";
            leftRend.material = original;

        }
        else
        {
            rr.inputAxis = "RightPaddle";
            rightRend.material = original;
        }

        this.gameObject.SetActive(false);
    }
}
