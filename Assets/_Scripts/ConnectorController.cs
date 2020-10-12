using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class ConnectorController : MonoBehaviour
{
    public String stateName = "(not defined)";
    private bool _selected = false;

    public Image imageSelectedIcon;
    public Image imageSelectedHandle;

    public Text textName;

    private Vector3 _position;

    public void BUTTON_ACTION_Select()
    {
        // toggle select
        _selected = !_selected;
        
        if (_selected)
        {
//            _propetyInspector.StartEditingState(this);
        }
        else
        {
  //          _propetyInspector.BUTTON_ACTION_CancelEditing();                     
        }

        print("connector - selected = " + _selected + " : " + Time.time);

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


    private PropertyInspector _propetyInspector;

    void Awake()
    {
        _propetyInspector = GameObject.FindGameObjectWithTag("Inspector").GetComponent<PropertyInspector>();
        textName.text = stateName;
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
    }

}

