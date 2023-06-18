using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Area"))
        {
            return;
        }

        Vector3 playerPosition = GameManager.instance.player.transform.position;
        Vector3 myPosition = transform.position;
        float differenceX = Mathf.Abs(playerPosition.x - myPosition.x);
        float differenceY = Mathf.Abs(playerPosition.y - myPosition.y);

        Vector3 playerDirction = GameManager.instance.player.inputVector;
        float directionX = playerDirction.x < 0 ? -1 : 1;
        float directionY = playerDirction.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                if (differenceX > differenceY)
                {
                    transform.Translate(Vector3.right * directionX * 40);
                }
                else if (differenceX < differenceY)
                {
                    transform.Translate(Vector3.up * directionY * 40);
                }
                break;
            case "Enemy":
                break;
        }
    }
}
