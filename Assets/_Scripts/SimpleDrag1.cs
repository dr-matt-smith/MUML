using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class SimpleDrag1 : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{

    
    public GameObject prefabLine;
    private Color _dragColor = Color.white;
    private Material _material;

    private bool _dragging = false;
    private Color _startColor;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        _dragging = true;
        _material = gameObject.GetComponent<Image>().material;
        _startColor = _material.GetColor("_Color");
        GetComponent<Image>().color = _dragColor;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        transform.parent.position = Input.mousePosition;
        DrawLine(Vector3.zero, Input.mousePosition);

    }
    
    private void DrawLine(Vector2 pointA, Vector2 pointB)
    {
        float lineWidth = 10;
        /*
 
        Vector3 differenceVector = pointB - pointA;
        GameObject line = (GameObject)Instantiate(prefabLine, this.GetComponent<Transform>());
        RectTransform imageRectTransform = line.GetComponent<RectTransform>();
        imageRectTransform.sizeDelta = new Vector2(differenceVector.magnitude / CenterImg.canvas.scaleFactor, lineWidth);
        imageRectTransform.pivot = new Vector2(0, 0.5f);
        imageRectTransform.localPosition = new Vector3(pointA.x, pointA.y, CenterImg.transform.position.z);
        float angle = Mathf.Atan2(differenceVector.y, differenceVector.x) * Mathf.Rad2Deg;
        line.transform.localRotation = Quaternion.Euler(0, 0, angle);
        */
        
        GameObject line = (GameObject)Instantiate(prefabLine, this.GetComponent<Transform>());
        Destroy(line, 0.1f);
        RectTransform imageRectTransform = line.GetComponent<RectTransform>();

        Vector3 differenceVector = pointB - pointA;
 
        imageRectTransform.sizeDelta = new Vector2( differenceVector.magnitude, lineWidth);
        imageRectTransform.pivot = new Vector2(0, 0.5f);
        imageRectTransform.position = pointA;
        float angle = Mathf.Atan2(differenceVector.y, differenceVector.x) * Mathf.Rad2Deg;
        imageRectTransform.localRotation = Quaternion.Euler(0,0, angle);
    }
    
    


    public void OnEndDrag(PointerEventData eventData)
    {
        print("end drag : " + Time.time);
        _dragging = false;
//        gameObject.GetComponent<Image>().material.SetColor("_Color", _startColor);
        gameObject.GetComponent<Image>().material = _material;
        _material.color =_startColor;
        _material.SetColor("_Color", _startColor);
    }
}
