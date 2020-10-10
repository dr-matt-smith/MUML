using System;
using UnityEngine;
using UnityEngine.UI;

public class ObjectState : MonoBehaviour
{
    public String stateName = "(not defined)";
    private bool _selected = false;

    public Image imageSelectedIcon;
    public Image imageSelectedHandle;

    public Text textName;


    private PropetyInspector _propetyInspector;

    void Awake()
    {
        _propetyInspector = GameObject.FindGameObjectWithTag("Inspector").GetComponent<PropetyInspector>();
        textName.text = stateName;
    }

    public void BUTTON_ACTION_Select()
    {
        // toggle select
        _selected = !_selected;
        
        if (_selected)
        {
            Select();
        }
        else
        {
            _propetyInspector.BUTTON_ACTION_CancelEditing();                     
        }

    }

    public void Select()
    {
        _selected = true;
        _propetyInspector.StartEditingState(this);
    }

    public void Deselect()
    {
        _selected = false;
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
        imageSelectedIcon.enabled = _selected;        
        imageSelectedHandle.enabled = _selected;        
    }

}

