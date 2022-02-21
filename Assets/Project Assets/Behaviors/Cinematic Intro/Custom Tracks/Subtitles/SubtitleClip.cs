using I2.Loc;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleClip : PlayableAsset {

    public string key;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner) {

        var playable = ScriptPlayable<SubtitleBehavior>.Create(graph);
        SubtitleBehavior subtitleBehavior = playable.GetBehaviour();

        subtitleBehavior.key = key;

        return playable;
    }

}
