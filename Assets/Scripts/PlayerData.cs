using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="PlayerData")]
public class PlayerData : ScriptableObject {

    [HideInInspector]
    public int score = 0;

    public KeyCode up;
    public KeyCode down;
    public Transform paddle;

}
