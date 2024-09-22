using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsTriggerController : MonoBehaviour
{
  public Animator animator;

  public void TriggerHitAnimation(string hitLocation) {
    if (hitLocation == "foot") {
      animator.SetTrigger("FootShotTrigger");
    }
  }
}