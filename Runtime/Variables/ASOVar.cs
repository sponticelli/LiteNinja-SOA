using System;
using System.Collections.Generic;
using System.Text;
using LiteNinja.SOA.Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace LiteNinja.SOA.Variables
{
    [Serializable]
    public abstract class ASOVar<T> : ScriptableVariableBase, IDrawObjectsInInspector
    {
   
        [Tooltip("If TRUE the value assumes the default value when the game starts and it can't be changed")]         
        [SerializeField] protected bool _isConstant;
        
        [Tooltip("The value of the variable, this is changed at runtime.")] 
        [SerializeField] protected T initialValue;
        
        [Tooltip("The initial value of this variable. When reset is called, it is set to this value")]
        [SerializeField] protected T runtimeValue;
        
        [Tooltip("Log in the console whenever this variable is changed, loaded or saved.")] 
        [SerializeField]
        private bool _debugLogEnabled;

        [Tooltip("If true, saves the value to Player Prefs and loads it onEnable.")]
        [SerializeField]
        private bool _saveOnPlayerPrefs;
        
        [SerializeField] private ASOEvent<T> onValueChanged;
        
        [Tooltip("Reset to initial value." +
                 " Scene Loaded : when the scene is loaded." +
                 " Application Start : Once, when the application starts.")]
        [SerializeField]
        private ResetType _resetOn = ResetType.SceneLoaded;

        private List<Object> _listenersObjects = new();
        private Action<T> _onValueChanged;


#region Unity Lifetime
        private void Awake()
        {
            //Prevents from resetting if no reference in a scene
            hideFlags = HideFlags.DontUnloadUnusedAsset;
        }
        
        private void OnEnable()
        {
            if (_resetOn == ResetType.SceneLoaded)
                SceneManager.sceneLoaded += OnSceneLoaded;

            Reset();
        }

        private void OnDisable()
        {
            if (_resetOn == ResetType.SceneLoaded)
                SceneManager.sceneLoaded -= OnSceneLoaded;
        }
#endregion
        
        public void SetRuntimeValue(T newValue)
        {
            Value = newValue;
        }
        
        public T InitialValue => initialValue;

        public T Value
        {
            get => runtimeValue;
            set
            {
                if (_isConstant)
                {
                    Debug.LogWarning("Trying to set value of constant variable");
                    return;
                }
                if (Equals(runtimeValue, value))
                    return;
                runtimeValue = value;
                ValueChanged();
                
            }
        }
        
        public T PreviousValue { get; private set; }
        
        /// <summary>
        /// Register to this action to be notified when the variable changes value.
        /// </summary>
        public event Action<T> OnValueChanged
        {
            add
            {
                _onValueChanged += value;

                var listener = value.Target as Object;
                if (!_listenersObjects.Contains(listener))
                    _listenersObjects.Add(listener);
            }
            remove
            {
                _onValueChanged -= value;

                var listener = value.Target as Object;
                if (_listenersObjects.Contains(listener))
                    _listenersObjects.Remove(listener);
            }
        }

        public bool IsConstant => _isConstant;

        private void ValueChanged()
        {
            onValueChanged?.Raise(runtimeValue);
            _onValueChanged?.Invoke(runtimeValue);
            
            if (_debugLogEnabled)
                Debug.Log(ToColoredString());

            if (_saveOnPlayerPrefs)
                Save();

            PreviousValue = runtimeValue;
        }
        
        public virtual void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (mode == LoadSceneMode.Single)
                Reset();
        }
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            
            if (Equals(runtimeValue, PreviousValue))
                return;
            ValueChanged();
        }
#endif
        
        public void Reset()
        {
            _listenersObjects.Clear();
            
            if (_saveOnPlayerPrefs)
                Load();
            else
            {
                Value = initialValue;
                PreviousValue = initialValue;
            }
        }
        
        public virtual void Save()
        {
            if (_debugLogEnabled)
                Debug.Log(ToColoredString() + " <color=#52D5F2>[Saved]</color>");
        }
        
        public virtual void Load()
        {
            PreviousValue = runtimeValue;

            if (_debugLogEnabled)
                Debug.Log(ToColoredString() + " <color=#52D5F2>[Loaded]</color>");
        }
        
        public override string ToString()
        {
            var sb = new StringBuilder(name);
            sb.Append(" : ");
            sb.Append(runtimeValue);
            return sb.ToString();
        }

        private string ToColoredString()
        {
            return $"<color=#52D5F2>[Variable]</color> {ToString()}";
        }
        
        public List<Object> GetAllObjects()
        {
            return _listenersObjects;
        }
    }
}