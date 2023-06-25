using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class Menu : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _musicToggleSlider;

    [SerializeField] private float _persentShowAds;


    private PlayerInput _input;

    private void Awake()
    {
    }
    private void Start()
    {
        InsterstitialAds.S.LoadAd();        
        _masterVolumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
        _musicToggleSlider.onValueChanged.AddListener(OnMusicToggleSliderChanged);

        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);

        _masterVolumeSlider.SetValueWithoutNotify(masterVolume);
        _musicToggleSlider.SetValueWithoutNotify(musicVolume);

        ChangeVolume(masterVolume);
        ToggleMusic(musicVolume);
        StartCoroutine(LoadInsterstitialAds());
    }

    public void Initialize(PlayerInput input)
    {
        _input = input;
    }

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;

        _input.Player.Shoot.Disable();
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;

        _input.Player.Shoot.Enable();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SpaceShip");
    }
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }   

    public void ChangeVolume(float volume)
    {
        _mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
        AudioManager.MasterVolume = volume;
    }
    public void ToggleMusic(float volume)
    {
        _mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
        AudioManager.MusicVolume = volume;
    }

    private void OnVolumeSliderChanged(float value)
    {
        ChangeVolume(value);
        PlayerPrefs.SetFloat("MasterVolume", value);
    }

    private void OnMusicToggleSliderChanged(float value)
    {
        ToggleMusic(value);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
    private IEnumerator LoadInsterstitialAds()
    {
        yield return new WaitForSeconds(0.5f);
        ShowingAds();
    }
    private void ShowingAds()
    {
        float tempPersent = Random.Range(0f, 1f);

        if (tempPersent > _persentShowAds)
        {
            InsterstitialAds.S.ShowAd();
        }
    }
}
