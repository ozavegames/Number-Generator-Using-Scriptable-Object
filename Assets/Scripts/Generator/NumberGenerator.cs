using com.ozave.numbergenerator.enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.ozave.numbergenerator.generator
{
    [CreateAssetMenu(fileName = "Number Generator", menuName = "Create Number Generator")]
    public class NumberGenerator : ScriptableObject
    {
        #region Properties

        private float number;
        public float number1 { get; set; }
        public float number2 { get; set; }
        private NumberOptions selected = NumberOptions.CONSTANT;

        public float Number
        {
            get
            {
                return number;
            }
            set
            {
                SetNumber(value);
            }
        }

        public NumberOptions Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
            }
        }

        #endregion

        #region Mutators

        private void SetNumber(float value)
        {
            number = value;
        } 

        #endregion
    } 
}
