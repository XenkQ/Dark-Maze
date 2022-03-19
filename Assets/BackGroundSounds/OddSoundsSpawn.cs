using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OddSoundsSpawn : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private Transform spawnedObjectParent;
    [SerializeField] private GameObject objectWithSound;
    [SerializeField] private float spawningSoundDelayMin = 10;
    [SerializeField] private float spawningSoundDelayMax = 30;
    [SerializeField] private float spawnedObjectsSpeed = 3f;
    private float speedMultipler = 3000;
    private float spawningSoundDelay;
    [SerializeField] private AudioClip[] audioClips;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawningSoundDelay = spawningSoundDelayMin;
    }

    void Update()
    {
        SpawningSoundObjectAfterTime(CheckingForWallsVector());
    }

    private Vector3 CheckingForWallsVector()
    {
        Ray ray = new Ray(player.transform.position, player.transform.TransformDirection(Vector3.back));
        if (Physics.Raycast(ray, out RaycastHit hitinfo, 18f))
        {
            if (hitinfo.transform.gameObject.tag == "Wall")
            {
                Debug.Log("Widaæ œcianê");
                Debug.DrawLine(ray.origin, hitinfo.point, Color.red);
                return hitinfo.point;
            }
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 18f, Color.green);
        }
        return Vector3.zero;
    }

    private void MoveObject(GameObject spawnedSoundObject, float speed)
    {
        spawnedSoundObject.GetComponent<Rigidbody>().AddForce(-spawnedSoundObject.transform.forward * speed * speedMultipler * Time.deltaTime);
    }

    private void SpawningSoundObjectAfterTime(Vector3 spawnPoint)
    {
        if (spawningSoundDelay < 0)
        {
            if(spawnPoint != Vector3.zero)
            {
                GameObject spawnedSoundObject = Instantiate(objectWithSound, spawnPoint, transform.parent.rotation, spawnedObjectParent);
                MoveObject(spawnedSoundObject, spawnedObjectsSpeed);
                spawningSoundDelay = Random.Range(spawningSoundDelayMin, spawningSoundDelayMax + 1);
            }
        }
        else
        {
            spawningSoundDelay -= Time.deltaTime;
        }
    }
}