using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class truckMovingScript : MonoBehaviour
{
    public GameObject truck;
    private float speed = 1.7f;
    bool ifComes = false;
    bool ifGoes = false;
    
    public void truckMoveToRestaurant()
    {
        ifComes = true;
    }

    public void truckGoFromRestaurant()
    {
        ifGoes = true;
    }

    void Update()
    {
        if (ifComes)
        {
            Vector3 move = new Vector3(0, 1, 0);
            truck.transform.Translate(move * speed * Time.deltaTime);

            if (truck.transform.position[1] > 3)
                ifComes = false;
        }

        if (ifGoes)
        {
            Vector3 move = new Vector3(0, 1, 0);
            truck.transform.Translate(move * speed * Time.deltaTime);

            if (truck.transform.position[1] > 20)
            {
                ifGoes = false;
                truck.transform.position = new Vector3(-15.5f, -15.0f, 0);
            }
                
        }

    }
}
