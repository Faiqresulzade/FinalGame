using UnityEngine;

public class OpenLever : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject UIOpenLever;
    [SerializeField]
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIOpenLever.SetActive(true);
            if (Input.GetKeyDown(KeyCode.O))
            {
                animator.SetTrigger("OpenLever");
            }
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
             UIOpenLever.SetActive(false);
        }
    }
}
