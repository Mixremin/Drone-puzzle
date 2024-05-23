using Player;
using UnityEngine;

public class Door : MonoBehaviour
{



    private int trDoorOpen = Animator.StringToHash("DoorOpen");
    private int trDoorClose = Animator.StringToHash("DoorClose");
    private Animator animator;
    private AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider c)
    {
        openDoor(c);
    }

    private void OnTriggerExit(Collider c)
    {
        closeDoor(c);
    }

    public void openDoor(Collider c)
    {
        if (c.TryGetComponent<FirstPersonMovement>(out _))
        {
            audioSource.Play();
            animator.SetTrigger(trDoorOpen);

        }
    }
    public void closeDoor(Collider c)
    {
        if (c.TryGetComponent<FirstPersonMovement>(out _))
        {
            audioSource.Play();
            animator.SetTrigger(trDoorClose);
        }
    }


}
