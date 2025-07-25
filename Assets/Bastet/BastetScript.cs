using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BastetScript : MonoBehaviour
{
    // variaveis do player
    private Transform player; // transform do player
    private GameObject playerRef; // captura o objeto player para pegar o transform
    private PlayerScript playerScript; // para gerenciar alguns componentes do Player

    // variaveis da Bastet
    private Transform tf; // transform da Bastet
    private Rigidbody2D rb; // fisica e posiçao da bastet
    private SpriteRenderer rd; // renderizador de imagem (ou sprite) da bastet
    private Animator anim; // gerenciador de animaçao da bastet
    private Vector2 size;
    private Vector2 offset; // aproximaçao maxima do jogador (para atacar no alcance e evitar empurrar)
    public float speed = 3f; // velocidade de movimento da Bastet
    private Vector2 direction; // direçao para usar flip de sprite
    private AnimatorStateInfo currentState;
    private Transform childTransform;

    // alvo da bastet em relação ao player
    private Vector2 target; 
    // variaveis de ataque (anexar dentro do proprio UnityEditor)
    public GameObject AttackBox;
    private GameObject hurtbox;
    private float maxHealth = 30;
    public float Health;
    public float Damage = 50;


    // Awake is called once before Start
    void Awake()
    {
        tf = GetComponent<Transform>(); 
        playerRef = GameObject.Find("Player"); 
        player = playerRef.GetComponent<Transform>();
        playerScript = playerRef.GetComponent<PlayerScript>();
        rb = GetComponent<Rigidbody2D>(); 
        rd = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        size = rd.size; // pega o tamanho do renderer da personagem
        size = new Vector2(size.x * transform.localScale.x, size.y * transform.localScale.y);
        offset = new Vector2(size.x*2, size.y/2); // ponto à frente da personagem

    }

    // Start is called before the first frame update
    void Start()     
    {
        Health = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (direction.x > 0) 
            offset.x = Mathf.Abs(offset.x);
        else
            offset.x = -Mathf.Abs(offset.x);
    }

    // FixedUpdate is called once per in-game fixed time
    void FixedUpdate()
    {
        if (Mathf.Abs(player.position.x - transform.position.x) > offset.x)
        {
            Follow();
        }
        else
        {
            anim.SetBool("move", false);
            rb.velocity = Vector2.zero;
        }

        if (Mathf.Abs(player.position.x - transform.position.x) <= offset.x) // funcao que neutraliza o sinal do numero, ja que nao sera necessario
        {
            anim.SetBool("attack", true);

            // codigo para gerar parente trigger
            hurtbox = Instantiate(AttackBox, offset, Quaternion.identity);
            hurtbox.transform.parent = transform;
        }
        else
        {
            Destroy(hurtbox);
            anim.SetBool("attack", false);
        }
    }

    // metodos

    private void Follow()
    {
        /*direction = player.position - transform.position;
        anim.SetBool("move", (rb.velocity.magnitude > 0f ) ? true : false);
        rb.MovePosition(rb.position +  direction.normalized * speed * Time.deltaTime);*/

        direction = (player.position - transform.position).normalized;
        direction.y = 0;
        rb.velocity = direction * speed;

        anim.SetBool("move", (rb.velocity.x != 0) ? true : false);
        rd.flipX = (rb.velocity.x > 0) ? true : false;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerScript.Health -= Damage;
            hurtbox.SetActive(false);
        }
    }
}