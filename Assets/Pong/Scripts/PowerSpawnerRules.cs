using UnityEngine;

public class PowerSpawnerRules : MonoBehaviour
{
    public GameObject powerPrefab;
    public Transform spawnA;
    public Transform spawnB;
    public Transform spawnC;
    public Transform spawnD;

    private System.Random random;
    Transform[] locationList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        locationList = new Transform[] {spawnA, spawnB, spawnC,spawnD};
        Transform randomSpawn = locationList[Random.Range(0, locationList.Length)];
        GameObject newObj = Instantiate(powerPrefab, randomSpawn.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
