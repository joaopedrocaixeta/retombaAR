using System.Diagnostics;

using UnityEngine;

public class ChildToggle : MonoBehaviour
{
    private GameObject prefabInstance;

    // Call this method when the prefab is instantiated
    public void SetPrefabInstance(GameObject instance)
    {
        prefabInstance = instance;
    }

    public void EnableChild(string childName)
    {
        if (prefabInstance == null)
        {
            return;
        }

        foreach (Transform child in prefabInstance.transform)
        {
            child.gameObject.SetActive(child.name == childName);
        }
    }
}