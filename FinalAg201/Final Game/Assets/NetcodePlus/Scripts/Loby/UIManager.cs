using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private GameObject LobyPanel;
    [SerializeField] private GameObject Players;
    [SerializeField] private AudioSource BackroundMusic;
    [SerializeField] private Slider Slider;
    [SerializeField] private Image VolumeImage;
    [SerializeField] private Sprite MuteVolumeSprite;
    [SerializeField] private Sprite MediumVolumeSprite;
    [SerializeField] private Sprite MaxVolumeSprite;
    [SerializeField] private TMP_Dropdown DropdownChangeCharacter;


    private void Awake()
    {
        Slider.value = 1f;
    }

    public void ChangeVolumeValue()
    {
        BackroundMusic.volume = Slider.value;

        if (BackroundMusic.volume == 0)
        {
            VolumeImage.sprite = MuteVolumeSprite;
        }
        else if (BackroundMusic.volume > 0 && BackroundMusic.volume < 0.6)
        {
            VolumeImage.sprite = MediumVolumeSprite;
        }
        else
        {
            VolumeImage.sprite = MaxVolumeSprite;
        }

    }

    public void OnClickVolumeBTN()
    {
        if (BackroundMusic.volume > 0)
        {
            BackroundMusic.volume = 0;
            Slider.value = 0;
            VolumeImage.sprite = MuteVolumeSprite;
        }
        else
        {
            Slider.value = 1;
            BackroundMusic.volume = 1;
            VolumeImage.sprite = MaxVolumeSprite;
        }
    }

    public void OnClickPlayBTN()
    {
        SceneManager.LoadScene(1);
    }

    public void OnClickSettingsBTN()
    {
        SettingsPanel.SetActive(true);
        LobyPanel.SetActive(false);
    }

    public void BackSettingsPanel()
    {
        SettingsPanel.SetActive(false);
        LobyPanel.SetActive(true);
    }


    public void ChangeCharacter()
    {

        if (DropdownChangeCharacter.value == 1)
        {
           Scene scene= SceneManager.GetSceneAt(1);
           GameObject[] players=scene.GetRootGameObjects();

            for (int i = 0; i < players.Length; i++)
            {
               string name= players[i].name;
                if (name == "Players")
                {
                    players[i].transform.GetChild(3).gameObject.SetActive(true);
                }
            }


            //GameObject players = GameObject.Find("ExplorerRed");
            //players.gameObject.SetActive(true);
        }
    }
}
