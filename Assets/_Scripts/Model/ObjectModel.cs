using UnityEngine;

public class ObjectModel
{
    public enum Type
    {
        DEFAULT,
        CIRCLE
    }
    
    private string _name = "no name yet)";
    private Type _type = Type.DEFAULT;
    private ObjectView _objectView;
    private bool _selected = false;

    public void SetStateView(ObjectView objectView)
    {
        this._objectView = objectView;
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

    public void SetSelected(bool selected)
    {
        this._selected = selected;
        this._objectView.UpdateView();
    }

    public bool IsSelected()
    {
        return this._selected;
    }

}
