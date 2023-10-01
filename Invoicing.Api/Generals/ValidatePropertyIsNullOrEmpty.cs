using System.Reflection;

namespace Invoicing.Api.Generals
{
    public static class ValidatePropertyIsNullOrEmpty<T>
    {
        public static string ValidateProperty(T entidad, params string[] LPropertyNames)
        {
            Type type = entidad.GetType();
            PropertyInfo propertyInfo = null;
            object propertyValue = null;
            List<string> LPropertiesExist = new List<string>();

            foreach (string propertyName in LPropertyNames)
            {
                propertyInfo = type.GetProperty(propertyName);

                if (propertyInfo != null)
                {
                    propertyValue = propertyInfo.GetValue(entidad);

                    if (string.IsNullOrEmpty(propertyValue.ToString()) || string.Equals(propertyValue.ToString(), "0"))
                    {
                        LPropertiesExist.Add(propertyName);
                    }
                }
            }

            if (LPropertiesExist.Count > 0)
            {
                return $"Must send the {string.Join(", ", LPropertiesExist)}!";
            }
            else
            {
                return null;
            }
        }
    }
}
