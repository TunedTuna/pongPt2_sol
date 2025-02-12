using UnityEngine;

public class PowerSpawnerRules : MonoBehaviour
{
    public GameObject icePrefab;
    public GameObject mirrorPrefab;
    public Transform spawnA;
    public Transform spawnB;
    public Transform spawnC;
    public Transform spawnD;

    private System.Random random;
    Transform[] locationList;
    private GameObject power;

    private bool spotA=false;
    private bool spotB=false;
    private bool spotC = false;
    private bool spotD = false;
    private bool[] spotList;

    private bool urGood = false;

    private MirrorPower mirrorScript;
    private IcePower iceScript;

    private void Start()
    {
        spotList= new bool[] {spotA, spotB,spotC, spotD};
    }



    void Update()
    {
       
        
    }
    public void spawnPower()
    {
        //if all spot list are ocuppied, dont spawn a power
        if (!spotList[0] ||
            !spotList[1] ||
            !spotList[2] ||
            !spotList[3])
        {
            locationList = new Transform[] { spawnA, spawnB, spawnC, spawnD };
            int spot = Random.Range(0, locationList.Length);
            Transform randomSpawn;
            while (!urGood)
            {
                if (spotList[spot] == false)//if the spot is empty
                {
                    changeSpot(true, spot);//occupy location
                    urGood = true;
                }
                else
                {
                    spot = Random.Range(0, locationList.Length);
                }
            }
            urGood = false;//reset this 
            randomSpawn = locationList[spot];//out here cus unity cant see inside 'while'?



            int rand = Random.Range(0, 2);
            if (rand == 0)
            {
                power = icePrefab;
                iceScript = power.GetComponent<IcePower>();
                iceScript.id = spot;


            }
            else
            {
                power = mirrorPrefab;
                mirrorScript = power.GetComponent<MirrorPower>();
                mirrorScript.id = spot;
            }


            Quaternion spawnRotate = Quaternion.Euler(-90, 0, 0);
            GameObject newObj = Instantiate(power, randomSpawn.position, spawnRotate);
        }
        else
        {
            Debug.Log("Slots filled!");
        }

    }

    public void changeSpot(bool temp, int spot)
    {
        spotList[spot] = temp;
    }
}
