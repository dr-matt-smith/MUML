using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class ObjectView : MonoBehaviour
{
    private Text textDebug;
    
    public Text textName;
    public SimpleDragObject simpleDragObject;
        
    private Vector3 _position;

    public Image imageBackground;


    private Color _colorSelected = Color.yellow;
    
    private ObjectModel _objectModel;

    private void Awake()
    {
        textDebug = GameObject.FindWithTag("DebugText").GetComponent<Text>();
    }


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
        if (_objectModel.IsSelected())
        {
            imageBackground.color = _colorSelected;
            textDebug.text = "selected = TRUE";
        }
        else
        {
            textDebug.text = "selected = FALSE";
            imageBackground.color = Color.white;
        }
    }


    public void SetPosition(Vector3 newPosition)
    {
        this._position = newPosition;
    }

    public Vector3 GetPosition()
    {
        return this._position;
    }




    private void RandomName()
    {
        int n = Random.Range(1, 99);
        this._objectModel.SetName("Object: " + n);
    }

}

