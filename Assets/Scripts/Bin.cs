using UnityEngine;

public class Bin : MonoBehaviour
{
    [SerializeField] AudioClip collectsound;
    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Bug bug = other.GetComponent<Bug>();

        if (bug != null && bug.IsHeld())
        {
            GameManager.Instance.BugCollected();
            if (audioSource != null && collectsound != null)
            {
                audioSource.PlayOneShot(collectsound);
            }
            Destroy(other.gameObject);
        }
    }
}