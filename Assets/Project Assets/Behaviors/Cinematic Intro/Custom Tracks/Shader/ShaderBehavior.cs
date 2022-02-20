using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ShaderBehavior : PlayableBehaviour {

    public Vector2 offset;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData) {
    
        CanvasRenderer cRenderer = playerData as CanvasRenderer;
        if (cRenderer){

            
            cRenderer.GetMaterial()?.SetTextureOffset("_MainTex", info.weight * offset);
        }
    }
}
