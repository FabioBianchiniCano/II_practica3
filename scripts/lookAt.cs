using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour
{
    void Start() {
        MyCharacter.Instance.closeToA += lookAtObject;
    }

    void Update() {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 100;
        Debug.DrawRay(transform.position, forward, Color.green);
    }


    private void lookAtObject() {
        transform.LookAt(MyCharacter.Instance.gameObject.transform);
    }
}
