using UnityEngine;
using UnityEngine.UI;

public class TowerPlacementManager : MonoBehaviour
{
    public GameObject[] towerPrefabs;  // Array to hold different tower prefabs
    public GameObject selectedTowerPrefab;  // The currently selected tower to place

    void Start()
    {
        selectedTowerPrefab = null;
    }

    // Method to assign selected tower from UI buttons
    public void SelectTower(int towerIndex)
    {
        selectedTowerPrefab = towerPrefabs[towerIndex];
    }

    void Update()
    {
        // Check for mouse click to place tower if a tower is selected
        if (Input.GetMouseButtonDown(0) && selectedTowerPrefab != null)
        {
            // Get mouse position and convert to world space
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits a valid placement spot
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("PlacementSpot"))
                {
                    // Place the selected tower on the hit spot
                    Instantiate(selectedTowerPrefab, hit.collider.transform.position, Quaternion.identity);
                    selectedTowerPrefab = null;  // Reset selected tower after placement
                }
            }
        }
    }
}
