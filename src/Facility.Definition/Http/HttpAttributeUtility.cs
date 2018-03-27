using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace Facility.Definition.Http
{
	internal static class HttpAttributeUtility
	{
		public static ServiceAttributeInfo TryGetHttpAttribute(this IServiceElementInfo element) => element.TryGetAttribute("http");

		public static IReadOnlyList<ServiceAttributeParameterInfo> GetHttpParameters(this IServiceElementInfo element)
			=> element.TryGetAttribute("http")?.Parameters ?? new ServiceAttributeParameterInfo[0];

		public static ServiceDefinitionError CreateInvalidHttpParameterError(this ServiceAttributeParameterInfo parameter)
			=> new ServiceDefinitionError($"Unexpected 'http' parameter '{parameter.Name}'.", parameter.Position);

		public static HttpStatusCode? TryParseStatusCodeInteger(ServiceAttributeParameterInfo parameter, out ServiceDefinitionError error)
		{
			int.TryParse(parameter.Value, NumberStyles.Integer, CultureInfo.InvariantCulture, out var valueAsInteger);
			if (valueAsInteger < 200 || valueAsInteger >= 599)
			{
				error = new ServiceDefinitionError($"'{parameter.Name}' parameter must be an integer between 200 and 599.", parameter.ValuePosition);
				return null;
			}

			error = null;
			return (HttpStatusCode) valueAsInteger;
		}
	}
}
