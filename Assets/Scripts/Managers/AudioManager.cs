using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource blockBreak;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void BlockBreakPlay() => blockBreak.Play();
}