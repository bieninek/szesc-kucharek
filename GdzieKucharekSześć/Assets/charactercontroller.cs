using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterController : MonoBehaviour
{

    public float speed;
    bool stuned = false;
    float stunDuration;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (stuned)
        {
            stunDuration -= Time.fixedDeltaTime;
            if (stunDuration < 0)
                stuned = false;
        }
        





    }

    private void Stun(float time)
    {
        stunDuration = time;
        stuned = true;
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed*Time.fixedDeltaTime*10);
    }
}
