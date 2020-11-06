using System.Transactions;
using UnityEngine;

public class ObjectModelState: ObjectModel
{
    public enum StateType
    {
        DEFAULT,
        INITIAL, 
        FINAL
    }

    private StateType _stateType = StateType.DEFAULT;

    public ObjectModelState()
    {
        GameManager.AddObjectModel(this);
        SetObjectType(ObjectType.STATE);
    }

    public void SetStateType(StateType stateType)
    {
        this._stateType = stateType;
    }
    
    public StateType GetStateType()
    {
        return this._stateType;
    }
}
