using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptBatman : MonoBehaviour
{

    private Rigidbody2D rbd;
    private Animator anim;
    public float velocidade = 4;
    public float pulo = 100;
    public bool chao = true;
    private bool direita = true;
    public bool pular1;

    public LayerMask mascara;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    private void OnCollisionEnter2D(Collision2D collision) {
        
        chao = true;
        pular1 = true;

        transform.parent = collision.transform;
        
    }

    private void OnCollisionExit2D(Collision2D collision) {
        chao = false;
        pular1 = false;
        transform.parent = null;
        
    }


    // Update is called once per frame
    void Update()
    {

        float x = Input.GetAxis("Horizontal");

        if(x == 0){
            anim.SetBool("stop",true);

        }else{
            anim.SetBool("stop", false);

        }


       

       if(direita && x < 0 || !direita && x > 0){
            direita = !direita;
            transform.Rotate(new Vector2(0,180));
        }

        

        

        rbd.velocity = new Vector2(x*velocidade, rbd.velocity.y);



        if(Input.GetKeyDown(KeyCode.Space) && chao && pular1){
            chao = false;
            rbd.AddForce(new Vector2(0,pulo));
            pular1 = false;
            transform.parent = null;
            anim.SetBool("jump",false);
        }else{
            anim.SetBool("jump",true);
        }

        if(Input.GetKeyDown(KeyCode.Space) && pular1 == false){
            rbd.AddForce(new Vector2(0,pulo+50));
            chao = false;
            pular1 = true; anim.SetBool("jump",false);
        }
        

        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, -transform.up, 1, mascara);

        if(hit.collider != null){
            //Debug.Log(hit.collider.name);
            Destroy(hit.collider.gameObject);

        }



    }
}
