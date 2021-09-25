using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Vector2 movement = new Vector2();
    Rigidbody2D rb2D;
    public float movementSpeed = 20;
    Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        movementSpeed = movementSpeed * 100;
        m_Animator = gameObject.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        GetInput();
        MoveCharacter(movement);
        
    }
    private void GetInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        
        movement.y = Input.GetAxisRaw("Vertical");
        
        if(movement.x > 0)
        {
            m_Animator.SetInteger("statusWalk", 3);
            
        }
        else if(movement.x < 0)
        {
            m_Animator.SetInteger("statusWalk", 4);
        }
        else if (movement.x == 0 && movement.y == 0)
        {
            m_Animator.SetInteger("statusWalk", 0);
        }
        else if (movement.y < 0 && movement.x == 0)
        {
            m_Animator.SetInteger("statusWalk", 2);

        }
        else if (movement.y > 0 && movement.x == 0)
        {
            m_Animator.SetInteger("statusWalk", 1);
        }
    }
    public void MoveCharacter(Vector2 movementVector)
    {
        movementVector.Normalize();
        // move the RigidBody2D instead of moving the Transform
        rb2D.velocity = movementVector * movementSpeed * Time.deltaTime;
       
    }
}
