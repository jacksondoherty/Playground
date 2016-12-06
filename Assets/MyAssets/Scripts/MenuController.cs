using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour {

    public GameObject itemSpawnLocation;
    public GameObject gun;
    public GameObject bow;
    public GameObject arrow;
    public GameObject lightBox;

    public void GunButtonListener() {
        Instantiate(gun, itemSpawnLocation.transform.position, itemSpawnLocation.transform.rotation);
    }

    public void BowAndArrowButtonListener() {
        Instantiate(bow, itemSpawnLocation.transform.position, itemSpawnLocation.transform.rotation);
        for (int i = 1; i <= 5; i++) {
            Instantiate(arrow, itemSpawnLocation.transform.position, itemSpawnLocation.transform.rotation);
        }
    }

    public void LightBoxButtonListener() {
        Instantiate(lightBox, itemSpawnLocation.transform.position, itemSpawnLocation.transform.rotation);
    }
}
