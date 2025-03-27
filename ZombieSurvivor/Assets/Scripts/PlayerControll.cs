using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 20f;
    public Rigidbody rigidbody;
    public GameObject animator;
    public LivingEntity livingEntity;
    public float LastHitTime;
    public float delay = 2.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        Move();
    }
    
    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        var dir = new Vector3(h, 0, v);
        var movement = transform.position + (dir.z * transform.forward * moveSpeed * Time.deltaTime);
        rigidbody.MovePosition(movement);

        //턴을 하는 방향을 플레이어 기준 x좌표로 턴 속도 만큼 시간을 곱한다
        float turn = dir.x * turnSpeed * Time.deltaTime;
        this.transform.rotation *= Quaternion.Euler(0, turn, 0);
        rigidbody.angularVelocity = new Vector3(0, 0, 0);
        animator.GetComponent<Animator>().SetFloat("Move", dir.z);
    }
    
}

