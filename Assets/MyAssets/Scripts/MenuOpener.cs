using UnityEngine;
using System.Collections;
using VRTK;

public class MenuOpener : MonoBehaviour {

    public GameObject menu;

    // Use this for initialization
    void Start() {
        menu.SetActive(false);
        GetComponent<VRTK_ControllerEvents>().ApplicationMenuPressed += new ControllerInteractionEventHandler(OpenCloseMenu);
    }

    // Update is called once per frame
    void Update() {
    }

    private void OpenCloseMenu(object sender, ControllerInteractionEventArgs e) {
        if (menu.activeSelf) {
            menu.SetActive(false);
        } else {
            menu.SetActive(true);
        }
    }
}