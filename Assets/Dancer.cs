using UnityEngine;
using System.Collections;

public class Dancer : MonoBehaviour {
    public Transform leftHand;
    public Transform rightHand;
    public Transform leftFoot;
    public Transform rightFoot;
    public Transform head;
    Animator animator;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnAnimatorIK ()
    {
        animator.SetLookAtWeight(1.0f);
        animator.SetLookAtPosition(head.position);
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1.0f);
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
        animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHand.position);
        animator.SetIKPosition(AvatarIKGoal.RightHand, rightHand.position);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1.0f);
        animator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
        animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHand.rotation);
        animator.SetIKRotation(AvatarIKGoal.RightHand, rightHand.rotation);
        animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1.0f);
        animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1.0f);
        animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftFoot.position);
        animator.SetIKPosition(AvatarIKGoal.RightFoot, rightFoot.position);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1.0f);
        animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1.0f);
        animator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFoot.rotation);
        animator.SetIKRotation(AvatarIKGoal.RightFoot, rightFoot.rotation);
    }
}
