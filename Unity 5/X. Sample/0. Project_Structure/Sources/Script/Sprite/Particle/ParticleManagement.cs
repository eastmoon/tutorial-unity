using UnityEngine;
using Game.Framework.View.Builder;
using Game.Framework.View.Builder.StandardComponent;
using System.Collections;

namespace Game.Script.Sprite.Particle
{ 
    public class ParticleManagement : MonoBehaviour {

	    // Use this for initialization
	    void Start () {
            // Defined builder
            ViewComponentsBuilder builder = new ViewComponentsBuilder();
            builder.SetStage(this.gameObject)
                .SetBuilder(new SpriteBuilder());

            // Retrieve origin object and stage.
            GameObject obj = GameObject.Find("Particle");
            GameObject stage = this.gameObject;
            GameObject particle = null;
            SpriteRenderer sr = null;

            if (obj != null)
            {
                int max_particle = 20;
                for(int i = 0; i < max_particle; i++)
                {
                    // Clone particle
                    particle = Object.Instantiate(obj);
                    particle.name = "Particle_" + (i + 1);
                    // Random scale
                    float randomScale = Random.Range(0.01f, 0.15f);
                    if(i != 0)
                        particle.transform.localScale = new Vector3(randomScale, randomScale, 0);
                    // Make sure object non disabled.
                    sr = particle.GetComponent<SpriteRenderer>();
                    if (sr != null && !sr.enabled)
                        sr.enabled = true;
                    // Set particle on stage
                    if (stage != null)
                        particle.transform.parent = stage.transform;
                }
            }
        }
	
	    // Update is called once per frame
	    void Update () {
	    }
    }
}
