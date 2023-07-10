using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource blockBreak;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
    public void BlockBreakPlay() => blockBreak.Play();

    public void SetVolume(float volume)
    {
        music.volume = volume;
        blockBreak.volume = volume;
    }
}