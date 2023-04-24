using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fullscreen : MonoBehaviour
{
    public void FullScreen(bool is_Fullscreen)
    {
        Screen.fullScreen = is_Fullscreen;
    }
}
