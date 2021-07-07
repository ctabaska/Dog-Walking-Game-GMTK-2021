using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _playerDirection;

    public Rigidbody2D player;

    public float PlayerSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        _playerDirection = new Vector2(0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        _playerDirection.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        if (_playerDirection.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (_playerDirection.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        player.velocity = _playerDirection * PlayerSpeed;
    }
}
