using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wautuh : MonoBehaviour
{
    public GameObject playuh;
    void Start()
    {
       playuh = GetComponent<GameObject>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playuh.transform.localPosition = new Vector2(15, -4);
    }
}
