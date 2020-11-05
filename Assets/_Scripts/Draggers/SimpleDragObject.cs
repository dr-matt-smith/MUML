using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/*
 * pointer events for UI objects
 * https://stackoverflow.com/questions/41391708/how-to-detect-click-touch-events-on-ui-and-gameobjects
 *
 * TODO: When clicked, if selected already wait a few milliseconds before de-selecting - time to start dragging
 */

public class SimpleDragObject : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
{
      public const float MAX_WAIT_DRAG_TIME = 0.2f;
      private bool _dragging = false;
      
      private ConnectorController _objectState;
      
      private float _timeLastClicked;
      
      public void OnPointerDown(PointerEventData eventData)
      {
            this._dragging = true;
      }      
        
      public void OnDrag(PointerEventData eventData)
      {
           if (_dragging)
           {
             transform.parent.position = Input.mousePosition;
           }
      }
      
      public void OnEndDrag(PointerEventData eventData)
      {
         if (_dragging)
         {
            _dragging = false;    
         }
      }
      
      
      public void OnBeginDrag(PointerEventData eventData)
      {
      }


}
