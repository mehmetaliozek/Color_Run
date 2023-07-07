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
            currentSpawnTime = spawnTime;
        }
        GameManager.instance.UpdateSpawnTime(ref spawnTime);
    }
}