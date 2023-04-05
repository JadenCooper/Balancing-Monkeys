using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fix2DHingeJoints : MonoBehaviour
{
    bool isFixed = false;

    void Start()
    {
        // Find all child game objects of this parent game object
        GameObject[] childObjects = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            childObjects[i] = transform.GetChild(i).gameObject;
        }

        // Find all 2D Hinge Joints within the child game objects and fix their angle of movement
        foreach (GameObject child in childObjects)
        {
            HingeJoint2D[] hingeJoints = child.GetComponentsInChildren<HingeJoint2D>();
            foreach (HingeJoint2D hingeJoint in hingeJoints)
            {
                hingeJoint.useLimits = true; // enable joint angle limits
                JointAngleLimits2D limits = hingeJoint.limits; // get joint angle limits
                limits.min = hingeJoint.jointAngle; // set the lower limit to the current joint angle
                limits.max = hingeJoint.jointAngle; // set the upper limit to the current joint angle
                hingeJoint.limits = limits; // update the joint angle limits
            }
        }
    }

    void Update()
    {
        // Check if the space bar has been pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Toggle the fixed state of the 2D Hinge Joints
            isFixed = !isFixed;

            // Find all child game objects of this parent game object
            GameObject[] childObjects = new GameObject[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                childObjects[i] = transform.GetChild(i).gameObject;
            }

            // Fix or unfix all 2D Hinge Joints within the child game objects
            foreach (GameObject child in childObjects)
            {
                HingeJoint2D[] hingeJoints = child.GetComponentsInChildren<HingeJoint2D>();
                foreach (HingeJoint2D hingeJoint in hingeJoints)
                {
                    if (isFixed)
                    {
                        JointAngleLimits2D limits = hingeJoint.limits; // get joint angle limits
                        limits.min = hingeJoint.jointAngle; // set the lower limit to the current joint angle
                        limits.max = hingeJoint.jointAngle; // set the upper limit to the current joint angle
                        hingeJoint.limits = limits; // update the joint angle limits
                    }
                    else
                    {
                        hingeJoint.useLimits = false; // disable joint angle limits
                    }
                }
            }
        }
    }
}

