using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;


    private PlayerInput _input;

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

    //public void ToggleMusic(bool enabled)
    //{
    //    if (enabled)
    //        _mixer.audioMixer.SetFloat("MusicVolume", 0);
    //    else
    //        _mixer.audioMixer.SetFloat("MusicVolume", -80);
    //}

    public void ChangeVolume(float volume)
    {
        _mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
    }
    public void ToggleMusic(float volume)
    {
        _mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
    }
}
