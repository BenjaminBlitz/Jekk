using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (AudioVolumeManager.isInGame)
        {
            if(MenuPause.GamePaused) Cursor.visible = true;
            else Cursor.visible = false;
        }
        else Cursor.visible = true;
    }
}
