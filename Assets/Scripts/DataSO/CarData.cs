using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "Car Properties", menuName = "Car Properties/Create new properties")]
public class CarData : ScriptableObject
{
   [SerializeField] private Sprite _icon;
   [SerializeField] private string _model;
   [SerializeField] private string _mass;
   [SerializeField] private string _power;

   [Header("Unic Property")]
   [SerializeField] private AdditionalProperty.additional uniqProperty;
   [SerializeField] private string uniqPropertyValue;

   [SerializeField] private int _id;

   private string _modelLabel = "Model: ";
   private string _massLabel = "Mass: ";
   private string _powerLabel = "Power: ";
   
   public Sprite Icon => _icon;

   public string Model
   {
      get => _model;
      set => _model = value; 
   }

   public string ModelLabel => _modelLabel;

   public string Mass
   {
      get => _mass;
      set => _mass = value;
   }
   
   public string MassLabel => _massLabel;

   public string Power
   {
      get => _power;
      set => _power = value;
   }
   
   public string PowerLabel => _powerLabel;

   public int ID
   {
      get => _id;
      set => _id = value; 
   }

   public AdditionalProperty.additional UniqProperty => uniqProperty;

   public string UniqPropertyValue
   {
      get => uniqPropertyValue;
      set => uniqPropertyValue = value;
   }
   
   public void Save()
   {
      #if UNITY_EDITOR
      EditorUtility.SetDirty(this);
      #endif
   }
}
