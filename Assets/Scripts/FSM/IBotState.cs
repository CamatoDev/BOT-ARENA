// Interface de base pour tous les �tats du bot.
// Chaque �tat doit impl�menter ces trois m�thodes.
public interface IBotState
{
    void Enter();   // Appel� lors de l'entr�e dans l'�tat
    void Execute(); // Appel� � chaque frame
    void Exit();    // Appel� lors de la sortie de l'�tat
}
