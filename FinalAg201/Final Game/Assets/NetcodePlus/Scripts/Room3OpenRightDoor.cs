using UnityEngine;

public class Room3OpenRightDoor : MonoBehaviour
{
    [SerializeField] private Animator OpenDoorAnimator;

    void Start()
    {
    }

    void Update()
    {
        OpeenDoor();
    }

    public void OpeenDoor()
    {
        if (RedCube.Instance.isTrigger && BlueCube.Instance.isTrigger &&
             GreenCube.Instance.isTrigger && YellowCube.Instance.isTrigger)
        {
            OpenDoorAnimator.SetTrigger("OpenDoor");
            Debug.Log("opendoor");
        }
    }
}
