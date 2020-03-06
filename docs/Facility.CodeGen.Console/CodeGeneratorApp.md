# CodeGeneratorApp class

Base class for code generator console applications.

```csharp
public abstract class CodeGeneratorApp
```

## Public Members

| name | description |
| --- | --- |
| [Run](CodeGeneratorApp/Run.md)(…) | Called to execute the code generator application. |

## Protected Members

| name | description |
| --- | --- |
| [CodeGeneratorApp](CodeGeneratorApp/CodeGeneratorApp.md)() | The default constructor. |
| abstract [Description](CodeGeneratorApp/Description.md) { get; } | The app description lines for help. |
| virtual [ExtraUsage](CodeGeneratorApp/ExtraUsage.md) { get; } | Any extra usage lines for help. |
| abstract [CreateGenerator](CodeGeneratorApp/CreateGenerator.md)() | Creates the code generator. |
| abstract [CreateSettings](CodeGeneratorApp/CreateSettings.md)(…) | Creates the file generator settings. |

## See Also

* namespace [Facility.CodeGen.Console](../Facility.CodeGen.Console.md)
* [CodeGeneratorApp.cs](https://github.com/FacilityApi/Facility/tree/master/src/Facility.CodeGen.Console/CodeGeneratorApp.cs)

<!-- DO NOT EDIT: generated by xmldocmd for Facility.CodeGen.Console.dll -->