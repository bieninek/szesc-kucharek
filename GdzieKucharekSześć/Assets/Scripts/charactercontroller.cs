using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CharacterController : MonoBehaviour
{
    public Item item = null;
    public float speed;
    public float sprintRatio;
    [SerializeField]
    bool stuned = false;
    [SerializeField]
    float stunDuration;
    private Rigidbody2D rb2d;
    Collider2D collider;
    GameObject lastTouched;

    // Start is called before the first frame update
   // private void OnCollisionStay2D(Collision2D collision)
   // {
   //     Debug.Log("OnCollisionEnter2D");
   // }
    private void Start()
    {
        
        rb2d = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
      //  Debug.Log("OnCollisionEnter2D");
        if (collision.gameObject.GetComponent<Item>()!=null&&item==null)
        {

            lastTouched = collision.gameObject;
        }else if( collision.gameObject.GetComponent<Storage>() != null)
        {
            lastTouched = collision.gameObject;
        }
    }
    void Update()
    {
        if (stuned)
        {
            stunDuration -= Time.fixedDeltaTime;
            if (stunDuration < 0)
                stuned = false;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(lastTouched.GetComponent<Collider2D>()!=null&& collider.IsTouching(lastTouched.GetComponent<Collider2D>()))
            {
                if (item == null && lastTouched.GetComponent<Item>() != null)
                {
                    lastTouched.GetComponent<Item>().Grab(this);
                }else if (lastTouched.GetComponent<Storage>() != null)
                {
                    if (item != null)
                    {
                        lastTouched.GetComponent<Storage>().interact(item);
                    }
                    else
                    {
                        lastTouched.GetComponent<Storage>().interact(this);
                    }
                }

            }
            
        }
    }
    public void UnStun()
    {
        stunDuration = 0;
        stuned = false;


    }

    public void Stun(float time)
    {
        stunDuration = time;
        stuned = true;
        

    }

    private void FixedUpdate()
    {
        bool sprint = Input.GetKey(KeyCode.LeftShift);
        //Store the current vertical input in the float moveVertical.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed*Time.fixedDeltaTime*10*(stuned ? 0 : 1)*(sprint ?sprintRatio:1));
    }
}
