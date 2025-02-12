using System.Net.Security;
using UnityEngine;

public class IcePower : MonoBehaviour
{
   //figure out what side ur on and change side
    public GameObject left;
    public GameObject right;
    public Paddle ll;
    public Paddle rr;
    public PowerSpawnerRules powerRules;
    private string side;

    private float timer = 5f;
    private bool isActive= false;

    public Renderer leftRend;
    public Renderer rightRend;

    public Material icy;
    public Material original;

    public int id;

    public AudioClip audioClip_chirp;
    AudioSource audioSource;

    void Start()
    {
        //GetComponent paddles
        left = GameObject.Find("Left Paddle");
        ll= left.GetComponent<Paddle>();
        right = GameObject.Find("Right Paddle");
        rr= right.GetComponent<Paddle>();

        //material stuff
        leftRend=left.GetComponent<Renderer>();
        rightRend=right.GetComponent<Renderer>();

        powerRules = GameObject.Find("PowerSpawner").GetComponent<PowerSpawnerRules>();
        audioSource = GetComponent<AudioSource>();





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
        transform.position = new Vector3(10,10,10);


    }
    void StartPowerUp()
    {
        audioSource.clip = audioClip_chirp;
        audioSource.Play();
        isActive = true;
        if (side.Equals("right"))
        {
            ll.speed = ll.speed / 2;
            leftRend.material = icy;

        }
        else
        {
            rr.speed = rr.speed / 2;
            rightRend.material = icy;
        }
        
    }

    void EndPowerUp()
    {
        Debug.Log("power over");
        isActive = false;
        if (side.Equals("right"))
        {
            ll.speed = 3;
            leftRend.material = original;

        }
        else
        {
            rr.speed = 3;
            rightRend.material = original;
        }
        powerRules.changeSpot(false,id);
        this.gameObject.SetActive(false);
    }
}
