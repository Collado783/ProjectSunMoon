
public class GameManager
{
    public int unlockedLevels { get; private set; }
    public int selectedLevel = 1;
    public int completedLevel = 0;


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

    
    public void UnlockLevels(int completedLevel) //this variable is so it doesn't increment linearly, it just increments the level you just completed. 
    {
        if (completedLevel < unlockedLevels) //this condition checks if the level you completed is < than the ones you have unlocked, it gets out of the method. This allows you to play a past level that you had already played without incrementing the ones in front.
        {
            return;
        }
        unlockedLevels += completedLevel;

    }


}
