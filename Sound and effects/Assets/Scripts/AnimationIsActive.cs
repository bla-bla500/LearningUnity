using UnityEngine;

public class AnimationIsActive : StateMachineBehaviour
{
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime < 1)
        {
            animator.SetBool("animationActive", true);
        }
        else
        {
            animator.SetBool("animationActive", false);
        }
        Debug.Log(animator.GetBool("animationActive"));
    }
}
