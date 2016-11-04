using UnityEngine;
using System.Collections;

public class ButtonHandler : MonoBehaviour {
    public void EnableDisable(GameObject go)
    {
        if (go.activeSelf)
        {
            go.SetActive(false);
        }
        else
        {
            go.SetActive(true);
        }
    }
}
