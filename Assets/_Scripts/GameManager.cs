using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/*
 * TODO: ensure GameManager GameObject is child of the Canvas - otherwise Image for line won't display .....
 */
public class GameManager : MonoBehaviour
{
    public ObjectState objectState1;
    public ObjectState objectState2;
    
    public GameObject prefabLine;
    private GameObject line;

    private void Awake()
    {
        line = (GameObject)Instantiate(prefabLine, this.GetComponent<Transform>());
    }

    private void Update()
    {
        Vector3 p1 = objectState1.GetPosition();
        Vector3 p2 = objectState2.GetPosition();
        DrawLine(p1, p2);
//        print("drawing line from p1-p2 " + p1 + p2);
    }


    private void DrawLine(Vector2 pointA, Vector2 pointB)
    {
        float lineWidth = 10;
//        GameObject line = (GameObject)Instantiate(prefabLine, this.GetComponent<Transform>());
//        Destroy(line, 0.1f);
        RectTransform imageRectTransform = line.GetComponent<RectTransform>();

        Vector3 differenceVector = pointB - pointA;
 
        imageRectTransform.sizeDelta = new Vector2( differenceVector.magnitude, lineWidth);
        imageRectTransform.pivot = new Vector2(0, 0.5f);
        imageRectTransform.position = pointA;
        float angle = Mathf.Atan2(differenceVector.y, differenceVector.x) * Mathf.Rad2Deg;
        imageRectTransform.localRotation = Quaternion.Euler(0,0, angle);
    }

}
