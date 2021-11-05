using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Contact();
public class MyCharacter : MonoBehaviour
{
  private ScoreCharacter score;

  [Range(1.0f, 30.0f)]
  public float speedMovement = 10f;
  public float speedRotation = 90f;
  public float punctuation = 0f;


  public static MyCharacter controller;
  public event Contact OnContactA;
  public event Contact OnContactB;
  public event Contact closeToA;


  public static MyCharacter Instance {
      get {
          return controller;
      }
  }

    private void Awake()
  {
      controller = this;
  }

  void Start () {
    score = GameObject.FindObjectOfType<ScoreCharacter>();
  }

  void Update() {
    transform.Translate(Vector3.up * Time.deltaTime * Input.GetAxis("Vertical") * speedMovement);
    transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * speedMovement);
    if (Input.GetKey("e")) {
      transform.Rotate(0, 0, Time.deltaTime * (-speedRotation));
    } 
    if (Input.GetKey("q")) {
      transform.Rotate(0, 0, Time.deltaTime * speedRotation);
    }
  }

  void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.tag == "ObjectA")
      OnContactA();
    if (collision.gameObject.tag == "ObjectB")
      OnContactB();
      
  }

  void OnTriggerEnter(Collider other) {
    if (other.gameObject.tag == "FirstCylinder") {
      punctuation++;
      score.UpdateScoreText(punctuation);
    }
    if (other.gameObject.tag == "ObjectA")
      closeToA();
  }
}
