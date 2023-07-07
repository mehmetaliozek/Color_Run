using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private float highScore;
    private float score;

    private float scoreTime = 0.1f;
    private float currentScoreTime;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        currentScoreTime -= Time.deltaTime;
        if (currentScoreTime <= 0)
        {
            currentScoreTime = scoreTime;
            UpdateScore(1);
        }
        if (Player.instance.isTrigger)
        {
            UpdateScore(100);
            Player.instance.isTrigger = false;
        }
        UpdateHighScore();
        WriteText();
    }

    private void UpdateScore(int add)
    {
        score = score + add;
    }

    private void UpdateHighScore()
    {
        if (score >= highScore)
        {
            highScore = score;
        };
    }

    private void WriteText()
    {
        highScoreText.text = highScore.ToString();
        scoreText.text = score.ToString();
    }

    public void UpdateSpawnTime(ref float spawnTime)
    {
        if (score % 1000 == 0)
        {
            Physics.gravity += new Vector3(0, -0.5f, 0);
            if (spawnTime > 1f)
            {
                spawnTime -= 0.25f;
            }
        }
    }
}