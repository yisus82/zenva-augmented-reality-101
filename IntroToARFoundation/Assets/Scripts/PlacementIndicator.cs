using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlacementIndicator : MonoBehaviour
{
  private ARRaycastManager raycastManager;
  private GameObject placementIndicator;

  void Start()
  {
    raycastManager = FindObjectOfType<ARRaycastManager>();
    placementIndicator = transform.GetChild(0).gameObject;
    placementIndicator.SetActive(false);
  }

  void Update()
  {
    List<ARRaycastHit> hits = new List<ARRaycastHit>();
    raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);
    if (hits.Count > 0)
    {
      placementIndicator.transform.position = hits[0].pose.position;
      placementIndicator.transform.rotation = hits[0].pose.rotation;
      if (!placementIndicator.activeInHierarchy)
      {

        placementIndicator.SetActive(true);
      }
    }
  }
}
