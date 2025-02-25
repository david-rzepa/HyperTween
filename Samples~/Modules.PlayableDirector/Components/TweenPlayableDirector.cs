using HyperTween.Auto.Systems;
using HyperTween.ECS.Invoke.Components;
using HyperTween.ECS.Update.Components;
using UnityEngine;
using UnityEngine.Playables;
using Unity.Entities;

namespace HyperTween.Modules.PlayableDirector.Components
{
    [UpdateAfter(typeof(TweenInvokeAction_ManagedTweenInvokeOnPlaySystem))]
    public class TweenPlayableDirector : ITweenInvokeOnPlay
    {
        public UnityEngine.Playables.PlayableDirector PlayableDirector;
        public PlayableAsset PlayableAsset;
        
        public void Invoke(in TweenDuration tweenDuration)
        {
            if (!PlayableDirector.gameObject.activeInHierarchy)
            {
                Debug.LogError($"Cannot play disabled {nameof(PlayableDirector)}: {PlayableDirector.name}", PlayableDirector);
                return;
            }

            PlayableDirector.Play(PlayableAsset);
            
            if (!PlayableDirector.playableGraph.IsValid())
            {
                PlayableDirector.RebuildGraph();
            }

            PlayableDirector.playableGraph.GetRootPlayable(0).SetSpeed(PlayableAsset.duration / tweenDuration.Value);
        }
    }
}