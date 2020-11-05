using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class ObjectView : MonoBehaviour
{
    public Text textName;
    
    private Vector3 _position;
    

    public Image imageSelected;
    public Image imageSelectedDraghandle;
    
    private ObjectModel _objectModel;

    public void SetModel(ObjectModel objectModel)
    {
        this._objectModel = objectModel;
    }

    public ObjectModel GetObjectModel()
    {
        return this._objectModel;
    }

    public void UpdateView()
    {
        textName.text = this._objectModel.GetName();
    }


    public void SetPosition(Vector3 newPosition)
    {
        this._position = newPosition;
    }

    public Vector3 GetPosition()
    {
        return this._position;
    }


    void Update()
    {
        imageSelected.enabled = this._objectModel.IsSelected();
        imageSelectedDraghandle.enabled = this._objectModel.IsSelected();
    }

    public void BUTTON_ACTION_randomName()
    {
        int n = Random.Range(1, 99);
        this._objectModel.SetName("Object: " + n);
    }

}

