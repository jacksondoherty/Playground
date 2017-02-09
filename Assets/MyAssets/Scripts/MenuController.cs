using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour {

    public Transform itemSpawnLocation;
    public Transform itemSpawnLocation2;
    public Transform itemSpawnLocation3;
    public GameObject gunPrefab;
    public GameObject bowPrefab;
    public GameObject arrowPrefab;
    public GameObject lightBoxPrefab;

    private bool gravityON = true;
    private int velocity = 5;

    public void GunButtonListener() {
        spawnItem(gunPrefab, itemSpawnLocation);
    }

    public void BowAndArrowButtonListener() {
        spawnItem(bowPrefab, itemSpawnLocation3);
        for (int i = 1; i <= 5; i++) {
            spawnItem(arrowPrefab, itemSpawnLocation2);
        }
    }

    public void LightBoxButtonListener() {
        spawnItem(lightBoxPrefab, itemSpawnLocation);
    }

    public void spawnItem(GameObject itemPrefab, Transform spawnLocation) {
        GameObject item = Instantiate(itemPrefab, spawnLocation.position, spawnLocation.rotation);
        if (!gravityON) {
            Rigidbody body = item.GetComponent<Rigidbody>();
            body.useGravity = false;
            body.AddForce(new Vector3(0, velocity, 0));
        }
    }

    public void GravityOnOffListener() {
        gravityON = !gravityON;
        GameObject[] items = GameObject.FindGameObjectsWithTag("item");
        foreach (GameObject item in items) {
            Rigidbody body = item.GetComponent<Rigidbody>();
            body.useGravity = gravityON;
            if (!gravityON) {
                body.AddForce(new Vector3(0, 5, 0));
            }
        }
    }
}
