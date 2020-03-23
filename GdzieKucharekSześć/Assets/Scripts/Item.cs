using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    Collider2D Tcollider;
    bool grabbed = false;
    public void Grab(CharacterController player)
    {
        Debug.Log(player.transform == null);
        if (grabbed == false)
        {
            Tcollider.enabled = false;
            grabbed = true;
            this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            player.item = this;
            Vector3 savedVector = this.transform.localScale;
           this.transform.localPosition = player.transform.localPosition;
            this.transform.SetParent(player.transform);
            this.transform.localScale = savedVector;
        }
        
    }
    
    public void Drop(CharacterController player)
    {
        Tcollider.enabled = true;
        grabbed = false;
        player.item = null;
        Vector3 savedVector = this.transform.localScale;
        this.transform.parent = null;
        this.transform.localScale = savedVector;


    }
    public void Start()
    {
        Tcollider = this.GetComponent<Collider2D>();
        Debug.LogError(Tcollider==null);
    }
    // Start is called before the first frame update


    // Update is called once per frame

}
