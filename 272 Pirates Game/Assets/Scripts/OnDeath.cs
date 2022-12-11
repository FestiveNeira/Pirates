using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDeath : MonoBehaviour
{
    private void OnDestroy()
    {
        SceneManager.LoadScene("Level 2");
    }
}
