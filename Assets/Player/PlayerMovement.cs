using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("MovementPlayer")]
    [SerializeField] private float speedMultipler = 0;
    private CharacterController controler;
    private Transform playerTransform;

    [Header("Audio")]
    [SerializeField] private AudioClip[] steps;
    [SerializeField] private float timeToPlaySongAfterClick = 1;
    private float buttonTimeIsPressed = 0;
    private AudioSource audioSource;
    private AudioClip lastStep;

    private void Awake()
    {
        controler = GetComponent<CharacterController>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        lastStep = RandomStep();
    }

    private void Update()
    {
        MovePlayer();
        PlayStepsSounds();
    }

    private void MovePlayer()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        float inputVertical = Input.GetAxisRaw("Vertical");

        Vector3 moveVector = (((playerTransform.transform.right * inputHorizontal) + (playerTransform.transform.forward * inputVertical))).normalized * speedMultipler;
        controler.Move(moveVector * Time.deltaTime);
    }

    private void PlayStepsSounds()
    {
        if (Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.S) == false && Input.GetKey(KeyCode.D) == false)
        {
            audioSource.Stop();
            buttonTimeIsPressed = 0;
        }
        else
        {
            buttonTimeIsPressed += Time.deltaTime;
            if (!audioSource.isPlaying && buttonTimeIsPressed > timeToPlaySongAfterClick) 
            {
                audioSource.PlayOneShot(RandomStep()); 
            }
        }
    }

    private AudioClip RandomStep()
    {
        AudioClip step;
        do
        {
            step = steps[Random.Range(0, steps.Length)];
        }
        while (lastStep == step);
        lastStep = step;
        return step;
    }
}