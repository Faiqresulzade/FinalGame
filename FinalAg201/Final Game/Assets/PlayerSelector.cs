using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    void Start()
    {
        transform.GetChild(UIManager.SelectedPlayer).gameObject.SetActive(true);
    }

}
