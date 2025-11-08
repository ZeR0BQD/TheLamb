using System.Collections.Generic;
using System;
using UnityEngine;
namespace Behavior.Player
{
    public class BehaviorManager
    {
        private Dictionary<Type, IBehavior> _behaviorDic = new Dictionary<Type, IBehavior>();

        public BehaviorManager()
        {
            _behaviorDic.Add(typeof(BehaviorLibrary), new BehaviorLibrary());
        }

        public T Get<T>() where T : class, IBehavior
        {
            Type type = typeof(T);
            if (_behaviorDic.TryGetValue(type, out IBehavior behavior))
            {
                return (T)behavior;
            }
            throw new KeyNotFoundException($"BehaviorLibrary không chứa behavior: {type.Name}");
        }
    }
}