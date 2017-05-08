using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectMenuManager : MonoBehaviour {
    public List<GameObject> objectList;
    public List<GameObject> objectPrefabList;
    public List<GameObject> objectMenuUI;
    private int currentObject = 0;
    private int[] objectsDeployed = new int[4];


    void Start () {
        objectList[currentObject].transform.rotation = Quaternion.identity;
	}

    private void LateUpdate() {
        if (objectMenuUI[currentObject].gameObject.name == "Plank") {
            objectList[currentObject].transform.rotation = Quaternion.identity;
        } else if (objectMenuUI[currentObject].gameObject.name == "Goal" ||
            objectMenuUI[currentObject].gameObject.name == "Trampoline" ||
            objectMenuUI[currentObject].gameObject.name == "Portal") {
            objectList[currentObject].transform.rotation = Quaternion.Euler(-90, 0, 0);
        } else if (objectMenuUI[currentObject].gameObject.name == "Funnel") {
            objectList[currentObject].transform.rotation = Quaternion.Euler(90, 0, 0);
        }

    }

    public void MenuLeft() {
        objectMenuUI[currentObject].SetActive(false);
        currentObject--;
        if (currentObject < 0) {
            currentObject = objectList.Count - 1;
        }
        objectMenuUI[currentObject].SetActive(true);
    }

    public void MenuRight() {
        objectMenuUI[currentObject].SetActive(false);
        currentObject++;
        if (currentObject > objectList.Count - 1) {
            currentObject = 0;
        }
        objectMenuUI[currentObject].SetActive(true);
    }

    public void SpawnCurrenObject() {
        if (SceneManager.GetActiveScene().buildIndex == 0) {
            if (objectsDeployed[currentObject] < 2 ) {
                InstantiateObject();
            }
        } else if (SceneManager.GetActiveScene().buildIndex == 1) {
            if (objectsDeployed[currentObject] < 3) {
                InstantiateObject();
            }
        } else if (SceneManager.GetActiveScene().buildIndex == 2) {
            if (objectsDeployed[currentObject] < 4) {
                InstantiateObject();
            }
        } else if (SceneManager.GetActiveScene().buildIndex == 3) {
            if (objectsDeployed[currentObject] < 5) {
                InstantiateObject();
            }
        }
    }

    private void InstantiateObject() {
        Instantiate(objectPrefabList[currentObject], objectList[currentObject].transform.position, objectList[currentObject].transform.rotation);
        objectsDeployed[currentObject]++;
    }
}
