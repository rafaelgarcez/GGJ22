using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Transform visualTransform;
    [SerializeField] Sprite center, left, right;

    public void CenterVisual() => spriteRenderer.sprite = center;
    public void LeftVisual() => spriteRenderer.sprite = left;
    public void RightVisual() => spriteRenderer.sprite = right;

    public void SwapColors() => visualTransform.localScale = new Vector3(visualTransform.localScale.x * -1, visualTransform.localScale.y, visualTransform.localScale.z);

    public void ResetColor()
    {
        if(visualTransform.localScale.x < 0)
         visualTransform.localScale = new Vector3(visualTransform.localScale.x * -1, visualTransform.localScale.y, visualTransform.localScale.z);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "Obstacle":
                Debug.Log("Morreu!");
                gameController.Death();
                break;

            case "Point":
                gameController.AddPoint();
                break;

            case "Swap":
                gameController.Swap();
                break;

            default:
                break;
        }
    }
}
