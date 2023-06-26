using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Detector : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Animator Opendooranimator;
    [SerializeField] private GameObject UIOpenLever;

    public event Action OnDetectGround;
    public event Action<Collider> OnDetectFloorSwitch;
    public event Action<Collider> OnDetectPuzzleCube;
    public event Action<Collider, Animator, GameObject,Animator> OnDetectOpenLever;

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
            OnDetectPuzzleCube.Invoke(other);
        }

        if (other.CompareTag("FloorTrap"))
        {
           // OnDetectFloorTrap?.Invoke(other);
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("OpenLever"))
        {
            OnDetectOpenLever?.Invoke(other, animator, UIOpenLever, Opendooranimator);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("OpenLever"))
        {
            UIOpenLever.SetActive(false);
        }
    }
}
