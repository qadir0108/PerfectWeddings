using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web.Mvc;
using System.Web.WebPages;

namespace PerfectWeddings.Validation
{
    #region validation

    public class CustomCompareDatesAttribute : ValidationAttribute, IClientValidatable
    {
        #region Properties and Variables
        private CompareOperator operatorName = CompareOperator.GreaterThanOrEqual;

        public string CompareToPropertyName { get; set; }

        public CompareOperator OperatorName { 
            get { return operatorName; } 
            set { operatorName = value; }
        }

        public string HTMLCompareToPropertyName { get; set; }
        #endregion

        #region Server Side Validation
        /// <summary>
        /// This method validate the value of the model property on which this CustomCompareDates validator is applied.
        /// </summary>
        /// <param name="value">Value of the model property on which this CustomCompareDates validator is applied.</param>
        /// <param name="validationContext"></param>
        /// <returns>Returns the boolean value whether the value is valid or not.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string operstring = (OperatorName == CompareOperator.GreaterThan ?
            "greater than " : (OperatorName == CompareOperator.GreaterThanOrEqual ?
            "greater than or equal to " :
            (OperatorName == CompareOperator.LessThan ? "less than " :
            (OperatorName == CompareOperator.LessThanOrEqual ? "less than or equal to " : ""))));

            PropertyInfo basePropertyInfo = validationContext.ObjectType.GetProperty(CompareToPropertyName);

            IComparable otherValue = (IComparable)Convert.ToDateTime(basePropertyInfo.GetValue(validationContext.ObjectInstance, null));

            IComparable thisValue = (IComparable)Convert.ToDateTime(value);

