using UnityEngine;

public class Bin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Bug bug = other.GetComponent<Bug>();

        if (bug != null && bug.IsHeld())
        {
            GameManager.Instance.BugCollected();

            Destroy(other.gameObject); // remove bug
        }
    }
}