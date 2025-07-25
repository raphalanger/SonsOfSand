using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform Player; // Transform = infos do jogador
    public Vector3 offset; // Vector3 = terceira dimensão representando a distancia da camera em relação ao jogador
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").transform; // Posiciona a camera no jogador
    }
    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }
    void FollowPlayer()
    {
        transform.position = new Vector3(Player.position.x + offset.x, Player.position.y + offset.y, offset.z);
    }
}
