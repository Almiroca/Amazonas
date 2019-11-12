using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrullar : MonoBehaviour
{
    private NavMeshAgent nav;
    private float patrol_radious = 30f;
    private float patrol_time = 5;
    private float timer_count;
    public float followDistance;
    public GameObject personaje;
    public GameObject puntoInicio;
    float currentDistance;
    Animator anim;
   // public GameObject bullet;
   // public Transform startPosition;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        personaje = GameObject.FindWithTag("Player");
        timer_count = patrol_time;
    }

    // Update is called once per frame
    void Update()
    {

        currentDistance = Vector3.Distance(transform.position, personaje.transform.position); //Calculamos la distancia actual entre el presonaje y el enemigo
        if (currentDistance <= followDistance)
        {
            nav.SetDestination(personaje.transform.position);
            //nav.transform.LookAt(personaje.transform.position);
            anim.SetBool("run",true);
            anim.SetBool("caminar",false);
            anim.SetBool("idle",false);
            anim.SetBool("atacar",false);
        }
        else
        {
            patrol();
            anim.SetBool("caminar",true);
            anim.SetBool("run",false);
            anim.SetBool("idle",false);
            anim.SetBool("atacar",false);
        }
        if (currentDistance >= followDistance && currentDistance <= 10)
        {
            nav.SetDestination(puntoInicio.transform.position);
            //nav.transform.LookAt(personaje.transform.position);
            anim.SetBool("idle",true);
            anim.SetBool("caminar",false);
            anim.SetBool("run",false);
            anim.SetBool("atacar",false);
        }
        if(currentDistance <= 5 ){
            nav.SetDestination(personaje.transform.position);
            //nav.transform.LookAt(personaje.transform.position);
            anim.SetBool("idle",false);
            anim.SetBool("caminar",false);
            anim.SetBool("run",false);
            anim.SetBool("atacar",true);
        }
      

        void patrol()
        {
            timer_count += Time.deltaTime;
            if (timer_count > patrol_time)
            {
                SetNewRandomDestination();
                timer_count = 0f;
            }
        }

        void SetNewRandomDestination()
        {
            Vector3 newDestination = RandomNavSphere(transform.position, patrol_radious, -1);
            nav.SetDestination(newDestination);
        }
        Vector3 RandomNavSphere(Vector3 originPos, float radius, int layerMask)
        {
            Vector3 randDir = Random.insideUnitSphere * radius;
            randDir += originPos;
            NavMeshHit hit;
            NavMesh.SamplePosition(randDir, out hit, radius, layerMask);

            return hit.position;
        }
        Debug.Log(currentDistance+"distanciactual");
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag=="Arbol")
        {
            
        }   
    }
}
