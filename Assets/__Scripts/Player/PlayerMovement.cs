using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PolygonCollider2D))]

public class PlayerMovement : MonoBehaviour
{

    // == public fields ==

    // == private fields ==
    private Rigidbody2D rb;

    private string Horizontal = "Horizontal";
    private string Vertical = "Vertical";
    private float yBottomClamp= -4.7f;
    private float yTopClamp= 4.5f;
    private float xLeftClamp= -8.4f;
    private float xRightClamp= 8.5f;


    [SerializeField] private float speed = 7.0f;
    // == private methods ==


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveController();
        faceMouse();
    }

    void MoveController()
    {
        float vMovement = Input.GetAxis(Vertical);
        float hMovement = Input.GetAxis(Horizontal);

        rb.velocity = new Vector2(hMovement * speed,
                             vMovement * speed);


        // keep the player on the screen
        // float xValue = Mathf.clamp(value, min, max)
        // rb.position.x 
        float yValue = Mathf.Clamp(rb.position.y, yBottomClamp, yTopClamp);
        float xValue = Mathf.Clamp(rb.position.x, xLeftClamp, xRightClamp);

        rb.position = new Vector2(xValue, yValue);
    }

    void faceMouse()
    {

        //Code from https://www.youtube.com/watch?v=_XdqA3xbP2A


        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);


        Vector2 direction = new Vector2(mousePosition.x - transform.position.x,
                                        mousePosition.y - transform.position.y);

        transform.up = direction;
    }
}
