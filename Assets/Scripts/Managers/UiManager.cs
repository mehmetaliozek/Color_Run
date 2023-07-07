using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;

    public void PauseAndResume()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        pauseButton.SetActive(Time.timeScale == 1 ? true : false);
        pauseMenu.SetActive(Time.timeScale == 1 ? false : true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}