using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCreator : MonoBehaviour 
{
    public GameObject planePrefab;
    private GameObject[] createdPlanes = new GameObject[4];

    void Start()
    {
        if (planePrefab == null)
        {
            Debug.LogError("Plane prefab is not assigned!");
            return;
        }

        CreateOpenBox();
    }

    void OnDestroy()
    {
        foreach (var plane in createdPlanes)
        {
            if (plane != null)
            {
                Destroy(plane);
            }
        }
    }

    void CreateOpenBox()
    {
        float w = SceneTransitionWithBox.BoxParameters.width;
        float h = SceneTransitionWithBox.BoxParameters.height;
        float d = SceneTransitionWithBox.BoxParameters.depth;

        createdPlanes[0] = CreatePlane(new Vector3(0, 0, 0), Quaternion.Euler(90, 0, 0), w, d); 
        createdPlanes[1] = CreatePlane(new Vector3(0, h/2, d/2), Quaternion.identity, w, h);
        createdPlanes[2] = CreatePlane(new Vector3(0, h/2, -d/2), Quaternion.identity, w, h);
        createdPlanes[3] = CreatePlane(new Vector3(w/2, h/2, 0), Quaternion.Euler(0, 0, 90), d, h);
    }

    GameObject CreatePlane(Vector3 position, Quaternion rotation, float scaleX, float scaleZ)
    {
        GameObject plane = Instantiate(planePrefab);
        plane.transform.position = position;
        plane.transform.rotation = rotation;
        plane.transform.localScale = new Vector3(scaleX, 1, scaleZ);
        return plane;
    }
}