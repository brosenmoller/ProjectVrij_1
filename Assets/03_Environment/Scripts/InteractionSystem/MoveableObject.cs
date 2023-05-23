using System;
using System.Collections;
using UnityEngine;

public class MoveableObject : InteractableObject
{
    [Header("MoveableObject Settings")]
    [SerializeField] private bool startOpen = false;
    [SerializeField] private float animationDuration;
    [SerializeField] private TransformValues openTransformValues;
    [SerializeField] private TransformValues closedTransformValues;

    [Header("Editor Buttons")]
    [SerializeField] private bool autoChangeAssignIndex = true;
    [SerializeField] private int assignIndex = 0;

    private bool isOpen = false;

    private void Start()
    {
        isOpen = startOpen;
        SetCorrectTransformInstant();
    }

    protected override void PerformInteraction()
    {
        isOpen = !isOpen;
        SetCorrectTransformAnimated();
    }

    public void AssignOpenTranformValues()
    {
        openTransformValues = TransformValues.GetTransformValues(transform);
    }

    public void AssignClosedTranformValues()
    {
        closedTransformValues = TransformValues.GetTransformValues(transform);
    }

    private void SetCorrectTransformAnimated()
    {
        StopAllCoroutines();
        TransformValues currentTransformValues = TransformValues.GetTransformValues(transform);

        if (isOpen)
        {
            StartCoroutine(AnimateDoorTransform(currentTransformValues, openTransformValues));
        }
        else
        {
            StartCoroutine(AnimateDoorTransform(currentTransformValues, closedTransformValues));
        }
    }

    private void SetCorrectTransformInstant()
    {
        if (isOpen)
        {
            transform.SetLocalPositionAndRotation(openTransformValues.position, Quaternion.Euler(openTransformValues.rotation));
            transform.localScale = openTransformValues.scale;
        }
        else
        {
            transform.SetLocalPositionAndRotation(closedTransformValues.position, Quaternion.Euler(closedTransformValues.rotation));
            transform.localScale = closedTransformValues.scale;
        }
    }


    private IEnumerator AnimateDoorTransform(TransformValues startTransformValues, TransformValues endTransformValues)
    {
        float time = 0f;
        while (time <= 1f)
        {
            time += Time.deltaTime / animationDuration;
            transform.SetLocalPositionAndRotation(
                Vector3.Lerp(startTransformValues.position, endTransformValues.position, time), 
                Quaternion.Euler(Vector3.Lerp(startTransformValues.rotation, endTransformValues.rotation, time))
            );

            transform.localScale = Vector3.Lerp(startTransformValues.scale, endTransformValues.scale, time);

            yield return null;
        }
    }

    #region public setters for isOpen
    public void SetIsOpenInstant(bool value)
    {
        isOpen = value;
        SetCorrectTransformInstant();
    }

    public void ToggleStateInstant()
    {
        isOpen = !isOpen;
        SetCorrectTransformInstant();
    }

    public void SetIsOpenAnimated(bool value)
    {
        isOpen = value;
        SetCorrectTransformAnimated();
    }

    public void ToggleStateAnimated()
    {
        isOpen = !isOpen;
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
}
