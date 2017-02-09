using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using VRTK;

public class PressButton : MonoBehaviour {
    public Button button;
    public Scrollbar scrollbar;

    private VRTK_ControllerActions controllerActions;
    private bool delaying = false;
    private bool currentlySelecting;
    private ushort largeRumbleValue = 2000;
    private ushort smallRumbleValue = 500;
    private ScrollbarControll scrollbarScript;

    void Start() {
        scrollbarScript = scrollbar.GetComponent<ScrollbarControll>();
    }

    void OnTriggerEnter(Collider other) {
        if (scrollbarScript.isScrolling) return;

        if (other.gameObject.name == "Head" && !delaying) {
            // rumble
            controllerActions = other.GetComponentInParent(typeof(VRTK_ControllerActions)) as VRTK_ControllerActions;
            controllerActions.TriggerHapticPulse(largeRumbleValue);

            currentlySelecting = true;
            button.Select();
        }
    }

    void OnTriggerExit(Collider other) {
        if (scrollbarScript.isScrolling) return;

        if (other.gameObject.name == "Head" && !delaying && currentlySelecting) {
            // rumble
            controllerActions = other.GetComponentInParent(typeof(VRTK_ControllerActions)) as VRTK_ControllerActions;
            controllerActions.TriggerHapticPulse(smallRumbleValue);

            button.onClick.Invoke();
            EventSystem.current.SetSelectedGameObject(null);
            currentlySelecting = false;
            StartCoroutine(DelayButton());
        }
    }

    // prevents accidental double clicking
    IEnumerator DelayButton() {
        delaying = true;
        yield return new WaitForSeconds(0.01f);
        delaying = false;
    }
}