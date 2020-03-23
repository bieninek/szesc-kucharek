using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public abstract class Storage : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract void interact(Item itemInHand);
    public abstract void interact(CharacterController player);

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
