using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public Animator animator;
    public GameObject GunPivat;
    public Transform LeftHandle;
    public Transform RightHandle;
    public float LeftSetIKPosWeight;
    public float LeftSetIKRotWeight;
    public float RightSetIKPosWeight;
    public float RightSetIKRotWeight;
    public PlayerControll playerControll;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GunPivat.transform.rotation = playerControll.transform.rotation;
    }
    private void OnAnimatorIK(int layerIndex)
    {
        //피봇의 위치를 오른쪽 엘보로 설정
        GunPivat.transform.position = animator.GetIKHintPosition(AvatarIKHint.RightElbow);

        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, LeftSetIKPosWeight);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, LeftSetIKRotWeight);

        animator.SetIKPosition(AvatarIKGoal.LeftHand, LeftHandle.position);
        animator.SetIKRotation(AvatarIKGoal.LeftHand, LeftHandle.rotation);

        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, RightSetIKPosWeight);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, RightSetIKRotWeight);

        animator.SetIKPosition(AvatarIKGoal.RightHand, RightHandle.position);
        animator.SetIKRotation(AvatarIKGoal.RightHand, RightHandle.rotation);
    }
    public void Die()
    {
        animator.SetTrigger("IsDie");

    }
}
