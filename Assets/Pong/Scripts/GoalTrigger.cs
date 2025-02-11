using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public AudioClip audioClip_goal;
    AudioSource audioSource;

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
    }
}
