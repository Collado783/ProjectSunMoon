
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
        unlockedLevels++;
    }


}
