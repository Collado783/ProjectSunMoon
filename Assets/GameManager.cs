
public class GameManager
{
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }

    private static GameManager _instance;

    private GameManager()
    {
        unlockedLevels = 1;
    }

    public int unlockedLevels { get; private set; }
    public int selectedLevel = 1;

    public void UnlockLevels()
    {
        //passar-li una variable perque no incrementi linealment, sino que augmenti segons el nivell que acabes de completar
        //comprovar que no s'estan desbloquejant nivells de més endavant al jugar a nivells anteriors
        unlockedLevels++;
    }


}
