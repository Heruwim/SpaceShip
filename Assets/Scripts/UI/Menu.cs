using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;

    public void OpenPanel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = 0;

        SetButtonsInteractable(false);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = 1;

        SetButtonsInteractable(true);
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
    }
}
