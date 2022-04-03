using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Conquest {

    public class Barrier : Interactable {

        [Header("Barrier")]
        public Transform destinationOnBarrierEnter;
        public Transform destinationOnBarrierExit;
        public NavMeshObstacle obstacle;

        public UnityEvent onBarrierEntered;
        private bool barrierEntered;

        public override void OnFocus() {

            StartCoroutine(EnterBarrier());
        }

        public override void OnDefocus() { }

        private IEnumerator EnterBarrier() {

            barrierEntered = !barrierEntered;

            //clear any subscribed event that didn't get invoked
            GameManager.localPlayer.movement.whileMovementWasDisabled = null;

            GameManager.localPlayer.movement.movementDisabled = true;
            obstacle.enabled = false;

            if (barrierEntered) {

                Debug.Log($"<color=green>Entered the room.</color>");
                GameManager.localPlayer.movement.MoveTo(destinationOnBarrierEnter.position);

            } else {

                Debug.Log($"<color=green>Exited the room.</color>");
                GameManager.localPlayer.movement.MoveTo(destinationOnBarrierExit.position);
            }

            yield return new WaitForSeconds(0.5f); //minimum time for the agent to pass through

            GameManager.localPlayer.movement.movementDisabled = false;
            obstacle.enabled = true;
            GameManager.localPlayer.movement.whileMovementWasDisabled?.Invoke();
        }
    }
}
