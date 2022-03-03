using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController Character_Controller;

    private Vector3 move_Direction;

    public float Speed = 5f;
    private float gravity = 20f;

    public float jump_float = 1f;
    private float vertical_velocity;

    void Awake()
    {
        Character_Controller = GetComponent<CharacterController>();

    }

   

    void Update()
    {
        MoveThePlayer();  
    }
    void MoveThePlayer()
    {
        move_Direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));
        move_Direction = transform.TransformDirection(move_Direction);
        move_Direction *= Speed * Time.deltaTime;
        ApplyGravity();
        Character_Controller.Move(move_Direction);

        
    }//player moving

    void ApplyGravity()
    {
        if (Character_Controller.isGrounded)
        {
            vertical_velocity -= gravity * Time.deltaTime;

            PlayerJump();
        }
        else
        {
            vertical_velocity -= gravity * Time.deltaTime;
            
        }
        move_Direction.y = vertical_velocity * Time.deltaTime;
        move_Direction.y = vertical_velocity;
    }
    void PlayerJump()
    {
        if(Character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            vertical_velocity = jump_float;
        } 
    }
}
