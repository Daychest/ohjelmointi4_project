using System.Collections.Generic;
using UnityEngine;

public class CreateInfoEditPage : MonoBehaviour
{
    public Transform infoEditPage;

    public GameObject imagePrefab;
    public Sprite profileSprite;

    public GameObject buttonPrefab;
    public GameObject iconInputfieldPrefab;
    public GameObject nameInputfieldPrefab;
    public GameObject titlePrefab;

    public List<GameObject> gameobjects = new List<GameObject>();







    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject obj = Instantiate(imagePrefab, infoEditPage);
        obj.transform.localPosition = new Vector3(-2, -2, 0);
    }


    public void createInfoEditPage()
    {

    }
}
