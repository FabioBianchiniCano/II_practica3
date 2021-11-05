using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_B : MonoBehaviour
{

    public float force;
    // Start is called before the first frame update
    void Start() {
        MyCharacter.Instance.OnContactB += addForce;
        MyCharacter.Instance.closeToA += changeColor;
    }


    void addForce () {
        force++;
    }

    void changeColor () {
        Debug.Log("Change color");
        gameObject.GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f),Random.Range(0f, 1f),Random.Range(0f, 1f));
    }
}
