using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Checkpoint : MonoBehaviour
{
    public GameObject player;
    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = player.GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetFloat("x", gameObject.transform.position.x);
            PlayerPrefs.SetFloat("y", gameObject.transform.position.y);
            PlayerPrefs.SetFloat("z", gameObject.transform.position.z);
            Debug.Log("save pos");
        }
    }
}
