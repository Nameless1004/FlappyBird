using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float jumpPower = 0f;
    public float Speed = 0f;
    private Rigidbody2D rig2D;
    private SpriteRenderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
    } 

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Vector2 pos = Vector2.up * jumpPower;
            rig2D.AddForce(pos);
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            if (_renderer.flipX == false)
            {
                _renderer.flipX = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(_renderer.flipX == true)
            {
                _renderer.flipX = false;
            }
        }

        Vector2 move = new Vector2(h, 0);
        transform.position += (Vector3)(move * Speed * Time.smoothDeltaTime);
    }

}

