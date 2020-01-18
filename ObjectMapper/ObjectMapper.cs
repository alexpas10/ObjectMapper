using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace ObjectMapper
{
	public class ObjectMapper
	{
		public TDestination Map<TDestination>(object source)
		{
			var destinationType = typeof(TDestination);

			return (TDestination)Map(source, destinationType);
		}


		public object Map(object source, Type destinationType)
		{
			var sourceType = source.GetType();
			var result = Activator.CreateInstance(destinationType);

			var srcProperties = sourceType.GetProperties();
			var destProperties = destinationType.GetProperties();

			foreach (var srcProp in srcProperties)
			{
				foreach (var destProp in destProperties)
				{
					if (srcProp.Name.Equals(destProp.Name))
					{
						SetPropertyValue(srcProp, source, destProp, result);
					}
				}
			}

			return result;
		}



		private void SetPropertyValue(PropertyInfo source, object sourceObject, PropertyInfo destination, object destinationObject)
		{
			bool areCompatible = destination.PropertyType.IsAssignableFrom(source.PropertyType);
			if (areCompatible)
			{
				var value = source.GetValue(sourceObject);
				destination.SetValue(destinationObject, value);
			}
			else
			{
				if (destination.PropertyType == typeof(string)
					&& (source.PropertyType.IsPrimitive || source.PropertyType == typeof(DateTime)))
				{
					var value = source.GetValue(sourceObject).ToString();
					destination.SetValue(destinationObject, value);
				}
			}
		}
	}
}
