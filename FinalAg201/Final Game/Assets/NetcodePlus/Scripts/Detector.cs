using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Detector : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Animator Opendooranimator;
    [SerializeField] private Animator Room3OpendoorWithKeyAnimator;
    [SerializeField] private Animator Room3Opendooranimator;
    [SerializeField] private GameObject UIOpenLever;
    [SerializeField] private GameObject UIKeySetActive;
    [SerializeField] private GameObject UIPressOSetActive;
    [SerializeField] private GameObject Key;
    [SerializeField] private GameObject WinPanel;

    private int _count;

    public event Action OnDetectGround;
    public event Action<Collider> OnDetectFloorSwitch;
    public event Action<Collider> OnDetectPuzzleCube;
    public event Action<Collider,GameObject> OnDetectKey;
    public event Action<Animator,GameObject,GameObject> OnDetectRoom3OpenDoor;
    public event Action<Collider, Animator, GameObject, Animator> OnDetectOpenLever;
    public event Action<GameObject> OnDetectFinishCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            OnDetectGround?.Invoke();
        }

        if (other.CompareTag("FloorSwitch"))
        {
            OnDetectFloorSwitch?.Invoke(other);
        }

        if (other.CompareTag("Room3Door"))
        {
            OnDetectPuzzleCube?.Invoke(other);
        }

        if (other.CompareTag("Key"))
        {
            _count++;
            OnDetectKey?.Invoke(other, Key);
           // Key.gameObject.SetActive(true);
        }

        if (other.CompareTag("FloorTrap"))
        {
            SceneManager.LoadScene(0);
        }

        if (other.CompareTag("Arrow"))
        {
            SceneManager.LoadScene(0);
        }

        if (other.CompareTag("FinishEmptyCollider"))
        {
            Debug.Log("Finish");
            OnDetectFinishCollider?.Invoke(WinPanel);
        }
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("OpenLever"))
        {
            OnDetectOpenLever?.Invoke(other, animator, UIOpenLever, Opendooranimator);
        }
        if (other.CompareTag("Room3DoorwithKey"))
        {
            if (_count != 0)
            {
                UIPressOSetActive.SetActive(true);

                if (Input.GetKeyDown(KeyCode.O))
                {
                    Room3OpendoorWithKeyAnimator.SetBool("IsOpen", true);
                    Key.SetActive(false);
                }
            }
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("OpenLever"))
        {
            UIOpenLever.SetActive(false);
        }

        if (other.CompareTag("Room3DoorwithKey"))
        {
            Debug.Log(12340987654356);
            UIPressOSetActive.gameObject.SetActive(false);
        }
    }
}
