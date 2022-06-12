using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelDisable : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private PlayerAudioMenager playerAudioMenager;

    private void OnDisable()
    {
        DisablePlayerFunctions();
        playerAudioMenager.StopAllSound();
    }

    private void DisablePlayerFunctions()
    {
        player.enabled = false;
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerInteractions>().enabled = false;
    }
}
