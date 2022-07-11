using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Map : MonoBehaviour
{
    [Header("Map Visibility")]
    [SerializeField] private MeshRenderer mapMeshRenderer;
    [SerializeField] private MeshRenderer mapIconsMeshRenderer;

    [Header("Map Ray Collision")]
    private BoxCollider meshCollider;

    [Header("Other Scripts")]
    [SerializeField] private InLvlPostProcessingManager inLvlPostProcessingManager;
    [SerializeField] private DrawManager drawManager;
    private FleshLight fleshLight;

    private void Awake()
    {
        meshCollider = GetComponent<BoxCollider>();
        fleshLight = GameObject.FindGameObjectWithTag("FleshLight").GetComponent<FleshLight>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)){OnKeyClickMapActions();}
    }

    private void OnKeyClickMapActions()
    {
        if (IsVisible())
        {
            fleshLight.UnpauseFleshLightActions();
            inLvlPostProcessingManager.ActiveDepthOfFieldEffect(false);
            drawManager.gameObject.SetActive(false);
            DisableMapVisibilityWithDrawMode();
        }
        else
        {
            fleshLight.PauseFleshLightActions();
            inLvlPostProcessingManager.ActiveDepthOfFieldEffect(true);
            drawManager.gameObject.SetActive(true);
            EnableMapVisibilityWithDrawMode();
        }
    }

    public bool IsVisible()
    {
        return mapMeshRenderer.enabled;
    }

    private void EnableMapVisibilityWithDrawMode()
    {
        EnableMapRender(true);
        ActiveMapDrawMode();
    }

    private void DisableMapVisibilityWithDrawMode()
    {
        EnableMapRender(false);
        DisableMapDrawMode();
    }

    private void EnableMapRender(bool value)
    {
        mapMeshRenderer.enabled = value;
        mapIconsMeshRenderer.enabled = value;
    }

    private void EnableMapCollider(bool value)
    {
        meshCollider.enabled = value;
    }

    private void ActiveMapDrawMode()
    {
        EnableMapCollider(true);
        GameTimeManager.PauseGame();
        CursorManager.UnlockCursor();
    }

    private void DisableMapDrawMode()
    {
        EnableMapCollider(false);
        GameTimeManager.UnpauseGame();
        CursorManager.LockCursor();
    }
}