using UnityEngine;

public class BotStateMachine : MonoBehaviour
{
    private IBotState currentState;

    public void ChangeState(IBotState newState)
    {
        if (currentState != null) currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    void Update()
    {
        if (currentState != null)
            currentState.Execute();
    }
}