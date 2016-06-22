using UnityEngine;
using UnityEngine.UI;
using Game.Framework.View.ViewComponentsBuilder;
using Game.Framework.View.ViewComponentsBuilder.StandardComponent;
using System.Collections;

namespace Game.Script { 
    public class Stage2D : MonoBehaviour {

	    // Use this for initialization
	    void Start () {
            ViewComponentsBuilder builder = new ViewComponentsBuilder();
            builder.SetStage(this.gameObject)
                .SetBuilder(new CanvasBuilder())
                .SetBuilder(new SpriteBuilder());

            // UI
            builder.Build(CanvasBuilder.ID, "UICnavas");
            // 2D Sprite
            builder.Build(SpriteBuilder.ID, "Wheel_obj_1", "Goods/icon_product_1");
        }
	
	    // Update is called once per frame
	    void Update () {
	
	    }
    }
}
