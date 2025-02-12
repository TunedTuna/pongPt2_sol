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
    


    void Update()
    {
       
        
    }
    public void spawnPower()
    {
        int rand = Random.Range(0, 2);
        if(rand== 0)
        {
            power = icePrefab;
        }
        else
        {
            power = mirrorPrefab;
        }
        locationList = new Transform[] { spawnA, spawnB, spawnC, spawnD };
        Transform randomSpawn = locationList[Random.Range(0, locationList.Length)];
        Quaternion spawnRotate = Quaternion.Euler(-90,0,0);
        GameObject newObj = Instantiate(power, randomSpawn.position, spawnRotate);
    }

    public void checkSpot(bool temp)
    {

    }
}
