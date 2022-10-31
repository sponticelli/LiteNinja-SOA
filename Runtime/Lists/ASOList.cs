using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LiteNinja.SOA.Variables;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace LiteNinja.SOA.Lists
{
  public abstract class ASOList<T> : ScriptableListBase, IEnumerable<T>, IDrawObjectsInInspector
  {
    [Tooltip(
      "Clear the list when:" +
      " Scene Loaded : when a scene is loaded." +
      " Application Start : Once, when the application starts. Modifications persists between scenes")]
    [SerializeField]
    private ResetType _resetOn = ResetType.SceneLoaded;

    [SerializeField] protected List<T> _list = new();
    public int Count => _list.Count;

    public event Action<T> OnItemCountChanged;
    public event Action<T> OnItemAdded;
    public event Action<T> OnItemRemoved;
    public event Action OnCleared;

    public T this[int index]
    {
      get => _list[index];
      set => _list[index] = value;
    }

    public void Add(T item)
    {
      if (_list.Contains(item)) return;
      _list.Add(item);
      OnItemCountChanged?.Invoke(item);
      OnItemAdded?.Invoke(item);
    }

    public void Remove(T item)
    {
      if (!_list.Contains(item)) return;
      _list.Remove(item);
      OnItemCountChanged?.Invoke(item);
      OnItemRemoved?.Invoke(item);
    }

    private void Clear()
    {
      _list.Clear();
      OnCleared?.Invoke();
    }

    private void Awake()
    {
      //Prevents from resetting if no reference in a scene
      hideFlags = HideFlags.DontUnloadUnusedAsset;
    }

    private void OnEnable()
    {
      Clear();
      if (_resetOn == ResetType.SceneLoaded) SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
      if (_resetOn == ResetType.SceneLoaded) SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
      if (mode == LoadSceneMode.Single)  Clear();
    }
        
    public void Reset()
    {
      Clear();
    }

    public IEnumerator<T> GetEnumerator()
    {
      return _list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public List<Object> GetAllObjects()
    {
      var list = new List<Object>(Count);
      list.AddRange(_list.OfType<Object>());
      return list;
    }
  }
}