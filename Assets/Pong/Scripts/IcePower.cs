using UnityEngine;

public class IcePower : MonoBehaviour
{
   //figure out what side ur on and change side
    public GameObject left;
    public GameObject right;
    public Paddle ll;
    public Paddle rr;
    private string side;
    private string affectedSide;

    private float timer = 5f;
    private bool isActive= false;

    void Start()
    {
        left = GameObject.Find("Left Paddle");
        ll= left.GetComponent<Paddle>();
        right = GameObject.Find("Right Paddle");
        rr= right.GetComponent<Paddle>();
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
        transform.position = new Vector3(10,10,10);


    }
    void StartPowerUp()
    {
        isActive = true;
        if (side.Equals("right"))
        {
            ll.speed = ll.speed / 2;

        }
        else
        {
            rr.speed = rr.speed / 2;
        }
        
    }

    void EndPowerUp()
    {
        Debug.Log("power over");
        isActive = false;
        if (side.Equals("right"))
        {
            ll.speed = 3;

        }
        else
        {
            rr.speed = 3;
        }

        this.gameObject.SetActive(false);
    }
}
