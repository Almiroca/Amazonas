using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TERCER : MonoBehaviour
{
    public Canvas camtodo;
    public Text canvv;
    public Text canve;
    public Text canvh;


    // Start is called before the first frame update
    enum STATES// Manera de programar los estados
    {   
        IDLE, Walkin, SHOOTING, CRAWL,MUERTO
    }
    STATES currentState = STATES.IDLE;// Estado inicial del personaje
    Animator anim;
    public float speed = 15;
    public int restartTimer = 1;
    public int restartDelay= 10;
    public Transform startPosition;
     public Rigidbody rb;    
    private float playerJump = 4f;
    public bool onFloor = true;
    private float life = 100f;
    private float banana = 0f;
    private float gota = 0f;
     //public GameObject energia;
      //public GameObject agua;

    
    
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
     
        CheckConditions();
        makeBehawour();
        //Debug.Log(life);
        //Debug.Log(banana);
        //Debug.Log(gota);


        canvv.text = life.ToString() + "%";
        canve.text = banana.ToString()+ "/3";
        canvh.text = gota.ToString()+ "/1";
   

      
    }

    void CheckConditions()// Funcion que define la toma de estados
    {
           //si se presiona la tecla W S A D
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            //El estado cambia a caminar
            currentState = STATES.Walkin;
        }
        else
        {
            //Si no el estado es reposo
            currentState = STATES.IDLE;
        }
   

        
             if (Input.GetKey(KeyCode.H))
            {   

                 currentState = STATES.SHOOTING;//estado caminar
          
            }
             if (Input.GetKeyDown(KeyCode.Z) && onFloor)
        {  currentState = STATES.CRAWL;//estado caminar
            rb.AddForce(new Vector3(0, playerJump, 0), ForceMode.Impulse);
            onFloor = false;
        }   
    }
    void IDLE()
    {
        anim.SetBool("Idle", true);// Se ejecuta la animación respirar
        anim.SetBool("Walk", false);
        anim.SetBool("Shooting", false);
        anim.SetBool("Crawl", false);
       
    }
    void WALK()
    {
        anim.SetBool("Idle", false);// Se ejecuta la animación respirar
        anim.SetBool("Walk", true);
        anim.SetBool("Shooting", false);
        anim.SetBool("Crawl", false);
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            // transform.Translate(speed * Time.deltaTime, 0, 0);
            transform.Rotate(new Vector3(0f, 90f, 0f) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            // transform.Translate(-speed * Time.deltaTime, 0, 0);
            transform.Rotate(new Vector3(0f, -90f, 0f) * Time.deltaTime);
        }
    }
    void SHOOTING()
    {
        anim.SetBool("Idle", false);// Se ejecuta la animación respirar
        anim.SetBool("Walk", false);
        anim.SetBool("Shooting", true);
        anim.SetBool("Crawl", false);
    }
    void CRAWL()
    {   anim.SetBool("Idle", false);// Se ejecuta la animación respirar
        anim.SetBool("Walk", false);
        anim.SetBool("Shooting", false);
        anim.SetBool("Crawl", true);
      
    }
   

   

    void makeBehawour()
    {
        switch (currentState)
        {
            case STATES.IDLE:
                IDLE();
                break;
            case STATES.Walkin:
                WALK();
                break;
            case STATES.SHOOTING:
                SHOOTING();
                break;
            case STATES.CRAWL:
                CRAWL();
                break;
            
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Araña")){
            life -= 25f;
        }
        if(other.CompareTag("Banana")){
            banana += 1f;
        }
        
        if(other.CompareTag("Gota")){
            gota += 1f;
        }
    }
     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name =="Suelo")
        {
            onFloor = true;
        }
    }
    
}

