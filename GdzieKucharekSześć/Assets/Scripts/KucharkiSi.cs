using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KucharkiSi : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;
    [SerializeField]
    public float pZmianyKierunku;
    [SerializeField]
    public int speed;
    [SerializeField]
    Vector2 kier = new Vector2(0, 0);
    bool stuned = false;
    
    float stunDuration;
    // Start is called before the first frame update

    private void Stun(float time)
    {
        stunDuration = time;
        stuned = true;
    }

    private void Update()
    {
        if (stuned)
        {
            stunDuration -= Time.fixedDeltaTime;
            if (stunDuration < 0)
                stuned = false;
        }
    }
    private void Start()
    {


        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Random.Range(0f, 1f) < pZmianyKierunku)
        {
            kier = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
        }

        rb2d.AddForce(kier * speed * Time.fixedDeltaTime * 10 * (stuned ? 0 : 1) );



    }
}
