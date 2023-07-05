using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player instance;
    public TextMeshProUGUI score;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
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
                score.text = (int.Parse(score.text) + 5).ToString();
            }
            else
            {
                Destroy(gameObject);
                Time.timeScale = 0;
            }
        }
    }
}