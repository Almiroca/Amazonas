using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float VelocidadMovimiento=5.0f;
    public float Rotacion = 200f;
    private Animator ani;
    public float x, y;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * Rotacion,0);
        transform.Translate(0, 0, y * Time.deltaTime * VelocidadMovimiento);
    }
}

