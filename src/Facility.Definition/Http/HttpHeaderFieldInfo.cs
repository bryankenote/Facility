namespace Facility.Definition.Http;

/// <summary>
/// Information about a field that corresponds to a request or response HTTP header.
/// </summary>
public sealed class HttpHeaderFieldInfo : HttpFieldInfo
{
	/// <summary>
	/// The name of the HTTP header.
	/// </summary>
	public string Name { get; }

	/// <summary>
	/// The children of the element, if any.
	/// </summary>
	public override IEnumerable<HttpElementInfo> GetChildren() => Enumerable.Empty<HttpElementInfo>();

	internal HttpHeaderFieldInfo(ServiceFieldInfo fieldInfo)
		: base(fieldInfo)
	{
		Name = fieldInfo.Name;

		foreach (var parameter in GetHttpParameters(fieldInfo))
		{
			switch (parameter.Name)
			{
				case "name":
					Name = parameter.Value;
					break;

				case "from":
					break;

				default:
					AddInvalidHttpParameterError(parameter);
					break;
			}
		}
	}
}
