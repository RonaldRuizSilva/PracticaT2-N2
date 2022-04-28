using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo3Controller : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update() 
    {
        rb.velocity = new Vector2(5, rb.velocity.y);
    }
}
