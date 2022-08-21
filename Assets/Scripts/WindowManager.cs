using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public void OpenWindow(GameObject windowToOpen)
    {
        windowToOpen.SetActive(true);
    }

    public void CloseWindow(GameObject windowToClose)
    {
        windowToClose.SetActive(false);
    }
}
