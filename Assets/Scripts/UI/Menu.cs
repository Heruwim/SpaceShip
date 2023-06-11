using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Image[] _moveButtons;
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

        SetButtonsInteractable(false);
        _input.Player.Shoot.Disable();
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;

        SetButtonsInteractable(true);
        _input.Player.Shoot.Enable();
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void SetButtonsInteractable(bool interactable)
    {
        foreach (Button button in _buttons)
        {
            button.interactable = interactable;
        }

        foreach (Image image in _moveButtons)
        {
            image.gameObject.SetActive(interactable);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SpaceShip");
    }

    public void ToggleMusic(bool enabled)
    {
        if (enabled)
            _mixer.audioMixer.SetFloat("MusicVolume", 0);
        else
            _mixer.audioMixer.SetFloat("MusicVolume", -80);
    }

    public void ChangeVolume(float volume)
    {
        _mixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
    }
}
