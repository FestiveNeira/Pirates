using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public Character[] characters;
    public Character currerntCharatcer;

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if(characters.Length > 0 && currerntCharatcer == null)
        {
            currerntCharatcer = characters[0];
        }
    }

    public void SetCharacter(Character character)
    {
        currerntCharatcer = character;
    }
}
