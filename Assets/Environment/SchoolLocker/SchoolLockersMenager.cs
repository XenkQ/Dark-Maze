using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolLockersMenager : MonoBehaviour
{
    [SerializeField] private List<Transform> schoolLockers;
    public List<Transform> GetSchoolLockers()
    {
        return schoolLockers;
    }
}
