/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimentController : MonoBehaviour
{    
    InputSystem controls;

    private PlayerScript Player;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRender;
    public Button left;
    public Button right;
    public Button up;
    public Button attack;
    public Button pause;
    private float horizontal;
    public float speed = 10f;

    // Awake is called before Start
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();

        controls = new InputSystem();
        controls.Enable();

        controls.Land.Movement.performed += ctx =>
        {
            horizontal = ctx.ReadValue<float>();
        };

        controls.Land.Jump.performed += ctx => Jump();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Fixed Update
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

    }

    // Update is called once per frame
    void Update()
    {
        if (horizontal > 0)
        {
            Player.spriteRender.flipX = false;
        }
        else if (horizontal < 0)
        {
            Player.spriteRender.flipX = true;
        }
    }
    private void Mov()
    {
        if(right)
        {
            horizontal = 5;
            horizontal *= Player.speed;
            Player.rb2d.velocity = new Vector2(horizontal, Player.rb2d.velocity.x);                 // atualiza a posição do Player
            
        }
        else if (left)
        {
            horizontal = -5;
            horizontal *= Player.speed;
            Player.rb2d.velocity = new Vector2(horizontal, Player.rb2d.velocity.x);                 // atualiza a posição do Player
            
        }
    }
    private void Jump()
    {

    }
}
*/