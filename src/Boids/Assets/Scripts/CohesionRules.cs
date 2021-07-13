using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoidScript))]
public class CohesionRules : MonoBehaviour
{
    private BoidScript boid;

    public float radius;
    
    // Start is called before the first frame update
    void Start()
    {
        boid = GetComponent<BoidScript>();
    }

    // Update is called once per frame
    void Update()
    {
       BoidScript boids = FindObjectOfType<BoidScript>();
       Vector3 moyenne = Vector3.zero;
       var found = 0;

       foreach (var boid in boids.Where(b =>b != boid))
       {
           
       }
    }
}
