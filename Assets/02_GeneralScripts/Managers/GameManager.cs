using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static AudioManager AudioManager { get; private set; }
    public static TimerManager TimerManager { get; private set; }
    public static SaveManager SaveManager { get; private set; }
    public static EventManager EventManager { get; private set; }
    public static InputManager InputManager { get; private set; }
    public static UIViewManager UIViewManager { get; private set; }
    public static DialogueManager DialogueManager { get; private set; }
    public static TutorialManager TutorialManager { get; private set; }

    private Manager[] activeManagers;

    private void Awake()
    {
        Instance = this;
        ManagerSetup();
    }

    private void SingletonSetup()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void ManagerSetup()
    {
        AudioManager = new AudioManager();
        TimerManager = new TimerManager();
        SaveManager = new SaveManager();
        EventManager = new EventManager();
        InputManager = new InputManager();
        DialogueManager = new DialogueManager();
        TutorialManager = new TutorialManager();
        UIViewManager = new UIViewManager();

        activeManagers = new Manager[] {
            AudioManager,
            TimerManager,
            SaveManager,
            EventManager,
            InputManager,
            DialogueManager,
            TutorialManager,
            UIViewManager,
        };

        foreach (Manager manager in activeManagers)
        {
            manager.Setup();
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene loadedScene, LoadSceneMode loadSceneMode)
    {
        foreach (Manager manager in activeManagers)
        {
            manager.OnSceneLoad();
        }
    }
    
    private void FixedUpdate()
    {
        foreach (Manager manager in activeManagers)
        {
            manager.OnFixedUpdate();
        }
    }

    #region SaveManager ContextMenu
    [ContextMenu("SaveManager/Save")] public void Save() => SaveManager?.Save();
    [ContextMenu("SaveManager/Load")] public void Load() => SaveManager?.Load();
    [ContextMenu("SaveManager/DeleteSave")] public void DeleteSave() => SaveManager?.DeleteSave();

    #endregion

    public void StartDialogue(DialogueData dialogueData)
    {
        DialogueManager.QueueDialogue(dialogueData);
    }

    public void StartTutorial(TutorialStep tutorialStep)
    {
        TutorialManager.QueueTutorial(tutorialStep);
    }
}

