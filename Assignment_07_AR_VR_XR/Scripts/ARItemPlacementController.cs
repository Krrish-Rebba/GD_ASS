using System.Collections.Generic;
using UnityEngine;
#if UNITY_XR_ARFOUNDATION
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
#endif

/// <summary>
/// Practical 7: AR/XR Object Placement Controller
/// Raycasts against detected surfaces to place 3D game models in real/simulated space.
/// Includes an in-editor simulation fallback for testing on PC without a mobile device.
/// </summary>
public class ARItemPlacementController : MonoBehaviour
{
    [Header("Spawn Settings")]
    [Tooltip("The 3D game asset to instantiate (e.g., Character Statue, Golden Amulet, Crystal).")]
    [SerializeField] private GameObject objectToPlacePrefab;

    [Tooltip("Visual indicator placed on the detected surface before placing the object.")]
    [SerializeField] private GameObject placementIndicator;

    private GameObject spawnedObject;

#if UNITY_XR_ARFOUNDATION
    private ARRaycastManager raycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
#endif

    private void Awake()
    {
#if UNITY_XR_ARFOUNDATION
        raycastManager = GetComponent<ARRaycastManager>();
#endif
    }

    private void Update()
    {
        // 1. In-Editor PC Simulation (Mouse Click to test without mobile AR device)
        if (Application.isEditor)
        {
            SimulateEditorPlacement();
            return;
        }

        // 2. Mobile Device AR Touch Handling
        HandleMobileARTouch();
    }

    private void SimulateEditorPlacement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                PlaceOrMoveObject(hit.point, Quaternion.identity);
            }
        }
    }

    private void HandleMobileARTouch()
    {
#if UNITY_XR_ARFOUNDATION
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touchPos = Input.GetTouch(0).position;

            if (raycastManager != null && raycastManager.Raycast(touchPos, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                PlaceOrMoveObject(hitPose.position, hitPose.rotation);
            }
        }
#endif
    }

    private void PlaceOrMoveObject(Vector3 position, Quaternion rotation)
    {
        if (spawnedObject == null)
        {
            spawnedObject = Instantiate(objectToPlacePrefab, position, rotation);
            Debug.Log($"[XR Placement] Placed {objectToPlacePrefab.name} at {position}");
        }
        else
        {
            spawnedObject.transform.position = position;
            Debug.Log($"[XR Placement] Repositioned {spawnedObject.name} to {position}");
        }
    }
}
