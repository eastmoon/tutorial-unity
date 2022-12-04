using UnityEngine;
using UnityEngine.UI;
using Game.Framework.View.Builder;
using Game.Framework.View.Builder.StandardComponent;
using Game.Framework.View.Utility;
using System.Collections;

namespace Game.Script.Particle.UserInterface { 
    public class MainFrame : MonoBehaviour {

	    // Use this for initialization
	    void Start () {
            // Initial variable
            
            // Defined builder
            ViewComponentsBuilder builder = new ViewComponentsBuilder();
            builder.SetStage(this.gameObject)
                .SetBuilder(new CanvasBuilder())
                .SetBuilder(new ButtonBuilder());

            // UI
            builder.SetTarget(this.gameObject).Build(CanvasBuilder.ID, this.GetType().Name);
            Vector2 resoulation = CanvasUtility.GetCanvasScalerResolution(this.GetComponent<CanvasScaler>());

            Button btn = builder.Build(ButtonBuilder.ID, "Button_Change_Color", "Change Particle Color").GetComponent<Button>();
            RectTransform rect = btn.GetComponent<RectTransform>();
            rect.anchoredPosition = new Vector2(resoulation.x - rect.sizeDelta.x, rect.sizeDelta.y - resoulation.y);
            btn.onClick.AddListener(this.OnClickStartWheel); 
        }
	
	    // Update is called once per frame
	    void Update () {
	
	    }

        public void OnClickStartWheel()
        {
            Debug.Log("Click start wheel");
            for(int i = 1; i <= 20; i++)
            {
                GameObject obj = GameObject.Find("Particle_" + i);
                if (obj != null)
                {
                    obj.GetComponent<SpriteRenderer>().material.SetColor("_InnerColor", Color.red);
                    obj.GetComponent<SpriteRenderer>().material.SetColor("_BorderColor", Color.black);
                }
                else
                    Debug.Log("Not Particle_" + i);
            }
        }
    }
}
