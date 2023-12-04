using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raft : MonoBehaviour
{
    [SerializeField] private GameManagment GMT;
    private void OnTriggerEnter(Collider other)
    {
        GMT.Glowing();
        StartCoroutine(Glow());

    }

    private IEnumerator Glow()
    {
        yield return new WaitForSeconds(1);
        GMT.Raft();
    }
}
