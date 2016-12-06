using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace VRTK {
    public class ScrollbarControll : MonoBehaviour {
        public GameObject handle;

        private float totalScrollHeight;
        private Scrollbar scrollbarScript;
        private bool isScrolling = false;
        private GameObject wandHead;
        private float startPosition;
        private float startScrollValue = 1;
        private VRTK_ControllerActions controllerActions;
        private ushort largeRumbleValue = 2000;
        private ushort smallRumbleValue = 500;

        void Start() {
            scrollbarScript = GetComponent<Scrollbar>();
            RectTransform scrollbarTransform = this.GetComponent<RectTransform>();
            RectTransform handleTransform = handle.GetComponent<RectTransform>();
            totalScrollHeight = (scrollbarTransform.rect.height - handleTransform.rect.height) * transform.lossyScale.y;
        }

        void Update() {
            if (isScrolling) {
                float currentPosition = wandHead.transform.position.y;
                float delta = currentPosition - startPosition;
                float scrollPercentage = delta / totalScrollHeight;
                scrollbarScript.value = startScrollValue + scrollPercentage;
            }
        }

        void OnTriggerEnter(Collider other) {
            if (other.gameObject.name == "Head") {
                // rumble
                controllerActions = other.GetComponentInParent(typeof(VRTK_ControllerActions)) as VRTK_ControllerActions;
                controllerActions.TriggerHapticPulse(largeRumbleValue);

                isScrolling = true;
                wandHead = other.gameObject;
                startPosition = wandHead.transform.position.y;
                scrollbarScript.Select();
            }
        }

        void OnTriggerExit(Collider other) {
            if (other.gameObject.name == "Head") {
                // rumble
                controllerActions = other.GetComponentInParent(typeof(VRTK_ControllerActions)) as VRTK_ControllerActions;
                controllerActions.TriggerHapticPulse(smallRumbleValue);

                isScrolling = false;
                wandHead = null;
                startPosition = -1.0f; // flag
                startScrollValue = scrollbarScript.value;
                EventSystem.current.SetSelectedGameObject(null);
            }
        }
    }
}
