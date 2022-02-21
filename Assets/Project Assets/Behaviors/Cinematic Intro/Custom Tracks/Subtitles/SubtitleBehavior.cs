using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleBehavior : PlayableBehaviour {

    public string key;

    private TextMeshProUGUI text;
    private string keyValue;

    public override void OnBehaviourPlay(Playable playable, FrameData info) {
        base.OnBehaviourPlay(playable, info);

        keyValue = LocalizationManager.GetTermTranslation(key);
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData) {

        text = playerData as TextMeshProUGUI;

        text.text = keyValue;

        Color color = text.color;
        color.a = info.weight;
        text.color = color;
    }
}
