using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    private PropertyInspector _propetyInspector;
    
    void Awake()
    {
        _propetyInspector = GameObject.FindGameObjectWithTag("Inspector").GetComponent<PropertyInspector>();
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        print("background clicked ");
        // if click background, then cancel editing of anything selected
        _propetyInspector.BUTTON_ACTION_CancelEditing();
    }


}