            if (((operatorName == CompareOperator.GreaterThan && thisValue.CompareTo(otherValue) <= 0) ||
                (operatorName == CompareOperator.GreaterThanOrEqual && thisValue.CompareTo(otherValue) < 0) ||
                (operatorName == CompareOperator.LessThan && thisValue.CompareTo(otherValue) >= 0) ||
                (operatorName == CompareOperator.LessThanOrEqual && thisValue.CompareTo(otherValue) > 0)) &&
                (otherValue.CompareTo((IComparable)new DateTime(1, 1, 1)) != 0 && thisValue.CompareTo((IComparable)new DateTime(1, 1, 1)) != 0)
                )
            {
                return new ValidationResult(base.ErrorMessage);
            }
            return null;
        }
        #endregion

        #region Client Side Validation
        /// <summary>
        /// This method returns client validation rules for this custom validation (CustomCompareDates Validation).
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="context"></param>
        /// <returns>Validation rules</returns>
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            string errorMessage = this.FormatErrorMessage(metadata.DisplayName);
            ModelClientValidationRule compareRule = new ModelClientValidationRule();
            compareRule.ErrorMessage = errorMessage;
            compareRule.ValidationType = "customcomparedates";
            if (string.IsNullOrEmpty(HTMLCompareToPropertyName))
            {
                compareRule.ValidationParameters.Add("comparetopropertyname", CompareToPropertyName);
            }
            else
            {
                compareRule.ValidationParameters.Add("comparetopropertyname", HTMLCompareToPropertyName);
            }
            compareRule.ValidationParameters.Add("operatorname", Convert.ToString(OperatorName));
            yield return compareRule;
        }
        #endregion
    }

    public class CustomRangeDatesAttribute : ValidationAttribute, IClientValidatable
    {
        #region Properties and Variables      
        public string StartPropertyName { get; set; }
        public string HTMLStartPropertyName { get; set; }
        public string EndPropertyName { get; set; }
        public string HTMLEndPropertyName { get; set; }

        #endregion

        #region Server Side Validation
        /// <summary>
        /// This method validate the value of the model property on which this CustomCompareDates validator is applied.
        /// </summary>
        /// <param name="value">Value of the model property on which this CustomCompareDates validator is applied.</param>
        /// <param name="validationContext"></param>
        /// <returns>Returns the boolean value whether the value is valid or not.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {         
            PropertyInfo StartPropertyInfo = validationContext.ObjectType.GetProperty(StartPropertyName);

            PropertyInfo EndPropertyInfo = validationContext.ObjectType.GetProperty(EndPropertyName);

            IComparable StartValue = (IComparable)Convert.ToDateTime(StartPropertyInfo.GetValue(validationContext.ObjectInstance, null));

            IComparable EndValue = (IComparable)Convert.ToDateTime(EndPropertyInfo.GetValue(validationContext.ObjectInstance, null));

            IComparable thisValue = (IComparable)Convert.ToDateTime(value);

            if((StartValue.CompareTo((IComparable)new DateTime(1, 1, 1)) != 0 && thisValue.CompareTo(StartValue) < 0))
            {
                return new ValidationResult(base.ErrorMessage);
            }
            if((EndValue.CompareTo((IComparable)new DateTime(1, 1, 1)) != 0 && thisValue.CompareTo(EndValue) > 0))
            {
                return new ValidationResult(base.ErrorMessage);
            }
            return null;         
        }
        #endregion

        #region Client Side Validation
        /// <summary>
        /// This method returns client validation rules for this custom validation (CustomCompareDates Validation).
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="context"></param>
        /// <returns>Validation rules</returns>
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            string errorMessage = this.FormatErrorMessage(metadata.DisplayName);
            ModelClientValidationRule compareRule = new ModelClientValidationRule();
            compareRule.ErrorMessage = errorMessage;
            compareRule.ValidationType = "customrangedates";
            if (string.IsNullOrEmpty(HTMLStartPropertyName))
            {
                compareRule.ValidationParameters.Add("startpropertyname", StartPropertyName);
            }
            else
            {
                compareRule.ValidationParameters.Add("startpropertyname", HTMLStartPropertyName);
            }
            if (string.IsNullOrEmpty(HTMLEndPropertyName))
            {
                compareRule.ValidationParameters.Add("endpropertyname", EndPropertyName);
            }
            else
            {
                compareRule.ValidationParameters.Add("endpropertyname", HTMLEndPropertyName);
            }

            yield return compareRule;
        }
        #endregion
    }

    public class CustomCompareNumbersAttribute : ValidationAttribute, IClientValidatable
    {
        #region Properties and Variables
        private CompareOperator operatorName = CompareOperator.GreaterThanOrEqual;

        public string CompareToPropertyName { get; set; }

        public CompareOperator OperatorName
        {
            get { return operatorName; }
            set { operatorName = value; }
        }
        #endregion

        #region Server Side Validation
        /// <summary>
        /// This method validate the value of the model property on which this CustomCompareNumbersAttribute validator is applied.
        /// </summary>
        /// <param name="value">Value of the model property on which this CustomCompareNumbersAttribute validator is applied.</param>
        /// <param name="validationContext"></param>
        /// <returns>Returns the boolean value whether the value is valid or not.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string operstring = (OperatorName == CompareOperator.GreaterThan ?
            "greater than " : (OperatorName == CompareOperator.GreaterThanOrEqual ?
            "greater than or equal to " :
            (OperatorName == CompareOperator.LessThan ? "less than " :
            (OperatorName == CompareOperator.LessThanOrEqual ? "less than or equal to " : ""))));

            PropertyInfo basePropertyInfo = validationContext.ObjectType.GetProperty(CompareToPropertyName);

            IComparable otherValue = (IComparable)Convert.ToDecimal(basePropertyInfo.GetValue(validationContext.ObjectInstance, null));

            IComparable thisValue = (IComparable)Convert.ToDecimal(value);

            if ((operatorName == CompareOperator.GreaterThan && thisValue.CompareTo(otherValue) <= 0) ||
                (operatorName == CompareOperator.GreaterThanOrEqual && thisValue.CompareTo(otherValue) < 0) ||
                (operatorName == CompareOperator.LessThan && thisValue.CompareTo(otherValue) >= 0) ||
                (operatorName == CompareOperator.LessThanOrEqual && thisValue.CompareTo(otherValue) > 0))
            {
                return new ValidationResult(base.ErrorMessage);
            }
            return null;
        }
        #endregion

        #region Client Side Validation
        /// <summary>
        /// This method returns client validation rules for this custom validation (CustomCompareNumbersAttribute Validation).
        /// </summary>
        /// <param name="metadata"></param>
        /// <param name="context"></param>
        /// <returns>Validation rules</returns>
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            string errorMessage = this.FormatErrorMessage(metadata.DisplayName);
            ModelClientValidationRule compareRule = new ModelClientValidationRule();
            compareRule.ErrorMessage = errorMessage;
            compareRule.ValidationType = "customcomparenumbers";
            compareRule.ValidationParameters.Add("comparetopropertyname", CompareToPropertyName);
            compareRule.ValidationParameters.Add("operatorname", Convert.ToString(OperatorName));
            yield return compareRule;
        }
        #endregion
    }

    #endregion

    #region Operator Enum

    public enum CompareOperator
    {
        GreaterThan,
        GreaterThanOrEqual,
        LessThan,
        LessThanOrEqual
    }

    #endregion
}