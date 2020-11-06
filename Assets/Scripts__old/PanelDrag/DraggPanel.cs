using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 using UnityEngine.EventSystems;
 
 public class DraggPanel : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler{
    // [SerializeField] userInputSimple user;
 
     [SerializeField] Vector2 clickPosition;
     [SerializeField] Vector2 currentPosition;
 
     [SerializeField] Vector2 startPoint;
     [SerializeField] Vector2 endPoint;
     [SerializeField] bool drag;
     [SerializeField] RectTransform _rectTransform;
 
     [SerializeField] Vector2 minanchor;
     [SerializeField] Vector2 maxanchor;
 
     [SerializeField] Vector2 v1;
     [SerializeField] Vector2 v2;
     
     private Vector2 lastMousePosition;

 
     public void OnPointerClick(PointerEventData eventData)
     {
 
     }
 
     void IBeginDragHandler.OnBeginDrag(PointerEventData eventData){
         _rectTransform = GetComponent<RectTransform>();

         
         startPoint = eventData.position;
         clickPosition = eventData.position;
         startPoint =  eventData.position;
         endPoint =  eventData.position;
         
         lastMousePosition = eventData.position;

     }
 
     public void OnDrag(PointerEventData eventData){
         drag = true;
         endPoint = eventData.position;
         currentPosition = eventData.position;

 
         v1 = clickPosition;
         v2 = currentPosition;
         
         if(currentPosition.x < clickPosition.x){
             v1.x = currentPosition.x;
             v2.x = clickPosition.x;
         }
         if(currentPosition.y < clickPosition.y){
             v1.y = currentPosition.y;
             v2.y = clickPosition.y;
         }
         maxanchor = new Vector2(v2.x/ Screen.width, v2.y / Screen.height);
         minanchor = new Vector2(v1.x/ Screen.width, v1.y / Screen.height);
 
        // user.dragging(v1,v2,false);
         
    //     DragImage.anchorMin = minanchor;
      //   DragImage.anchorMax = maxanchor;
         
/*         Vector2 currentMousePosition = eventData.position;
         Vector2 diff = currentMousePosition - lastMousePosition;
         RectTransform rect = GetComponent<RectTransform>();

         Vector3 newPosition = rect.position +  new Vector3(diff.x, diff.y, transform.position.z);
         Vector3 oldPos = rect.position;
         rect.position = newPosition;
         
         lastMousePosition = currentMousePosition;*/

         /*
         Vector3 newPosition = new  Vector3(eventData.position.x, eventData.position.y, 0);
         
         _rectTransform.position = newPosition;
*/

         transform.position = Input.mousePosition;

     }
     public void OnEndDrag(PointerEventData eventData){
         /*
         drag = false;
       //  user.dragging(v1,v2,true);
 
         startPoint = new Vector2(0f,0f); 
         endPoint = new Vector2(0f,0f);
 
         currentPosition = new Vector2(0f,0f);
 
         minanchor = new Vector2(0f,0f);
         maxanchor = new Vector2(0f,0f);
 
      //   DragImage.anchorMin = new Vector2(0f,0f);
        //  DragImage.anchorMax = new Vector2(0f,0f);
 
         v1 = new Vector2(0f,0f);
         v2 = new Vector2(0f,0f);
 
         drag = false;
         */
     }
 }