using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

/*
 * TODO: ensure GameManager GameObject is child of the Canvas - otherwise Image for line won't display .....
 */
public class GameManager : MonoBehaviour
{
    private GameObject line;

    public GameObject stateGOPrefab;
    public GameObject connectorGOPrefab;

    private List<Connector> connectors = new List<Connector>();
    private List<State> states = new List<State>();

    private Connector c;
    
    private Vector3 startPosition = new Vector3(20, -90, 0);
    private GameObject newObjectStartGO;

    private const string START_POSITION_TAG = "Start_Position";
      

    private void Awake()
    {
        newObjectStartGO = GameObject.FindWithTag(START_POSITION_TAG);
    }

    private void Update()
    {
        
//        Vector3 p1 = objectState1.GetPosition();
//        Vector3 p2 = objectState2.GetPosition();
//        DrawLine(p1, p2);
//        print("drawing line from p1-p2 " + p1 + p2);

    }



    public void BUTTON_ACTION_NewState()
    {
        // new state
        State s = new State();
        s.SetName("State " + states.Count);
        states.Add(s);        
        
        GameObject newStateView = (GameObject) Instantiate(stateGOPrefab);
        newStateView.transform.SetParent(transform.parent);
        newStateView.transform.position = newObjectStartGO.transform.position;
        s.SetStateView(newStateView);
        s.UpdateView();
        newStateView.GetComponent<ObjectStateView>().BUTTON_ACTION_Select();
    }
    
    public void BUTTON_ACTION_NewConnector()
    {
        GameObject newConnectorView = (GameObject) Instantiate(connectorGOPrefab);
        newConnectorView.transform.SetParent(transform.parent);
        newConnectorView.transform.position = newObjectStartGO.transform.position;
        
        ConnectorController connectorController = newConnectorView.GetComponent<ConnectorController>();
        
        // get reference to new Connect object in the ConnectorController of new GO created
        Connector c = connectorController.GetConnector();
        connectors.Add(c);
    }


}
