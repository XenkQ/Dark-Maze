using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolLockersManager : MonoBehaviour
{
    [SerializeField] private List<Transform> schoolLockers;
    public List<Transform> GetSchoolLockers()
    {
        return schoolLockers;
    }
}
