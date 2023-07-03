using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Detector : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Animator Opendooranimator;
    [SerializeField] private Animator Room3Opendooranimator;
    [SerializeField] private GameObject UIOpenLever;
    [SerializeField] private GameObject UIKeySetActive;
    [SerializeField] private GameObject UIPressOSetActive;

    public event Action OnDetectGround;
    public event Action<Collider> OnDetectFloorSwitch;
    public event Action<Collider> OnDetectPuzzleCube;
    public event Action<Collider,GameObject> OnDetectKey;
    public event Action<Animator,GameObject,GameObject> OnDetectRoom3OpenDoor;
    public event Action<Collider, Animator, GameObject, Animator> OnDetectOpenLever;

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
            OnDetectKey?.Invoke(other, UIKeySetActive);
        }

        if (other.CompareTag("FloorTrap"))
        {
            SceneManager.LoadScene(0);
        }

        if (other.CompareTag("Arrow"))
        {
            SceneManager.LoadScene(0);
        }
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("OpenLever"))
        {
            OnDetectOpenLever?.Invoke(other, animator, UIOpenLever, Opendooranimator);
        }
        if (other.CompareTag("Room3Door"))
        {
            Debug.Log(12);
            OnDetectRoom3OpenDoor.Invoke(Room3Opendooranimator, UIKeySetActive, UIPressOSetActive);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("OpenLever"))
        {
            UIOpenLever.SetActive(false);
        }

        if (other.CompareTag("Room3Door"))
        {
            Debug.Log(12340987654356);
            UIPressOSetActive.gameObject.SetActive(false);
        }
    }
}
