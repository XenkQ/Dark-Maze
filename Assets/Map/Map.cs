using UnityEngine;

public class Map : MonoBehaviour
{
    [Header("Map Visibility")]
    [SerializeField] private MeshRenderer mapMeshRenderer;
    [SerializeField] private MeshRenderer mapIconsMeshRenderer;

    private PlayerInteractions playerInteractions;
    private NoteUI noteUI;
    private FleshLight fleshLight;

    private void Awake()
    {
        playerInteractions = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteractions>();
        noteUI = GameObject.FindGameObjectWithTag("NoteUI").GetComponent<NoteUI>();
        fleshLight = GameObject.FindGameObjectWithTag("FleshLight").GetComponent<FleshLight>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)){OnKeyClickMapActions();}
    }

    private void OnKeyClickMapActions()
    {
        if (CanActiveMap())
        {
            EnableMapRender(true);
            fleshLight.PauseFleshLightActions();
            playerInteractions.StopInteractions();
        }
        else
        {
            EnableMapRender(false);
            fleshLight.UnpauseFleshLightActions();
            playerInteractions.ResumeInteractions();
        }
    }

    private bool CanActiveMap()
    {
        return !IsVisible() && !noteUI.contentIsActive;
    }

    public bool IsVisible()
    {
        return mapMeshRenderer.enabled;
    }

    private void EnableMapRender(bool value)
    {
        mapMeshRenderer.enabled = value;
        mapIconsMeshRenderer.enabled = value;
    }
}