using Cysharp.Threading.Tasks;
using HyperTween.ECS.Invoke.Components;
using HyperTween.Modules.UniTask.API;
using Unity.Entities;

namespace HyperTween.Modules.UniTask.Components
{
    public class TweenCompleteTask : ITweenInvokeOnStop
    {
        public UniTaskCompletionSource TaskCompletionSource;

        public void Invoke(ref SystemState state)
        {
            // TODO: Make this more performant somehow...
            var tweenCompleteTaskBufferSystem = state.World.GetExistingSystemManaged<TweenCompleteTaskBufferSystem>();
            tweenCompleteTaskBufferSystem.CompleteTask(TaskCompletionSource);
        }
        
    }
}