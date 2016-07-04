using UnityEngine;
using UnityEngine.UI;
using Game.Framework.View.Builder;
using Game.Framework.View.Builder.StandardComponent;
using Game.Framework.View.Utility;
using System.Collections;

namespace Game.Script.ImageBox.Object2D
{ 
    public class Wheel : MonoBehaviour {
        // Variable member 
        string[] mResourceImages = new string[]
        {
            "ImageBox/icon_resource_1",
            "ImageBox/icon_resource_2",
            "ImageBox/icon_resource_3",
            "ImageBox/icon_specialty_1",
            "ImageBox/icon_specialty_2",
            "ImageBox/icon_specialty_3",
            "ImageBox/icon_product_1",
            "ImageBox/icon_product_2",
            "ImageBox/icon_product_3"
        };
        int[] mWheelList = new int[] { 0, 1, 2, 8, 7, 6, 3, 4, 5, 0 };
        ArrayList mBlocks = new ArrayList();
        float step;


	    // Use this for initialization
	    void Start () {
            // Initial variable
            step = -1;
            // Defined builder
            ViewComponentsBuilder builder = new ViewComponentsBuilder();
            builder.SetStage(this.gameObject)
                .SetBuilder(new SpriteBuilder());

            // Create Wheel object
            GameObject obj = null;
            for (int i = 0; i < this.mWheelList.Length; i++)
            {
                if(this.mWheelList[i] >= 0 && this.mWheelList[i] < this.mResourceImages.Length)
                { 
                    obj = builder.Build(SpriteBuilder.ID, "Block_" + i, this.mResourceImages[this.mWheelList[i]]);
                    obj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    this.mBlocks.Add(obj);
                }
            }
            //this.SpriteSize(obj.GetComponent<SpriteRenderer>());
            for (int i = 0; i < this.mBlocks.Count; i++)
            {
                obj = this.mBlocks[i] as GameObject;
                Vector2 pixelsSize = SpriteUtility.GetPixelsSize(obj.GetComponent<SpriteRenderer>());
                Vector2 screenSize = Camera.main.pixelRect.size;

                obj.transform.localPosition = new Vector3(0, screenSize.y / 2 - (i * (pixelsSize.y + 5) + pixelsSize.y / 2), 0);
            }
        }
	
	    // Update is called once per frame
	    void Update () {
            for (int i = 0; i < this.mBlocks.Count; i++)
            {
                GameObject obj = this.mBlocks[i] as GameObject;
                Vector2 pixelsSize = SpriteUtility.GetPixelsSize(obj.GetComponent<SpriteRenderer>());
                Vector2 screenSize = Camera.main.pixelRect.size;
                Vector3 newPosition = obj.transform.localPosition;
                newPosition.y += step;
                if(newPosition.y > -(screenSize.y / 2 + pixelsSize.y / 2))
                    obj.transform.localPosition = newPosition;
                else
                    obj.transform.localPosition = new Vector3(0, screenSize.y / 2 + pixelsSize.y / 2, 0);
            }
        }
    }
}
