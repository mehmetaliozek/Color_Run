using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenu;

    [SerializeField] private GameObject audioOn;

    public void PauseAndResume()
    {
        Time.timeScale = Time.timeScale == 1 ? 0 : 1;
        pauseButton.SetActive(Time.timeScale == 1 ? true : false);
        pauseMenu.SetActive(Time.timeScale == 1 ? false : true);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void AudioVolume(float volume)
    {
        AudioManager.instance.SetVolume(volume);
        audioOn.SetActive(volume == 0 ? false : true);
    }
}