using System.Collections;
using UnityEngine;

public class GoggleOverlay : MonoBehaviour
{
    [Range(0.2f, 1f)] public float transitionTime;
    public AnimationCurve transitionCurve;
    public GameObject goggles;
    private RectTransform gogglesRect;
    private bool currentState = false;
    private int maxGoggleHeight = 1080;
    private float timePassed;
    private void Awake()
    {
        gogglesRect = goggles.GetComponentInChildren<RectTransform>();
        HoloGoggles.OnHoloGogglesTriggered += ToggleHoloGoggles;
        // StartCoroutine(RemoveGoggles());

        gogglesRect.localPosition = new Vector3(
            gogglesRect.localPosition.x,
            maxGoggleHeight,
            gogglesRect.localPosition.z
        );
        goggles.SetActive(false);
    }

    private void OnDestroy() {
        HoloGoggles.OnHoloGogglesTriggered -= ToggleHoloGoggles;
    }
    private IEnumerator AddGoggles()
    {
        goggles.SetActive(true);
        while(timePassed / transitionTime <= 1)
        {
            gogglesRect.anchoredPosition = new Vector2(
                0,
                maxGoggleHeight - (transitionCurve.Evaluate(timePassed / transitionTime) * maxGoggleHeight)
            );
            gogglesRect.localPosition = new Vector3(
                gogglesRect.localPosition.x,
                maxGoggleHeight - transitionCurve.Evaluate((timePassed / transitionTime)) * maxGoggleHeight,
                gogglesRect.localPosition.z
            );
            timePassed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        gogglesRect.anchoredPosition = Vector2.zero;
        gogglesRect.localPosition = Vector3.zero;
    }
    private IEnumerator RemoveGoggles()
    {
        while(timePassed / transitionTime <= 1)
        {
            gogglesRect.anchoredPosition = new Vector2(
                0,
                transitionCurve.Evaluate(timePassed / transitionTime)*maxGoggleHeight
            );
            gogglesRect.localPosition = new Vector3(
                gogglesRect.localPosition.x,
                transitionCurve.Evaluate(timePassed / transitionTime)*maxGoggleHeight,
                gogglesRect.localPosition.z
            );
            timePassed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        goggles.SetActive(false);
    }
    private void ToggleHoloGoggles(object sender, bool active)
    {
        if(!currentState && active)
        {
            currentState = true;
            timePassed = 0;
            StartCoroutine(AddGoggles());
        }
        if(!active && currentState)
        {
            currentState = false;
            timePassed = 0;
            StartCoroutine(RemoveGoggles());
        }
    }
}
