using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public partial class UIManager : MonoBehaviour
{

    //For Loby

    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private GameObject LobyPanel;
    [SerializeField] private GameObject Players;
    [SerializeField] private AudioSource BackroundMusic;
    [SerializeField] private Slider Slider;
    [SerializeField] private Image VolumeImage;
    [SerializeField] private Image VolumeImageInGame;
    [SerializeField] private Sprite MuteVolumeSprite;
    [SerializeField] private Sprite MediumVolumeSprite;
    [SerializeField] private Sprite MaxVolumeSprite;
    [SerializeField] private TMP_Dropdown DropdownChangeCharacter;
    [SerializeField] private GameObject Player;
    [SerializeField] private Slider VolumeSliderInGame;

    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<UIManager>();
            }

            return _instance;
        }
    }
    public static int SelectedPlayer { get; set; } = 1;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }

        DropdownChangeCharacter.onValueChanged.AddListener(index =>
        {
            SelectedPlayer = index;
        });

        DontDestroyOnLoad(gameObject);
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



}

public partial class UIManager : MonoBehaviour
{
    //For PlayScene

    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject PausePanelBTN;

    public void OnClickLobyBTN()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void OnClickPauseBTN()
    {
        PausePanel.gameObject.SetActive(true);
        PausePanelBTN.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void OnClickContinueBTN()
    {
        PausePanel.gameObject.SetActive(false);
        PausePanelBTN.gameObject.SetActive(true);
        Time.timeScale = 1;
    }

    public void ChangeVolumeInGame()
    {
        BackroundMusic.volume = VolumeSliderInGame.value;

        if (BackroundMusic.volume == 0)
        {
            VolumeImageInGame.sprite = MuteVolumeSprite;
        }
        else if (BackroundMusic.volume > 0 && BackroundMusic.volume < 0.6)
        {
            VolumeImageInGame.sprite = MediumVolumeSprite;
        }
        else
        {
            VolumeImageInGame.sprite = MaxVolumeSprite;
        }
    }
}
