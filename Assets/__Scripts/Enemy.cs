using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{

    [SerializeField] private float speed = 1.0f;

    private Rigidbody2D rb;
    private GameObject player;
    private float enemyMoveX;
    private float enemyMoveY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
   
        fellowPlayer();
    }

    private void OnTriggerEnter2D(Collider2D whatHitMe)
    {
        // parameter = what ran into me
        // if the player hit, then destroy the player
        // and the current enemy rectangle

        var player = whatHitMe.GetComponent<PlayerMovement>();
        

        Debug.Log("Hit Something");

        if (player)  // if (player != null)
        {
            Debug.Log("It was the player");
            // play crash sound here
            // destroy the player and the rectangle
            // give the player points/coins
            Destroy(player.gameObject);
            Destroy(gameObject);
        }
    }

    void fellowPlayer()
    {
        
        enemyMoveX = transform.position.x - player.transform.position.x;
        enemyMoveY = transform.position.y - player.transform.position.y;


        if (enemyMoveX < 0 && enemyMoveY < 0)
        {
            rb.velocity = new Vector2(1 * speed, 1 * speed);
        }
        else if (enemyMoveX > 0 && enemyMoveY < 0)
        {
            rb.velocity = new Vector2(-1 * speed, 1 * speed);
        }
        else if (enemyMoveX < 0 && enemyMoveY > 0)
        {
            rb.velocity = new Vector2(1 * speed, -1 * speed);
        }
        else if (enemyMoveX > 0 && enemyMoveY > 0)
        {
            rb.velocity = new Vector2(-1 * speed, -1 * speed);
        }

    }
}
