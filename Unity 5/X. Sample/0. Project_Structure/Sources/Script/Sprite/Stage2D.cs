using UnityEngine;
using UnityEngine.UI;
using Game.Framework.View.Builder;
using Game.Framework.View.Builder.StandardComponent;
using Game.Framework.View.Utility;
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
            GameObject obj = builder.Build(SpriteBuilder.ID, "Wheel_obj_1", "Goods/icon_product_1");
            Vector2 pixelsSize = SpriteUtility.GetPixelsSize(obj.GetComponent<SpriteRenderer>());
            Debug.Log(string.Format("Screen size: {0}, Pixel size: {1}", Camera.main.pixelRect, pixelsSize));
        }
	
	    // Update is called once per frame
	    void Update () {
	
	    }
    }
}
