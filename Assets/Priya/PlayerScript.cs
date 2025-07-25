using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    InputSystem controls;

    // componentes do player
    private Animator anim; // referencia para o comp. de controle de animaçao
    private Rigidbody2D rb2d; // referencia para o comp. de controle de física
    private SpriteRenderer spriteRender;
    private AnimatorStateInfo currentState;

    //bastet (para dano direto)
    private GameObject bast;
    private BastetScript bastetScript;

    // variaveis de mecanica do player
    public float speed = 6f; // velocidade da corrida
    private float hori; // direção = - esquerda/+ direita
    private float moveInput; // entrada de movimento do player
    public float jmpnFrc = 10f; // força do salto   
    public bool jmpn = false; // saltando = verdadeiro/falso

    // dano e vida do player
    private float maxHealth = 100;
    public float Health; // vida visivel no Unity e para outros arquivos
    public float Damage = 30; // dano visivel no Unity e para outros arquivos

    public GameObject AttackBox; // prefab
    private Transform hurtbox; // define a área que o Player causará dano;
    private Vector2 size;
    private Vector2 offset;
    //public bool jump, left, right;


    private void Awake()
    {
        controls = new InputSystem();
        controls.Enable();
        controls.Land.Movement.performed += ctx => moveInput = ctx.ReadValue<float>();
        controls.Land.Movement.canceled += ctx => moveInput = 0;
        rb2d = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
        spriteRender = this.gameObject.GetComponent<SpriteRenderer>();
        size = spriteRender.size;
        size = new Vector2(size.x * transform.localScale.x, size.y * transform.localScale.y);
        offset = new Vector2(size.x * 2, size.y/2);
        //bast = GameObject.Find("Bastet");
        //bastetScript = bast.GetComponent<BastetScript>();
        //hurtbox = transform.Find("hurtbox");

    }
    // Start is called before the first frame update

    void Start()
    {
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentManager();
    }
    // FixedUpdate is called once per frame update (direcly bonded to the device performance)
    void FixedUpdate()
    {

    }

    private void Crouch()
    {
        if (controls.Land.Crouch.triggered && !jmpn && hori == 0)
        {
            anim.SetBool("crouch", true);
        }
        else 
            anim.SetBool("crouch", false);
    }
    public void MovimentManager()
    {
        hori = moveInput * speed; // atualiza a orientação "hori" de acordo com a velocidade x entrada horizontal
        rb2d.velocity = new Vector2(hori, rb2d.velocity.y);                 // atualiza a posição do Player

        if (hori != 0 && !jmpn)
        {
            anim.SetBool("move", true);                                     // ativa a animação de movimento, pausando a "idle"
            spriteRender.flipX = hori < 0;                                 // muda a direção do render, sem precisar criar outro sprite 
        }
        else if (hori == 0 && !jmpn) 
            anim.SetBool("move", false);

        if ((controls.Land.Jump.triggered) && !jmpn)
        {
            anim.SetBool("jump", true);
            rb2d.AddForce(new Vector2(0f, jmpnFrc), ForceMode2D.Impulse);
            jmpn = true;
        }

        if (controls.Land.Attack.triggered && !jmpn)
        {
            anim.SetBool("attack", true);
        }
    }
    public void EndAttack()
    {
        anim.SetBool("attack", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            jmpn = false;
            anim.SetBool("jump", false);
        }
    }

    public void DisableJump()
    {
        jmpn = false;
    }
    public void OnEnable()
    {
        controls.Enable();
    }
    public void OnDisable()
    {
        controls.Disable();
    }
}