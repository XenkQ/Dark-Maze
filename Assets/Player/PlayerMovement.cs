using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerAudioMenager playerAudioMenager;
    [SerializeField] private float speedMultipler = 0;
    [SerializeField] private float timeToPlaySongAfterStep = 0.2f;
    [SerializeField] private CharacterController controler;
    private float timeTheKeyIsPressed = 0;

    private void Update()
    {
        MovePlayerWithStepSound();
    }

    private void MovePlayerWithStepSound()
    {
        MovePlayer();
        PlayStepsSounds();
    }

    private void MovePlayer()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");

        Vector3 moveVector = (((transform.transform.right * inputHorizontal) + (transform.transform.forward * inputVertical))).normalized * speedMultipler;
        controler.Move(moveVector * Time.deltaTime);
    }

    private void PlayStepsSounds()
    {
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            timeTheKeyIsPressed = 0;
        }
        else
        {
            timeTheKeyIsPressed += Time.deltaTime;
            if (timeTheKeyIsPressed > timeToPlaySongAfterStep) 
            {
                playerAudioMenager.PlayRandomStepSound();
            }
        }
    }
}