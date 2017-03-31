using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour {

    public Transform itemSpawnLocation1;
    public Transform itemSpawnLocation2;
    public Transform itemSpawnLocation3;
    public GameObject gunPrefab;
    public GameObject bowPrefab;
    public GameObject arrowPrefab;
    public GameObject lightCubePrefab;
    public int velocity;

    private bool gravityON = true;

    public void GunButtonListener() {
        SpawnItem(gunPrefab, itemSpawnLocation1);
    }

    public void BowAndArrowButtonListener() {
        SpawnItem(bowPrefab, itemSpawnLocation3);
        float offset = 0.05f;
        int num = 5;
        for (int i = 1; i <= num; i++) {
            SpawnItem(arrowPrefab, itemSpawnLocation2);
            itemSpawnLocation2.position = itemSpawnLocation2.position + new Vector3(offset, 0, 0);
        }
        itemSpawnLocation2.position = itemSpawnLocation2.position - new Vector3(offset * num, 0, 0);
    }

    public void LightBoxButtonListener() {
        SpawnItem(lightCubePrefab, itemSpawnLocation1);
    }

    public void GravityOnOffListener() {
        gravityON = !gravityON;
        UpdateGravity();
    }

    public void ClearItemsListener() {        
        GameObject[] items = GameObject.FindGameObjectsWithTag("item");
        foreach (GameObject item in items) {
            Destroy(item);
        }
    }

    void SpawnItem(GameObject itemPrefab, Transform spawnLocation) {
        GameObject item = Instantiate(itemPrefab, spawnLocation.position, spawnLocation.rotation);
        // TODO: just update gravity on this single item
        UpdateGravity();
    }

    public void UpdateGravity() {
        GameObject[] items = GameObject.FindGameObjectsWithTag("item");
        foreach (GameObject item in items) {
            Rigidbody body = item.GetComponent<Rigidbody>();
            if (body.useGravity != gravityON) {
                body.useGravity = gravityON;
                if (!gravityON) {
                    body.AddForce(new Vector3(0, velocity, 0));
                }
            }
        }
    }
}
