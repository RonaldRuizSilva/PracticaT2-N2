using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegamanController : MonoBehaviour
{
    public GameObject Disparo1;
    public GameObject Disparo2;
    public GameObject Disparo3;

    public Transform InicioDisparo;

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sp;

   float segundos = 0;
   public float contadorSegundos = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            sp.flipX = false;
            animator.SetInteger("Estado", 1);
            rb.velocity = new Vector2(7, rb.velocity.y);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            sp.flipX = true;
            animator.SetInteger("Estado", 1);
            rb.velocity = new Vector2(-7, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.X))
        { 
            animator.SetInteger("Estado", 2);
            contadorSegundos += Time.deltaTime;
            Debug.Log(contadorSegundos);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetInteger("Estado", 0);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            animator.SetInteger("Estado", 0);
            if(contadorSegundos <= 0.5)
            {
                Instantiate(Disparo1, InicioDisparo.position, Quaternion.Euler(0f, 0f, 0));
                contadorSegundos = 0;
            }

            if(contadorSegundos >= 0.5 && contadorSegundos <= 1.3)
            {
                Instantiate(Disparo2, InicioDisparo.position, Quaternion.Euler(0f, 0f, 0));
                contadorSegundos = 0;
            }

            if (contadorSegundos > 1.4)
            {
                Instantiate(Disparo3, InicioDisparo.position, Quaternion.Euler(0f, 0f, 0));
                contadorSegundos = 0;
            }

        }
    }
}
