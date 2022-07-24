using UnityEngine;

[RequireComponent(typeof(UITextInteractionsEffects))]
public class ESCMenu : MonoBehaviour, ICanExitGame
{
    private static bool canBeUsed = true;

    [Header("Contents of menus")]
    [SerializeField] private GameObject settingsMenuContent;
    [SerializeField] private GameObject content;

    [Header("Other Scripts")]
    [SerializeField] private InLvlPostProcessingManager inLvlPostProcessingManager;
    [SerializeField] private PlayerInteractions playerInteractions;
    [SerializeField] private NoteUI noteUI;
    private FleshLight fleshLight;
    private PlayerCamera playerCamera;
    private UITextInteractionsEffects textInteractionsEffects;
    private Map map;

    private void Awake()
    {
        textInteractionsEffects = GetComponent<UITextInteractionsEffects>();
        playerCamera = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<PlayerCamera>();
        fleshLight = GameObject.FindGameObjectWithTag("FleshLight").GetComponent<FleshLight>();
        map = GameObject.FindGameObjectWithTag("Map").GetComponent<Map>();
        UnblockFunctionality();
    }

    private void Update()
    {
        if (canBeUsed)
        {
            PerformActionsOnEscKey();
        }
    }

    private void PerformActionsOnEscKey()
    {
        if (CanActiveESCMenu())
        {
            ESCMenuContentActivationProcess();
        }
        else if (CanDisableESCMenu())
        {
            DisableESCMenuContentProcess();
        }
    }

    private bool CanActiveESCMenu()
    {
        return Input.GetKeyDown(KeyCode.Escape) && content.active == false && settingsMenuContent.active == false;
    }

    private void ESCMenuContentActivationProcess()
    {
        PrepareGameForContentActivation();
        playerInteractions.StopInteractions();
        ActiveContent();
        CursorManager.UnlockCursor();
    }

    private void PrepareGameForContentActivation()
    {
        if (noteUI.contentIsActive == false)
        {
            GameTimeManager.PauseGame();
            playerCamera.DisableCameraRotationScript();
            fleshLight.PauseFleshLightActions();
            inLvlPostProcessingManager.ActiveDepthOfFieldEffect(true);
        }
    }

    private void ActiveContent()
    {
        content.SetActive(true);
    }

    private bool CanDisableESCMenu()
    {
        return Input.GetKeyDown(KeyCode.Escape) && content.active == true;
    }

    private void DisableESCMenuContentProcess()
    {
        PrepareGameForContentDisable();
        textInteractionsEffects.ResetAllTextColors();
        DisableESCMenu();

        if(!map.IsVisible())
        {
            playerInteractions.ResumeInteractions();
        }

        CursorManager.LockCursor();
    }

    private void PrepareGameForContentDisable()
    {
        if (noteUI.contentIsActive == false)
        {
            GameTimeManager.UnpauseGame();
            fleshLight.UnpauseFleshLightActions();
            playerCamera.EnableCameraRotationScript();
            inLvlPostProcessingManager.ActiveDepthOfFieldEffect(false);
        }
    }

    private void DisableESCMenu()
    {
        content.SetActive(false);
    }

    public static void BlockFunctionality()
    {
        if (canBeUsed == true)
        {
            canBeUsed = false;
        }
    }

    public static void UnblockFunctionality()
    {
        if (canBeUsed == false)
        {
            canBeUsed = true;
        }
    }

    public void Exit()
    {
        ApplicationManager.ExitApplication();
    }
}
