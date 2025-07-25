using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    private GameObject player;
    private GameObject bastet;

    private PlayerScript playerScript;
    private BastetScript bastetScript;
    private string objName;

    void Awake()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerScript>();
        bastet = GameObject.Find("Bastet");
        bastetScript = GetComponent<BastetScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/

}
