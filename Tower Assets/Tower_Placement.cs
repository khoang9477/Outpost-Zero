using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Placement : MonoBehaviour
{
    public GameObject[] towerPrefabs;   //Array to number of towers
    private GameObject selectedTower;   //selected tower

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //Detect LMB
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("BuildSpot"))
                {
                    BuildTower(hit.collider.gameObject);
                }
            }
        }
    }

    public void SelectTower(int towerIndex)
    {
        selectedTower = towerPrefabs[towerIndex];
    }

    void BuildTower(GameObject buildSpot)
    {
        if (selectedTower != null)
        {
            //Check if occupied
            if (buildSpot.transform.childCount == 0)
            {
                //instantiate the tower to build
                GameObject newTower = Instantiate(selectedTower, buildSpot.transform.position, Quaternion.identity);
                newTower.transform.parent = buildSpot.transform;
            }
            else
            {
                Debug.Log("Cannot build here.");
            }
        }
        else
        {
            Debug.Log("No tower selected!");
        }
    }

    // public void OnTowerButtonClicked(int towerIndex)
    // {
    //     FindObjectOfType<Tower_Placement>().SelectTower(towerIndex);
    // }
}
