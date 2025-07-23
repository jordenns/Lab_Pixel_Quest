using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {
    private Rigidbody2D _rigidbody2D;

    public float CapsuleHeight = 0.1f;
    public float CapsuleRadius = 0.1f;

    public Transform feetCollider;
    public LayerMask layer;
    private bool groundCheck;
    private float fallForce = 2;
    private Vector2 gravityForce;
    public float jumpForce = 2;

    private bool waterCheck;
    // Start is called before the first frame update
    void Start()
    {
        gravityForce = new Vector2(0f, Physics2D.gravity.y);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Water") { waterCheck = true; }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Water") { waterCheck = false; }
    }

    void Update()
    {
        groundCheck = Physics2D.OverlapCapsule(feetCollider.position, 
            new Vector2(CapsuleHeight, CapsuleRadius), CapsuleDirection2D.Horizontal, 0, layer);
        
        if (Input.GetKeyDown(KeyCode.Space) && (groundCheck || waterCheck))
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        }

        if (_rigidbody2D.velocity.y < 0 && !waterCheck)
        {
            _rigidbody2D.velocity += gravityForce * (fallForce * Time.deltaTime);
        }
        
    }
}
