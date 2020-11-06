using System;
using System.Numerics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class ObjectView : MonoBehaviour
{
    public GameObject imageHighlight;

    public Text textName;
    public SimpleDragObject simpleDragObject;
        
    private Vector3 _position;

    public Image imageBackground;

    protected Color _colorSelected = Color.yellow;
    
    protected ObjectModel _objectModel;

    public void SetModel(ObjectModel objectModel)
    {
        this._objectModel = objectModel;
        simpleDragObject.SetObjectModel(objectModel);
    }

    public ObjectModel GetObjectModel()
    {
        return this._objectModel;
    }

    public void UpdateView()
    {
        textName.text = this._objectModel.GetName();
        
        // selecting
        if (_objectModel.IsSelected())
        {
            imageBackground.color = _colorSelected;
        }
        else
        {
            imageBackground.color = Color.white;
        }

        // highlighting
        imageHighlight.SetActive(_objectModel.IsHighlighted());
    }


    public void SetPosition(Vector3 newPosition)
    {
        this._position = newPosition;
    }

    public Vector3 GetPosition()
    {
        return this._position;
    }


}

