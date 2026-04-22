using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Bug : MonoBehaviour
{
    static Bug currentlyHeldBug = null;

    XRGrabInteractable grab;
    Rigidbody rb;

    [SerializeField] Transform holdPoint;
    [SerializeField] AudioClip collectSound;
    [SerializeField] AudioSource collectSource;

    bool isHeld = false;

    void Awake()
    {
        grab = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
        collectSource = GetComponent<AudioSource>();

        grab.selectEntered.AddListener(OnGrabPressed);
    }

    void OnDestroy()
    {
        grab.selectEntered.RemoveListener(OnGrabPressed);
    }

    void OnGrabPressed(SelectEnterEventArgs args)
    {
        if (!isHeld && currentlyHeldBug == null)
        {
            PickUp();
        }
        else if (isHeld)
        {
            Drop();
        }
    }

    void PickUp()
    {
        isHeld = true;
        currentlyHeldBug = this;

        collectSource.PlayOneShot(collectSound);

        rb.isKinematic = true;

        grab.enabled = false;
    }

    void Drop()
    {
        isHeld = false;
        currentlyHeldBug = null;

        rb.isKinematic = false;

        grab.enabled = true;
    }

    void Update()
    {
        if (isHeld && holdPoint != null)
        {
            transform.position = holdPoint.position;
            transform.rotation = holdPoint.rotation;
        }
    }

    public bool IsHeld()
    {
        return isHeld;
    }
}