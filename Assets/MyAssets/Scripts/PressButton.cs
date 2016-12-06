using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace VRTK {
    public class PressButton : MonoBehaviour {
        public Button button;

        private VRTK_ControllerActions controllerActions;
        private bool delaying = false;
        private bool currentlySelecting;
        private ushort largeRumbleValue = 2000;
        private ushort smallRumbleValue = 500;

        void OnTriggerEnter(Collider other) {
            if (other.gameObject.name == "Head" && !delaying) {
                // rumble
                controllerActions = other.GetComponentInParent(typeof(VRTK_ControllerActions)) as VRTK_ControllerActions;
                controllerActions.TriggerHapticPulse(largeRumbleValue);

                currentlySelecting = true;
                button.Select();
            }
        }

        void OnTriggerExit(Collider other) {
            if (other.gameObject.name == "Head" && !delaying && currentlySelecting) {
                // rumble
                controllerActions = other.GetComponentInParent(typeof(VRTK_ControllerActions)) as VRTK_ControllerActions;
                controllerActions.TriggerHapticPulse(500);

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

}