using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingNyamukHorizontal : MonoBehaviour
{
    float speed = 0.5f;
    public bool vertical;
    float changeTime = 1.0f;
    float timer;
    int direction = 1;
    private SpriteRenderer mySpriteRenderer;

    Rigidbody2D rigidbody2D;
    GameObject lightShadow;
    GameObject obstacle;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        obstacle = GameObject.FindGameObjectWithTag("Obstacle");
        lightShadow = GameObject.FindGameObjectWithTag("Light");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;

        
        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;
        }
        
        rigidbody2D.MovePosition(position);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if(player != null)
        {
            player.ChangeHealth(-1);
            Handheld.Vibrate();
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            direction = -direction;
            mySpriteRenderer.flipX = !mySpriteRenderer.flipX;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        
            rigidbody2D.constraints = RigidbodyConstraints2D.None;
            rigidbody2D.freezeRotation = true;
        
    }
}
