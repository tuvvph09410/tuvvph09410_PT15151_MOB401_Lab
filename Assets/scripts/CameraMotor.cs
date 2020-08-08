using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
     private Transform lookAt; //điểm theo dõi
    private Vector3 startOS; // khoảng cách
    private Vector3 moveVT; //vector di chuyển
    private float transition; // ks nội suy
    private float animationTime = 4.0f; // thời gian animation
    private Vector3 animationOffet = new Vector3(0,5,5); 
    // Start is called before the first frame update
    void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform; //anh xạ đối tượng
        //khởi tạo khoản cách offset
        startOS = transform.position - lookAt.position;
    }

    // Update is called once per frame
    void Update()
    {
        //camera di chuyển
        moveVT = lookAt.position + startOS;
        //move X
        moveVT.x = 0f;
        //theo Y
        moveVT.y = Mathf.Clamp(moveVT.y,5,5);
        if (transition > 1.0f)
        {
            transform.position = moveVT; //di chuyển theo nhân vật
        }
        else
        {
            transform.position = Vector3.Lerp(moveVT + animationOffet, moveVT, transition);
            transition += Time.deltaTime * 1 / animationTime;
            transform.LookAt(lookAt.position + Vector3.up);
        }
    }
}

