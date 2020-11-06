using UnityEngine;

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
        GameManager.AddObjectModel(this);
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

    public void Select()
    {
        this._selected = true;
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

}
