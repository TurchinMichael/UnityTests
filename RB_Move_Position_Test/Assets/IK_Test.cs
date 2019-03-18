using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class IK_Test : MonoBehaviour
{
    Animator animator;
    Vector3 leftFootPosition;
    Vector3 rightFootPosition;
    Quaternion leftFootRotation;
    Quaternion rightFootRotation;
    float leftFootWeight;
    float rightFootWeight;

    Transform leftFoot;
    Transform rightFoot;



    Transform HipsPos;



    public float offsetY;
    public Transform targetPos;

    public float lookIkWeigt,
                eyesWeight,
                headWeight,
                bodyWeight,
                clampWeight,
                speedChangePosition = 10,
                upThreshold;

    void Start()
    {
        animator = GetComponent<Animator>();
        leftFoot = animator.GetBoneTransform(HumanBodyBones.LeftFoot);
        rightFoot = animator.GetBoneTransform(HumanBodyBones.RightFoot);
        leftFootRotation = leftFoot.rotation;
        rightFootRotation = rightFoot.rotation;
        HipsPos = animator.GetBoneTransform(HumanBodyBones.Hips);
    }

    void FixedUpdate()
    {
        RaycastHit leftHit;
        Vector3 lpos = leftFoot.position;

        //Debug.DrawLine(HipsPos.position, HipsPos.position + Vector3.down * 3, Color.red);


        if (Physics.Raycast(lpos + Vector3.up * upThreshold, Vector3.down, out leftHit, 10))
        {
            if (leftHit.transform.tag != "weapon" && leftHit.transform.tag != "Player")
            {
                leftFootPosition = Vector3.Lerp(lpos, leftHit.point + Vector3.down * offsetY, Time.deltaTime * speedChangePosition);

                if (leftFootPosition.y > rightFootPosition.y + 0.5)
                {
                   // Debug.Log("leftFootPosition");
                    leftFootPosition.y = rightFootPosition.y + 0.1f;
                }

                leftFootRotation = Quaternion.FromToRotation(transform.up, leftHit.normal) * transform.rotation;
                //Debug.DrawLine(leftHit.point, lpos + Vector3.up * 0.4f, Color.red);
                //Debug.Log(leftHit.transform.name);
            }
        }

        RaycastHit rightHit;
        Vector3 rpos = rightFoot.position;
        if (Physics.Raycast(rpos + Vector3.up * upThreshold, Vector3.down, out rightHit, 10))
        {
            if (rightHit.transform.tag != "weapon" && rightHit.transform.tag != "Player")
            {
                rightFootPosition = Vector3.Lerp(rpos, rightHit.point + Vector3.down * offsetY, Time.deltaTime * speedChangePosition);

                if (rightFootPosition.y > leftFootPosition.y + 0.5)
                {
                   // Debug.Log("rightFootPosition");
                    rightFootPosition.y = leftFootPosition.y + 0.1f;
                }

                rightFootRotation = Quaternion.FromToRotation(transform.up, leftHit.normal) * transform.rotation;
                //Debug.DrawLine(rightHit.point, rpos + Vector3.up * 0.4f, Color.red);
                //Debug.Log(rightHit.transform.name);
            }
        }

        if (rightFootPosition.y > HipsPos.position.y)
        {
            Debug.Log("RightFootDown");
            rightFootPosition.y = HipsPos.position.y + Vector3.down.y;
        }
        if (leftFootPosition.y > HipsPos.position.y)
        {
            Debug.Log("LeftFootDown");
            leftFootPosition.y = HipsPos.position.y + Vector3.down.y;
        }
    }

        void OnAnimatorIK()
    {
        animator.SetLookAtWeight(lookIkWeigt, bodyWeight, headWeight, eyesWeight, clampWeight);
        animator.SetLookAtPosition(targetPos.position);

        leftFootWeight = animator.GetFloat("LeftFoot");

        animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, leftFootWeight);
        animator.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootPosition);

        animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, leftFootWeight);
        animator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootRotation);

        rightFootWeight = animator.GetFloat("RightFoot");

        animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, rightFootWeight);
        animator.SetIKPosition(AvatarIKGoal.RightFoot, rightFootPosition);

        animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, rightFootWeight);
        animator.SetIKRotation(AvatarIKGoal.RightFoot, rightFootRotation/*Change(rightFootRotation.x, rightFootRotation.y, rightFootRotation.z, rightFootRotation.w)*/);
    }

    //private static Quaternion Change(float x, float y, float z, float w)
    //{
    //   // Debug.Log(x);

    //    return new Quaternion(x, y, z, w);
    //}
}
