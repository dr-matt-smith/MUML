using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;


/**
 * TODO: highlight panel when actively editing?
 * TODO: disable UPDATE/Cancel buttons when NOT editing
 * TODO: highlight active object too - SetHighlight(true/false) - in View Class ?
 */
public class PropertyInspector : MonoBehaviour
{
    public GameObject propetiesPanel;  
    public InputField inputField;

    private ObjectStateView _activeStateObject;

    private void Awake()
    {
        Reset();
    }

    public void StartEditingState(ObjectStateView os)
    {
        propetiesPanel.SetActive(true);
        // if already editing another object, deselect it
        if (_activeStateObject != null)
        {
            _activeStateObject.Deselect();
        }
        
        _activeStateObject = os;
        inputField.text = os.getStateName();        
        inputField.Select();
    }

    public void UpdateSelectedObject()
    {
        if(_activeStateObject !=null)
            _activeStateObject.SetStateName(inputField.text);        
    }

    public void BUTTON_ACTION_CancelEditing()
    {
        if(_activeStateObject != null)            
            _activeStateObject.Deselect();
    
        Reset();
       
    }

    public void BUTTON_ACTIOB_Delete()
    {
        _activeStateObject.Delete();
        Reset();        
    }

    void Reset()
    {
        inputField.text = "(nothing selected)";
        _activeStateObject = null;
        propetiesPanel.SetActive(false);

    }

    
}
