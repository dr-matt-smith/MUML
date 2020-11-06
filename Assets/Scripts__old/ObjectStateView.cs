using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Vector3 = UnityEngine.Vector3;

public class ObjectStateView : MonoBehaviour
{
    public String stateName = "(not defined)";
    private bool _selected = false;

    public Text textName;
    
    private Vector3 _position;
    

    public Image imageSelected;
    public Image imageSelectedDraghandle;
    
    private PropertyInspector _propetyInspector;

    void Awake()
    {
        _propetyInspector = GameObject.FindGameObjectWithTag("Inspector").GetComponent<PropertyInspector>();        
        textName.text = stateName;
    }



    public void BUTTON_ACTION_Select()
    {
        // toggle select
        _selected = !_selected;
        
        if (_selected)
        {
            _propetyInspector.StartEditingState(this);
        }
        else
        {
            _propetyInspector.BUTTON_ACTION_CancelEditing();                     
        }

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
        imageSelected.enabled = _selected;
        imageSelectedDraghandle.enabled = _selected;
    }

}

