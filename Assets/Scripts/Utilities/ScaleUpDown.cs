using UnityEngine;
using DG.Tweening;

public class ScaleUpDown : MonoBehaviour
{
    public float scaleDuration = 1f;
    public float loopDelay = 1f;
    public Vector3 maxScale = new Vector3(2f, 2f, 2f); // Adjust as needed

    void Start()
    {
        // Call the ScaleUpDownEffect method when the script starts
        ScaleUpDownEffect();

        // Uncomment the line below if you want to run the scaling effect in a loop
        InvokeRepeating("ScaleUpDownEffect", scaleDuration + loopDelay, scaleDuration * 2 + loopDelay);
    }

    void ScaleUpDownEffect()
    {
        // Scale up
        transform.DOScale(maxScale, scaleDuration)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                // Scale down after scaling up
                transform.DOScale(Vector3.one, scaleDuration)
                    .SetEase(Ease.InQuad);
            });
    }
}