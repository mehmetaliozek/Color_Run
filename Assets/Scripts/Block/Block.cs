using UnityEngine;

public class Block : MonoBehaviour
{
    private MaterialManager materialManager;
    public Animator animator;
    [HideInInspector] public Material material;

    [SerializeField] private GameObject blockLeft;
    [SerializeField] private GameObject blockRight;

    private void Start()
    {
        animator.speed = 0;

        materialManager = GameObject.FindGameObjectWithTag("MaterialManager").GetComponent<MaterialManager>();
        material = materialManager.GetMaterial();

        blockLeft.GetComponent<Renderer>().material = material;
        blockRight.GetComponent<Renderer>().material = material;
    }

    public void Break()
    {
        Destroy(gameObject);
    }
}