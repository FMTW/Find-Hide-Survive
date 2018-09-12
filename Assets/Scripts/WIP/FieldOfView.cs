using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour {

    public float viewRadius;
    public float viewAngle;

    Collider2D[] playerInRadius;
    [SerializeField] LayerMask obstacleMask, playerMash;
    public List<Transform> visiblePlayer = new List<Transform>();


    void FixedUpdate() {
        findVisiblePlayer();
    }

    void findVisiblePlayer() {
        playerInRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius);

        for (int i = 0; i < playerInRadius.Length; i++) {
            Transform player = playerInRadius[i].transform;
            Vector2 dirPlayer = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
            if (Vector2.Angle(dirPlayer, transform.right) < viewAngle / 2) {
                float distancePlayer = Vector2.Distance(transform.position, player.position);

                if (!Physics2D.Raycast(transform.position, dirPlayer, distancePlayer, obstacleMask)) {
                    visiblePlayer.Add(player);
                }
            }

        }

    }

    public Vector3 DirFromAngle(float _angleInDegrees, bool global) {
        if (!global)
        {
            _angleInDegrees += transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Sin(_angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(_angleInDegrees * Mathf.Deg2Rad));
    }

	
}
