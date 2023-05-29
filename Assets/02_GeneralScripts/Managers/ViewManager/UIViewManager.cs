using System;
using System.Collections.Generic;
using UnityEngine;

public class UIViewManager : Manager
{
    private UIView[] views;
    private readonly Dictionary<Type, UIView> viewsDictionary = new();

    private UIView currentView;
    private readonly Stack<UIView> history = new();

    public override void Setup()
    {
        SetupViewDictionary();
    }

    private void SetupViewDictionary()
    {
        views = UnityEngine.Object.FindObjectsOfType<UIView>();
        viewsDictionary.Clear();

        bool defaultViewFound = false;

        foreach (UIView view in views)
        {
            view.Initialize();
            view.Hide();

            viewsDictionary.Add(view.GetType(), view);

            if (!view.defaultView) { continue; }

            if (defaultViewFound)
            {
                Debug.LogWarning("UIViewManager: Multiple default views found in current scene");
            }
            else
            {
                defaultViewFound = true;
                Show(view.GetType());
            }
        }

        if (!defaultViewFound)
        {
            Debug.LogWarning("UIViewManager: No default views found in current scene");
        }
    }

    public UIView GetView(Type viewType)
    {
        if (!viewsDictionary.ContainsKey(viewType)) { return null; }
        
        return viewsDictionary[viewType];
    }

    public void Show(Type viewType, bool remember = true)
    {
        if (!viewsDictionary.ContainsKey(viewType)) { return; }

        if (currentView != null)
        {
            if (remember) { history.Push(currentView); }

            currentView.Hide();
        }

        currentView = viewsDictionary[viewType];
        currentView.Show();
    }

    public void ShowLast()
    {
        if (history.Count != 0)
        {
            Show(history.Pop().GetType(), false);
        }
    }
}