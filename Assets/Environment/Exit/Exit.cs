using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private WinMenu winMenu;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            winMenu.ActiveWinMenuContent();
        }
    }
}
