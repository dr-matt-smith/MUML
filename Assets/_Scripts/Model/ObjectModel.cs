using UnityEngine;
using System.Collections.Generic;


public class ObjectModel
{
    public enum ObjectType
    {
        DEFAULT,
        STATE
    }
    
    private string _name = "no name yet)";
    private ObjectType _type = ObjectType.DEFAULT;
    private ObjectView _objectView;
    private bool _selected = false;
    private bool _highlighted = false;
    private Vector3 _position;

    public ObjectModel()
    {
        ObjectModel.AddObjectModel(this);
        this._name = "object " + objectModels.Count;
    }

    public ObjectType GetObjectType()
    {
        return this._type;
    }

    public void SetObjectType(ObjectType objectType)
    {
        this._type = objectType;
    }

    public void SetObjectView(ObjectView objectView)
    {
        this._objectView = objectView;
    }

    public ObjectView GetObjectView()
    {
        return this._objectView;
    }

    public string GetName()
    {
        return this._name;
    }

    public void SetName(string newName)
    {
        this._name = newName;
        this._objectView.UpdateView();
    }


    public void Deselect()
    {
        this._selected = false;
        this._objectView.UpdateView();        
    }

    public bool IsSelected()
    {
        return this._selected;
    }

    public void SetHighlighted(bool highlighted)
    {
        this._highlighted = highlighted;
        this._objectView.UpdateView();
    }

    public bool IsHighlighted()
    {
        return this._highlighted;
    }

    public void SetPosition(Vector3 position)
    {
        this._position = position;
    }

    public void DeleteObject()
    {
        objectModels.Remove(this);
        this._objectView.DeleteGameObject();
    }
    
    // ------ static --------
    private static List<ObjectModel> objectModels = new List<ObjectModel>();
    private static ObjectModel currentSelectedObjectModel = null;

    public static void AddObjectModel(ObjectModel om)
    {
        objectModels.Add(om);
    }

    public static void DeleteSelected()
    {
        ObjectModel selected = GetSelected();
        if (selected != null)
        {
            selected.DeleteObject();
        }
    }

    public static ObjectModel GetSelected()
    {
        foreach (var objectModel in objectModels)
        {
            if (objectModel.IsSelected())
                return objectModel;
        }        
            
        // if get here, none was selected
        return null;
    }
    
    public static string AsString()
    {
        string s = Time.time + "\n selected = " + GetSelected() + "  // "; 
        foreach (var objectModel in objectModels)
        {
            s += "/ " + objectModel._name + "(" + objectModel._type + ")";
        }

        return s;
    }
    
    public static void Select(ObjectModel om)
    {
        // de-select any currently selected object
        if (currentSelectedObjectModel != null)
        {
            currentSelectedObjectModel._selected = false;
            currentSelectedObjectModel._objectView.UpdateView();
        }

        // now select given object
        if (om != null)
        {
            currentSelectedObjectModel = om;
            om._selected = true;
            om._objectView.UpdateView();                    
        }
    }

}
