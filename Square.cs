using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    private void Awake()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    void Update()
    {
        //jumping code below 
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 10f;
            rigidbody2d.velocity = Vector2.up * jumpVelocity;

        }

        HandleMovement();
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }
    private void HandleMovement(){
        float moveSpeed = 10f;
        float midAirControl = 3f;
        if (Input.GetKey(KeyCode.LeftArrow)) {
            if (IsGrounded()) {
                rigidbody2d.velocity = new Vector2(-moveSpeed, rigidbody2d.velocity.y);
            } else {
                rigidbody2d.velocity += new Vector2(-moveSpeed *midAirControl * Time.deltaTime, 0);
                rigidbody2d.velocity = new Vector2(Mathf.Clamp(rigidbody2d.velocity.x, -moveSpeed, +moveSpeed), rigidbody2d.velocity.y);
            }

        } else {
            if (Input.GetKey(KeyCode.RightArrow)) {
                if (IsGrounded())
                {
                    rigidbody2d.velocity = new Vector2(+moveSpeed, rigidbody2d.velocity.y);
                }
                else
                {
                    rigidbody2d.velocity += new Vector2(+moveSpeed * midAirControl * Time.deltaTime, 0);
                    rigidbody2d.velocity = new Vector2(Mathf.Clamp(rigidbody2d.velocity.x, -moveSpeed, +moveSpeed), rigidbody2d.velocity.y);


                }

                }else{
                    //no keys pressed
                    if (IsGrounded())
                    {
                        rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);



                    }
                }
            }
        }
    } 



