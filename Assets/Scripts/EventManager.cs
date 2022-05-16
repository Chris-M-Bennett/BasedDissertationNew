using System.Collections.Generic;
using EventSystem;
using UnityEngine.Events;

public class IntUnityEvent : UnityEvent<int>{
}
public class EventManager : GenericSingleton<EventManager>
{
     private Dictionary<string, IntUnityEvent> _eventDictionary;
            public IntUnityEvent intEvent;
    
            public override void Awake(){
                base.Awake();
                if(Instance._eventDictionary == null){
                    Instance._eventDictionary = new Dictionary<string, IntUnityEvent>();
                }
                if(Instance.intEvent == null){
                    Instance.intEvent = new IntUnityEvent();
                }
            }
    
            public void StartListening(string eventName, UnityAction<int> listener){
                IntUnityEvent thisEvent;
                if (Instance._eventDictionary.TryGetValue(eventName, out thisEvent)){
                    //Event name is in dictionary
                    thisEvent.AddListener(listener);
                }else{
                    thisEvent = new IntUnityEvent();
                    thisEvent.AddListener(listener);
                    Instance._eventDictionary.Add(eventName, thisEvent);
                } 
            }
            public void StopListening(string eventName, UnityAction<int> listener){
                if (Instance._eventDictionary == null){
                    return;
                }
                IntUnityEvent thisEvent;
                if (Instance._eventDictionary.TryGetValue(eventName, out thisEvent)){
                    thisEvent.RemoveListener(listener);
                }
            }
            public void TriggerEvent(string eventName){
                IntUnityEvent thisEvent = null;
                if (Instance._eventDictionary.TryGetValue(eventName, out thisEvent)){
                    thisEvent.Invoke(0);
                } 
            }
}
