using UnityEngine;

public class AparicionPlataformas : MonoBehaviour
{
    public GameObject plataformas;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(plataformas, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

}
