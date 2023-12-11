using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARPlacement : MonoBehaviour
{

    public GameObject prefab;
    private GameObject spawnedObject;
    private ARRaycastManager aRRaycastManager;

    /// <summary>
    /// Invoked whenever an object is placed in on a plane.
    /// </summary>
    public static event Action onPlacedObject;


    private GameObject church;
    private GameObject bigChurch;
    private GameObject station;

    void Start()
    {
        //aRRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // need to update placement indicator, placement pose and spawn 
    void Update()
    {

        if (Input.touchCount > 0)
        {
            GetSpawnedObjectChildren();
            /*Touch touch = Input.GetTouch(0); // get the first touch
            Vector2 touchPosition = touch.position; // get the touch position

            ARRaycasting(touchPosition);*/
        }
        else if (Input.GetMouseButton(0))
        {
            GetSpawnedObjectChildren();
            /*Vector3 mousePosition = Input.mousePosition;
            Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);

            ARRaycasting(mousePosition2D);*/
        }
    }

    void GetSpawnedObjectChildren()
    {
        if (spawnedObject != null)
        {
            church = GameObject.Find("igreja1");
            bigChurch = GameObject.Find("matrizFinal");
            station = GameObject.Find("estacaoRodoviariaFinal");
        }
    }
    public void ActivateChurch()
    {
        if (spawnedObject != null)
        {
            GameObject.Find("igreja1").SetActive(true);
            GameObject.Find("matrizFinal").SetActive(false);
            GameObject.Find("estacaoRodoviariaFinal").SetActive(false);
        }
    }
    public void ActivateBigChurch()
    {
        if (spawnedObject != null)
        {
            church.SetActive(false);
            GameObject.Find("matrizFinal").SetActive(true);
            GameObject.Find("estacaoRodoviariaFinal").SetActive(false);
        }
    }
    public void ActivateStation()
    {
        if (spawnedObject != null)
        {
            GameObject.Find("igreja1").SetActive(false);
            GameObject.Find("matrizFinal").SetActive(false);
            GameObject.Find("estacaoRodoviariaFinal").SetActive(true);
        }
    }
    public void DeactivateAll()
    {
        if (spawnedObject != null)
        {
            GameObject.Find("igreja1").SetActive(false);
            GameObject.Find("matrizFinal").SetActive(false);
            GameObject.Find("estacaoRodoviariaFinal").SetActive(false);
        }
    }

    void ARRaycasting(Vector2 pos)
    {
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (aRRaycastManager.Raycast(pos, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneEstimated))
        {
            Pose placementPose = hits[0].pose;
            if (spawnedObject == null)
            {
                // Instantiate the prefab at the hit position
                GetSpawnedObjectChildren();
                spawnedObject = Instantiate(prefab, placementPose.position, placementPose.rotation);

                if (onPlacedObject != null)
                {
                    onPlacedObject();
                }
            }
            else
            {
                // Update the prefab position
                spawnedObject.transform.position = placementPose.position;
            }
        }
    }


}
