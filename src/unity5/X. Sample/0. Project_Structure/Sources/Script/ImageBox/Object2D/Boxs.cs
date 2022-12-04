﻿using UnityEngine;
using UnityEngine.UI;
using Game.Framework.View.Builder;
using Game.Framework.View.Builder.StandardComponent;
using System.Collections;

namespace Game.Script.ImageBox.Object2D { 
    public class Boxs : MonoBehaviour {

	    // Use this for initialization
	    void Start ()
        {
            // Initial variable

            // Defined builder
            ViewComponentsBuilder builder = new ViewComponentsBuilder();
            builder.SetStage(this.gameObject)
                .SetBuilder(new SpriteBuilder());

            // 2D Sprite
            builder.Build(SpriteBuilder.ID, "Sprite_Wheel").AddComponent<Game.Script.ImageBox.Object2D.Wheel>();
        }
	
	    // Update is called once per frame
	    void Update () {
	
	    }
    }
}
