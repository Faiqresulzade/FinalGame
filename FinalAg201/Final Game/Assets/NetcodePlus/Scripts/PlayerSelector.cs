using Cinemachine;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    [SerializeField] private GameObject PlayerYellow;
    [SerializeField] private GameObject PlayerRed;
    [SerializeField] private GameObject PlayerGreen;

    void Start()
    {
        transform.GetChild(UIManager.SelectedPlayer).gameObject.SetActive(true);

    }

    private void Update()
    {
        cinemachineVirtualCamera.Follow = transform.GetChild(UIManager.SelectedPlayer);
        cinemachineVirtualCamera.LookAt = transform.GetChild(UIManager.SelectedPlayer);
    }

}
