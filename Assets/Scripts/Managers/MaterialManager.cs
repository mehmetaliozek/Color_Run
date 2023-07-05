using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    [SerializeField] private Material[] materials;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ChangeMaterial(Random.Range(0, materials.Length));
    }

    public Material GetMaterial()
    {
        return materials[Random.Range(0, materials.Length)];
    }

    public void ChangeMaterial(int index)
    {
        player.GetComponent<Renderer>().material = materials[index];
    }

}