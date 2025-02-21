using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using HyperTween.ECS.Structural.Systems;
using Unity.Entities;

namespace HyperTween.Modules.UniTask.API
{
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    [UpdateBefore(typeof(PreTweenStructuralChangeECBSystem))]
    public class TweenCompleteTaskBufferSystem : ComponentSystemBase
    {
        private readonly List<UniTaskCompletionSource> _taskCompletionSources = new();
        
        public void CompleteTask(UniTaskCompletionSource tcs)
        {
            _taskCompletionSources.Add(tcs);
        }
        
        public override void Update()
        {
            foreach (var taskCompletionSource in _taskCompletionSources)
            {
                taskCompletionSource.TrySetResult();
            }
            _taskCompletionSources.Clear();
        }
    }
}