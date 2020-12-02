using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickEvents : MonoBehaviour
{

    public void DeactivateThisObject()
    {
        this.gameObject.SetActive(false);
    }

}
