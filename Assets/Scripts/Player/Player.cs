using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [HideInInspector] public bool isTrigger = false;

    [SerializeField] private GameObject loseMenu;

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
                isTrigger = true;
            }
            else
            {
                loseMenu.SetActive(true);
                Time.timeScale = 0;
                Destroy(gameObject);
            }
        }
    }
}