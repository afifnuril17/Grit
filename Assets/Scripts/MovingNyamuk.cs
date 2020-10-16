using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingNyamuk : MonoBehaviour
{
    float speed = 0.5f;
    public bool vertical;
    // float changeTime = 5.0f;
    float timer;
    int direction = 1;
    private SpriteRenderer mySpriteRenderer;

    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        // timer = changeTime;
        // mySpriteRenderer.flipY = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        // timer -= Time.deltaTime;

        // if (timer < 0)
        // {
        //     direction = -direction;
        //     timer = changeTime;
        //     mySpriteRenderer.flipY = !mySpriteRenderer.flipY;
        // }
        
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


    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player == null)
        {
            direction = -direction;
            // timer = changeTime;
            mySpriteRenderer.flipY = !mySpriteRenderer.flipY;
        }
        
        
    }

    
}
