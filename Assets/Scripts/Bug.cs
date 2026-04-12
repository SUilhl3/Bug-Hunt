using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Bug : MonoBehaviour
{
    XRGrabInteractable grabInteractable;
    bool isHeld = false;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        isHeld = true;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        isHeld = false;
    }

    public bool IsHeld()
    {
        return isHeld;
    }
}