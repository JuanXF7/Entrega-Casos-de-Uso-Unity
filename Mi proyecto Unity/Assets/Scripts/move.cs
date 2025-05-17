using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    public float horizontalInput;
    public float verticalInput;
    public GameObject miObjeto;
    public GameObject miOtroObjeto;
    public bool cambiaObjeto = false;

    // Salto
    public float saltoFuerza = 5f;
    public float gravedad = -9.8f;
    private float velocidadVertical = 0f;
    private bool estaEnElPiso = true;

    public float distanciaChequeo = 0.5f; 
    public LayerMask capasSaltables;      


    void Update()
    {
        // Movimiento lateral y frontal
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);

        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        // Límites del escenario
        if (transform.position.z < -15.86f)
            transform.position = new Vector3(transform.position.x, transform.position.y, -15.86f);

        //if (transform.position.z > -7.05f)
        //    transform.position = new Vector3(transform.position.x, transform.position.y, -7.05f);

        if (transform.position.x > -0.05f)
            transform.position = new Vector3(-0.05f, transform.position.y, transform.position.z);

        if (transform.position.x < -5.05f)
            transform.position = new Vector3(-5.05f, transform.position.y, transform.position.z);

        // Disparar
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            cambiaMiObjeto();
        }

        //Saltar
        estaEnElPiso = Physics.Raycast(transform.position, Vector3.down, distanciaChequeo, capasSaltables);

        if (estaEnElPiso && Input.GetKeyDown(KeyCode.Space))
        {
            velocidadVertical = saltoFuerza;
        }

        velocidadVertical += gravedad * Time.deltaTime;
        transform.Translate(Vector3.up * velocidadVertical * Time.deltaTime);

        if (estaEnElPiso && velocidadVertical <= 0)
        {
            velocidadVertical = -2f;
        }


    }

    private void cambiaMiObjeto()
    {
        if (cambiaObjeto)
        {
            Instantiate(miOtroObjeto, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(miObjeto, transform.position, Quaternion.identity);
        }
    }
}
