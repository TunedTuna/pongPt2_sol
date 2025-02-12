using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public AudioClip audioClip_goal;
    AudioSource audioSource;

    public PowerSpawnerRules psr;

    private System.Random random;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    //---------------------------------------------------------------------------
    void OnTriggerEnter(Collider other)
    {
        gameManager.OnGoalTrigger(this);
        // play noise Goal
        audioSource.clip = audioClip_goal;
        audioSource.Play();

        int rand = Random.Range(0, 2);
        //int rand = 0;
        Debug.Log(rand);
        if (rand == 0)
        {
            psr.spawnPower();
        }
        
    }
}
