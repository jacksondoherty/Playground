using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCube : MonoBehaviour {

    public Material normalColor;
    public Material collisionColor;
    public float highlightDuration;

    private Renderer rend;

    void Start() {
        rend = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision collision) {
        string name = collision.gameObject.name;
        if (name == "Bullet(Clone)" || name == "BasicArrow(Clone)") {
            rend.material = collisionColor;
        }
        //Invoke("BackToNormal", highlightDuration);
    }

    /*
    void OnCollisionExit() {
        rend.material = normalColor;
    }

    void BackToNormal() {
        rend.material = normalColor;
    }
    */
}
