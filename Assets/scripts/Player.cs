using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5.0f; //Toc do
    private CharacterController controller; //điều phối
    private float verticalVelocity = 0.0f; //vân tốc ngang
    private float gravity = 11.0f; //trọng lượng
    private float animationDuration = 3.0f;

    Vector3 moveVector;

    private bool isDead = false;

    //su kien su ly va cham
    private void OnControllerColliderHit(ControllerColliderHit hit){
        if(hit.point.z > transform.position.z + controller.radius)// diem va cham
        {
            Death();
        }
    }

    private void Death(){
        isDead = true;
        GetComponent<Score>().OnDeath();
        Debug.Log("Death");
    }

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

 
    // Update is called once per frame
    void Update()
    {
        if(isDead)
        return;

        moveVector = Vector3.zero; 
        if (Time.time < animationDuration)
        {
            
        //di chuyển
        controller.Move(Vector3.forward * speed * Time.deltaTime);
        return;
    }

    if (controller.isGrounded)
    {
        verticalVelocity = -0.5f;
    }
    else //ko phải đất thì trọng lượng hút xuống
    {
        verticalVelocity -= gravity*Time.deltaTime;
    }

    //định nghĩa di chuyển
    moveVector.x = Input.GetAxisRaw("Horizontal")*speed; 
    moveVector.y = verticalVelocity;
    moveVector.z = speed;
    controller.Move(moveVector*Time.deltaTime);
}

public void SetSpeed(float modifier){
        speed = 5.0f + modifier;
    }
}