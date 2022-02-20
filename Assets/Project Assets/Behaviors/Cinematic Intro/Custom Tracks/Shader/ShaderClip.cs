using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ShaderClip : PlayableAsset {

    public Vector2 offset;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner) {

        var playable = ScriptPlayable<ShaderBehavior>.Create(graph);
        ShaderBehavior shaderBehavior = playable.GetBehaviour();
        shaderBehavior.offset = offset;

        return playable;
    }
}
