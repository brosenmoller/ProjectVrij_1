using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableObject : InteractableObject
{
    [Header("MoveableObject Settings")]
    [SerializeField] private float animationDuration = 2;
    [SerializeField] private bool loop = false;
    [SerializeField] private List<TransformValues> transformValuesList = new();

    [Header("Editor Buttons")]
    [SerializeField] private bool autoChangeAssignIndex = true;
    [SerializeField] private uint assignIndex = 0;
    [SerializeField] private Mesh mesh;

    private bool isDirectionForward = false;
    private int currentIndex = 0;
    private float animationDurationPerSegment;

    private void Start()
    {
        animationDurationPerSegment = animationDuration / transformValuesList.Count;

        if (transformValuesList.Count < 2) 
        {
            IsInteractable = false;
            return;
        }

        SetCorrectTransformInstant();
    }

    protected override void PerformInteraction()
    {
        isDirectionForward = !isDirectionForward;
        SetCorrectTransformAnimated();
    }

    public void AssignTranformValues()
    {
        TransformValues currentTransformValues = TransformValues.GetTransformValues(transform);

        if (assignIndex >= transformValuesList.Count)
        {
            transformValuesList.Add(currentTransformValues);
            if (autoChangeAssignIndex) { assignIndex = (uint)transformValuesList.Count; }
        }
        else
        {
            transformValuesList[(int)assignIndex] = currentTransformValues;
            if (autoChangeAssignIndex) { assignIndex++; }
        }
    }

    public void SetToInitialPosition()
    {
        if (transformValuesList.Count > 0)
        {
            transform.SetLocalPositionAndRotation(transformValuesList[0].position, Quaternion.Euler(transformValuesList[0].rotation));
            transform.localScale = transformValuesList[0].scale;
        }
    }

    private void SetCorrectTransformAnimated()
    {
        StopAllCoroutines();
        StartCoroutine(AnimateTransformValuesPath());
    }

    private void SetCorrectTransformInstant()
    {
        if (isDirectionForward)
        {
            transform.SetLocalPositionAndRotation(transformValuesList[^1].position, Quaternion.Euler(transformValuesList[^1].rotation));
            transform.localScale = transformValuesList[^1].scale;
            currentIndex = transformValuesList.Count - 1;
        }
        else
        {
            transform.SetLocalPositionAndRotation(transformValuesList[0].position, Quaternion.Euler(transformValuesList[0].rotation));
            transform.localScale = transformValuesList[0].scale;
            currentIndex = 0;
        }
    }

    private IEnumerator AnimateTransformValuesPath()
    {
        if (isDirectionForward)
        {
            while (currentIndex < transformValuesList.Count - 1)
            {
                if (currentIndex < transformValuesList.Count - 1) { currentIndex++; }
                yield return StartCoroutine(AnimateTransformValues(transformValuesList[currentIndex - 1], transformValuesList[currentIndex]));
            }
        }
        else
        {
            while (currentIndex > 0)
            {
                if (currentIndex > 0) { currentIndex--; }
                yield return StartCoroutine(AnimateTransformValues(transformValuesList[currentIndex + 1], transformValuesList[currentIndex]));
            }
        }

        if (loop) { PerformInteraction(); }
    }

    private IEnumerator AnimateTransformValues(TransformValues lastTransformValues, TransformValues endTransformValues)
    {
        float time = 0f;
        float distanceTraveled01 = Vector3.Distance(transform.localPosition, endTransformValues.position) /
            Vector3.Distance(lastTransformValues.position, endTransformValues.position);

        float currentSegementDuration = animationDurationPerSegment * distanceTraveled01;

        TransformValues startTransformValues = TransformValues.GetTransformValues(transform);

        while (time <= 1f)
        {
            time += Time.deltaTime / currentSegementDuration;
            transform.SetLocalPositionAndRotation(
                Vector3.Lerp(startTransformValues.position, endTransformValues.position, time), 
                Quaternion.Euler(Vector3.Lerp(startTransformValues.rotation, endTransformValues.rotation, time))
            );

            transform.localScale = Vector3.Lerp(startTransformValues.scale, endTransformValues.scale, time);

            yield return null;
        }
    }

    #region public setters for isDirectionFoward
    public void SetStateForwardInstant(bool value)
    {
        isDirectionForward = value;
        SetCorrectTransformInstant();
    }

    public void ToggleStateForwardInstant()
    {
        isDirectionForward = !isDirectionForward;
        SetCorrectTransformInstant();
    }

    public void SetStateForwardAnimated(bool value)
    {
        isDirectionForward = value;
        SetCorrectTransformAnimated();
    }

    public void ToggleStateForwardAnimated()
    {
        isDirectionForward = !isDirectionForward;
        SetCorrectTransformAnimated();
    }
    #endregion

    [Serializable]
    private struct TransformValues
    {
        public Vector3 position;
        public Vector3 rotation;
        public Vector3 scale;

        public TransformValues(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.scale = scale;
        }

        public static TransformValues GetTransformValues(Transform transform)
        {
            return new TransformValues(transform.localPosition, transform.localRotation.eulerAngles, transform.localScale);
        }
    }

    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < transformValuesList.Count; i++)
        {
            if (i == 0) { Gizmos.color = Color.green; }
            else if (i == transformValuesList.Count - 1) { Gizmos.color = Color.red; }
            else { Gizmos.color = Color.yellow; }

            Gizmos.DrawWireMesh(
                mesh,
                transform.parent != null ? transform.parent.TransformPoint(transformValuesList[i].position) : transformValuesList[i].position,
                Quaternion.Euler(transformValuesList[i].rotation),
                transformValuesList[i].scale
            );
        }
    }
}
