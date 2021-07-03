using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boids : MonoBehaviour
{
    public Vector3 Position;
    public Vector3 Velocity;
    public List<Transform> Neighbors;
    
    
    public Boids(Vector3 position, Vector3 velocity)
    {
        Vector3 Position = position;
        Vector3 Velocity = velocity;
        gameObject.transform.position = position;
        gameObject.transform.rotation = Quaternion.LookRotation(Vector3.Normalize(velocity));
    }

    
    public void UpdateBoids(Vector3 position, Vector3 velocity)
    {
        Vector3 Position = position;
        Vector3 Velocity = velocity;
        gameObject.transform.position = position;
        gameObject.transform.rotation = Quaternion.LookRotation(Vector3.Normalize(velocity));
    }

    public void UpdateNeighbors(List<Transform> boid,float distance)
    {
        var neighbors = new List<Transform>();
        for (int i = 0; i < boid.Count; i++)
        {
            if (Position != boid[i].position)
            {
                if (Vector3.Distance(boid[i].position, Position) < distance)
                {
                    neighbors.Add(boid[i]);
                }
            }
        }

        Neighbors = neighbors;
    }
    
    public Vector3 RulesRapproche()
    {
        // on initialise le centre de la zone en 0 0 0
        Vector3 centreBoid = new Vector3(0, 0, 0);
        
        // si il y a pas d'autre oiseau on renvoie que le centre est en 0 0 0
        if (Neighbors.Count == 0)
        {
            return centreBoid;
        }
        // on calibre le centre en fonction de la position des oiseaux
        for (int i = 0; i < Neighbors.Count; i++)
        {
            // on recup tout les gameobject des oiseaux
            var neighbors = Neighbors[i].GetComponent<Boids>();
            if (centreBoid == Vector3.zero)
            {
                centreBoid = neighbors.Position;
            }
            else
            {
                centreBoid = centreBoid + neighbors.Position;
            }
        }
        centreBoid = centreBoid / Neighbors.Count;
        
        return (centreBoid - Position) / 100;
    }


    public Vector3 RulesSeparation()
    {
        //initialise le centre de la zone
        Vector3 centreBoid = new Vector3(0, 0, 0);

        for (int i = 0; i < Neighbors.Count; i++)
        {
            Boids neighbor = Neighbors[i].GetComponent<Boids>();
            float distance = Vector3.Distance(Position, neighbor.Position);
            centreBoid = centreBoid + Vector3.Normalize(Position - neighbor.Position) / Mathf.Pow(distance, 2) / 100;
        }
        return centreBoid * 5;
    }


    public Vector3 RulesAllignement()
    {
        Vector3 centreBoid = new Vector3(0, 0, 0);
        if (Neighbors.Count == 0)
        {
            return centreBoid;
        }

        for (int i = 0; i < Neighbors.Count; i++)
        {
            var neighbor = Neighbors[i].GetComponent<Boids>();
            centreBoid = centreBoid + neighbor.Velocity;
        }

        if (Neighbors.Count > 1)
        {
            centreBoid = centreBoid / (Neighbors.Count);
        }

        return Vector3.Normalize(centreBoid - Velocity) * 8;
    }

 
    
    
    
}

    