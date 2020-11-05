﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

/*
 * TODO: ensure GameManager GameObject is child of the Canvas - otherwise Image for line won't display .....
 */
public class GameManager : MonoBehaviour
{
    private GameObject line;

    public GameObject stateGOPrefab;
    public GameObject connectorGOPrefab;
    public GameObject objectViewGOPrefab;

    public Transform canvasDiagram;

    private List<Connector> connectors = new List<Connector>();
    private List<State> states = new List<State>();
    private List<ObjectModel> objectModels = new List<ObjectModel>();

    private Connector c;
    
    private Vector3 startPosition = new Vector3(20, -90, 0);
    private GameObject newObjectStartGO;

    private const string START_POSITION_TAG = "Start_Position";

    private CanvasScaler _diagramCanvasScaler;
      

    private void Awake()
    {
        newObjectStartGO = GameObject.FindWithTag(START_POSITION_TAG);
        _diagramCanvasScaler = canvasDiagram.GetComponent<CanvasScaler>();
    }

    private void Update()
    {
        
//        Vector3 p1 = objectState1.GetPosition();
//        Vector3 p2 = objectState2.GetPosition();
//        DrawLine(p1, p2);
//        print("drawing line from p1-p2 " + p1 + p2);

    }

    public void BUTTON_ACTION_NewObject()
    {
//        print(1 + " scale facor = " + _diagramCanvasScaler.scaleFactor);
//        _diagramCanvasScaler.scaleFactor = 1;
//        print(2 + " scale facor = " + _diagramCanvasScaler.scaleFactor);
//        
        // new state
        ObjectModel om = new ObjectModel();
        objectModels.Add(om);        
        
        GameObject newObjectView = (GameObject) Instantiate(objectViewGOPrefab);
        newObjectView.transform.SetParent(canvasDiagram);
        newObjectView.transform.position = newObjectStartGO.transform.position;

        newObjectView.transform.localScale *= _diagramCanvasScaler.scaleFactor;


        // link Model and View
        newObjectView.GetComponent<ObjectView>().SetModel(om);
        om.SetStateView(newObjectView.GetComponent<ObjectView>());

        // ensure new object is selected
        // @TODO: de-select ALL other objects!
        om.SetSelected(true);
    }

    public void BUTTON_ACTION_NewState()
    {
        // new state
        State s = new State();
        s.SetName("State " + states.Count);
        states.Add(s);        
        
        GameObject newStateView = (GameObject) Instantiate(stateGOPrefab);
        newStateView.transform.SetParent(canvasDiagram);
        newStateView.transform.position = newObjectStartGO.transform.position;
        newStateView.transform.localScale *= _diagramCanvasScaler.scaleFactor;

        
        s.SetStateView(newStateView);
        s.UpdateView();
        newStateView.GetComponent<ObjectStateView>().BUTTON_ACTION_Select();
    }
    
    public void BUTTON_ACTION_NewConnector()
    {
        GameObject newConnectorView = (GameObject) Instantiate(connectorGOPrefab);
        newConnectorView.transform.SetParent(canvasDiagram);
        newConnectorView.transform.position = newObjectStartGO.transform.position;
        newConnectorView.transform.localScale *= _diagramCanvasScaler.scaleFactor;

        
        ConnectorController connectorController = newConnectorView.GetComponent<ConnectorController>();
        
        // get reference to new Connect object in the ConnectorController of new GO created
        Connector c = connectorController.GetConnector();
        connectors.Add(c);
    }

    public void BUTTON_ACTION_scaleRest()
    {
        SetDiagramScale(1);
    }
    
    public void SetDiagramScale(System.Single scale)
    {
        _diagramCanvasScaler.scaleFactor = scale;
    }
}
