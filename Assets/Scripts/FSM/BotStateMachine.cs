// Composant de gestion des �tats du bot.
// Permet de changer d'�tat et d'ex�cuter l'�tat courant � chaque frame.
using UnityEngine;

public class BotStateMachine : MonoBehaviour
{
    private IBotState currentState;

    // M�thode qui g�re le changement d'�tat du bot
    public void ChangeState(IBotState newState)
    {
        if (currentState != null) currentState.Exit(); // Si un �tat est en cour on sort d'abord de l'�tat courant avant passer au nouvelle �tats
        currentState = newState;
        currentState.Enter();
    }

    void Update()
    {
        if (currentState != null)
            currentState.Execute(); // Ex�cute l'�tat courant
    }
}
