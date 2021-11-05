using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Object_A : MonoBehaviour
{

    public Text texto;
    void Start() {
        MyCharacter.Instance.OnContactA += showText;
        texto.text = "Has colisionado con un objeto tipo B, el objeto tipo A está mostrando este mensaje";
        texto.enabled = false;
    }

    void showText() {
        texto.enabled = true;
        StartCoroutine(quitMessage());
    }

    private IEnumerator quitMessage() {
        yield return new WaitForSeconds(3);
        texto.enabled = false;
    }
}
