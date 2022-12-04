using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Sources.Script
{
    public class CanvasScript : MonoBehaviour
    {
        // Use this for initialization game object.
        void Start()
        {
            Debug.Log("Canvas Script");
            //
            Canvas can = this.gameObject.GetComponent<Canvas>();
            if(can != null)
            {
                Debug.Log("Canvas size : " + can.pixelRect.width + ", " + can.pixelRect.height);
            }
        }
    }
}
