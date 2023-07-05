using UnityEngine;

public class BlockManager : MonoBehaviour
{
    [SerializeField] private GameObject block;

    [SerializeField] private float spawnTime;
    private float currentSpawnTime = 0;

    private void Start()
    {
        Physics.gravity = new Vector3(0, -0.5f, 0);
    }

    private void Update()
    {
        currentSpawnTime -= Time.deltaTime;
        if (currentSpawnTime <= 0)
        {
            Instantiate(block, transform.position, Quaternion.identity);
            if (int.Parse(Player.instance.score.text) % 25 == 0)
            {
                Physics.gravity += new Vector3(0, -0.5f, 0);
                if (spawnTime != 1f)
                {
                    spawnTime -= 0.25f;
                }
            }
            currentSpawnTime = spawnTime;
        }
    }
}