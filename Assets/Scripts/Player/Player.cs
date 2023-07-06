using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player instance;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI score;
    [HideInInspector] public float blockScore = 0f;


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
            UpdateHighScore();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Block")
        {
            Block block = other.gameObject.GetComponent<Block>();
            if (block.material == gameObject.GetComponent<MeshRenderer>().sharedMaterial)
            {
                block.animator.speed = 1;
                UpdateScore(50);
                blockScore += 50;
            }
            else
            {
                Destroy(gameObject);
                Time.timeScale = 0;
            }
        }
    }

    private void UpdateScore(int add)
    {
        score.text = (int.Parse(score.text) + add).ToString();
    }

    private void UpdateHighScore()
    {
        if (int.Parse(score.text) >= int.Parse(highScore.text))
        {
            highScore.text = int.Parse(score.text).ToString();
        };
    }

    public void UpdateSpawnTime(ref float spawnTime)
    {
        if (blockScore % 250 == 0)
        {
            Physics.gravity += new Vector3(0, -0.5f, 0);
            if (spawnTime > 1f)
            {
                spawnTime -= 0.25f;
            }
        }
    }
}