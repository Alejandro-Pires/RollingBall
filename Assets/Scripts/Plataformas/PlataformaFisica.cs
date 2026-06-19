using UnityEngine;

public class PlataformaFisica : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Vector3 direction;
    [SerializeField] private float force;
    [SerializeField] private float time;
    [SerializeField] private float pauseTime;
    private float timer;

    private bool pause = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity =
            direction.normalized * force; //Añade velocidad (sin fuerza), y ya esta medido en metros por segundo
        //No hace falta Time.deltaTime

        //rb.AddTorque(); ----> Movimientos fisicos de empuje
        //rb.AddForce(); -----z rotaciones fisicas
    }

    // Update is called once per frame
    void Update()
    {
        MovementPlatform();
    }

    private void MovementPlatform()
    {

        timer += Time.deltaTime;
        if (timer >= time)
        {
            if (!pause)
            {
                rb.linearVelocity = Vector3.zero;
                pause = true;
            }
            else if (pause && timer >= pauseTime + time)
            {
                timer = 0;
                force *= -1;
                pause = false;
                rb.linearVelocity = direction.normalized * force;
            }

        }
    }
}