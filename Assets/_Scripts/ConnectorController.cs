using System;
//using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using System.Collections.Generic;



public class ConnectorController : MonoBehaviour
{
    public GameObject sourceGO;
    public GameObject destinationGO;
    
    public String stateName = "(not defined)";
    private bool _selected = false;

    public Image imageSelectedIcon;
    public Image imageSelectedHandle;

    public Text textName;

    private Vector3 _position;

    private Connector _connector;
    
    public GameObject prefabLine;

    private GameObject _line;

    
    
    private PropertyInspector _propertyInspector;

    void Awake()
    {
        _propertyInspector = GameObject.FindGameObjectWithTag("Inspector").GetComponent<PropertyInspector>();
        textName.text = stateName;
        
        _connector = new Connector();
        
        _line = (GameObject)Instantiate(prefabLine, this.GetComponent<Transform>());


    }

    public Connector GetConnector()
    {
        return this._connector;

    }


    public void BUTTON_ACTION_Select()
    {
        // toggle select
        _selected = !_selected;
        
        if (_selected)
        {
//            _propertyInspector.StartEditingState(this);
        }
        else
        {
  //          _propertyInspector.BUTTON_ACTION_CancelEditing();                     
        }

//        print("connector - selected = " + _selected + " : " + Time.time);

    }

    public bool IsSelected()
    {
        return this._selected;
    }

    public void SetPosition(Vector3 newPosition)
    {
        this._position = newPosition;
    }

    public Vector3 GetPosition()
    {
        return this._position;
    }



    public void Deselect()
    {
        _selected = false;
    }

    public void Delete()
    {
        Destroy(gameObject);
    }

    public string getStateName()
    {
        return this.stateName;
    }

    public void SetStateName(string newStateName)
    {
        this.stateName = newStateName;
        textName.text = this.stateName;
    }

    void Update()
    {
//        imageSelectedIcon.enabled = _selected;        
  //          imageSelectedHandle.enabled = _selected;        
        Vector2 sourcePosition = sourceGO.transform.position;
        Vector2 destinationPosition = destinationGO.transform.position;
        DrawLine(sourcePosition, destinationPosition);
        
        _connector.SetSource(sourcePosition);
        _connector.SetDestination(destinationPosition);

    }
    
    
    private void DrawLine(Vector2 pointA, Vector2 pointB)
    {
        print("a = " + pointA + "b = " + pointB);
        
        float lineWidth = 10;
//        GameObject line = (GameObject)Instantiate(prefabLine, this.GetComponent<Transform>());
//        Destroy(line, 0.1f);
        RectTransform imageRectTransform = _line.GetComponent<RectTransform>();

        Vector3 differenceVector = pointB - pointA;
 
        imageRectTransform.sizeDelta = new Vector2( differenceVector.magnitude, lineWidth);
        imageRectTransform.pivot = new Vector2(0, 0.5f);
        imageRectTransform.position = pointA;
        float angle = Mathf.Atan2(differenceVector.y, differenceVector.x) * Mathf.Rad2Deg;
        imageRectTransform.localRotation = Quaternion.Euler(0,0, angle);
    }

}

