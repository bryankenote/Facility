using System.Collections.Generic;
using System.Globalization;
using ArgsReading;
using Facility.Definition;

namespace Facility.CodeGen.Console
{
	internal static class CommonArgs
	{
		public static string ReadServiceNameOption(this ArgsReader args)
		{
			string serviceName = args.ReadOption("serviceName");
			if (serviceName != null && ServiceDefinitionUtility.IsValidName(serviceName))
				throw new ArgsReaderException($"Invalid service name '{serviceName}'.");
			return serviceName;
		}

		public static bool ReadCleanFlag(this ArgsReader args) => args.ReadFlag("clean");

		public static bool ReadDryRunFlag(this ArgsReader args) => args.ReadFlag("dryrun");

		public static bool ReadHelpFlag(this ArgsReader args) => args.ReadFlag("help|h|?");

		public static bool ReadQuietFlag(this ArgsReader args) => args.ReadFlag("quiet");

		public static bool ReadVerifyFlag(this ArgsReader args) => args.ReadFlag("verify");

		public static string ReadIndentOption(this ArgsReader args)
		{
			string value = args.ReadOption("indent");
			if (value == null)
				return null;

			if (value == "tab")
				return "\t";

			if (int.TryParse(value, NumberStyles.None, CultureInfo.InvariantCulture, out int spaceCount) && spaceCount >= 1 && spaceCount <= 8)
				return new string(' ', spaceCount);

			throw new ArgsReaderException($"Invalid indent '{value}'. (Should be 'tab' or the number of spaces.)");
		}

		public static string ReadNewLineOption(this ArgsReader args)
		{
			string value = args.ReadOption("newline");
			if (value == null)
				return null;

			switch (value)
			{
			case "auto":
				return null;
			case "lf":
				return "\n";
			case "crlf":
				return "\r\n";
			default:
				throw new ArgsReaderException($"Invalid new line '{value}'. (Should be 'auto', 'lf', or 'crlf'.)");
			}
		}

		public static IReadOnlyList<string> ReadExcludeTagOptions(this ArgsReader args)
		{
			var values = new List<string>();
			while (true)
			{
				string value = args.ReadOption("excludeTag");
				if (value == null)
					break;
				values.Add(value);
			}

			return values;
		}
	}
}
