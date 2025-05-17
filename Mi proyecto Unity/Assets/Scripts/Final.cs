using UnityEngine;
using UnityEngine.Audio;

public class Final : MonoBehaviour
{
    public GameObject felicidades;
    void Start()
    {
        
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(felicidades, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

}
