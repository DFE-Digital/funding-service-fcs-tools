// Type: Microsoft.Crm.Tools.SolutionPackager.Parser
// Assembly: SolutionPackager, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: DDA02B1F-45B8-4C93-A828-BAEBBAD561CA
// Assembly location: C:\Development\Crm\2013\SDK\Bin\SolutionPackager.exe

namespace Microsoft.Crm.Tools.SolutionPackager
{
    using System;
    using System.Collections;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Text;

    public sealed class Parser
  {
    public const string NewLine = "\r\n";
    private const int SpaceBeforeParam = 2;
    private readonly ArrayList _arguments;
    private readonly Hashtable _argumentMap;
    private readonly Argument _defaultArgument;
    private readonly ErrorReporter _reporter;

    public bool HasDefaultArgument
    {
      get
      {
        return _defaultArgument != null;
      }
    }

    private Parser()
    {
    }

    public Parser(Type argumentSpecification, ErrorReporter reporter)
    {
      _reporter = reporter;
      _arguments = new ArrayList();
      _argumentMap = new Hashtable();
      foreach (var field in argumentSpecification.GetFields())
      {
        if (!field.IsStatic && !field.IsInitOnly && !field.IsLiteral)
        {
          var attribute = GetAttribute(field);
          if (attribute is DefaultArgumentAttribute)
            _defaultArgument = new Argument(attribute, field, reporter);
          else
            _arguments.Add(new Argument(attribute, field, reporter));
        }
      }
      foreach (Argument obj in _arguments)
      {
        _argumentMap[obj.LongName.ToLowerInvariant()] = obj;
        if (obj.ExplicitShortName)
        {
          if (obj.ShortName != null && obj.ShortName.Length > 0)
            _argumentMap[obj.ShortName.ToLowerInvariant()] = obj;
          else
            obj.ClearShortName();
        }
      }
      foreach (Argument obj in _arguments)
      {
        if (!obj.ExplicitShortName)
        {
          var str = obj.ShortName.ToLowerInvariant();
          if (obj.ShortName != null && obj.ShortName.Length > 0 && !_argumentMap.ContainsKey(str))
            _argumentMap[str] = obj;
          else
            obj.ClearShortName();
        }
      }
    }

    public static bool ParseArgumentsWithUsage(string[] arguments, object destination)
    {
      if (!ParseHelp(arguments) && ParseArguments(arguments, destination))
        return true;
      Console.WriteLine();
      Console.WriteLine("Options:");
      Console.WriteLine(ArgumentsUsage(destination.GetType()));
      return false;
    }

    public static bool ParseArguments(string[] arguments, object destination)
    {
      return ParseArguments(arguments, destination, Console.Error.WriteLine);
    }

    public static bool ParseArguments(string[] arguments, object destination, ErrorReporter reporter)
    {
      return new Parser(destination.GetType(), reporter).Parse(arguments, destination);
    }

    private static void NullErrorReporter(string message)
    {
    }

    public static bool ParseHelp(string[] args)
    {
      var parser = new Parser(typeof (HelpArgument), NullErrorReporter);
      var helpArgument = new HelpArgument();
      parser.Parse(args, helpArgument);
      return helpArgument.Help;
    }

    public static string ArgumentsUsage(Type argumentType)
    {
      var columns = Console.BufferWidth;
      if (columns == 0)
        columns = 80;
      return ArgumentsUsage(argumentType, columns);
    }

    public static string ArgumentsUsage(Type argumentType, int columns)
    {
      return new Parser(argumentType, null).GetUsageString(columns);
    }

    public static int IndexOf(StringBuilder text, char value, int startIndex)
    {
      for (var index = startIndex; index < text.Length; ++index)
      {
        if (text[index] == value)
          return index;
      }
      return -1;
    }

    public static int LastIndexOf(StringBuilder text, char value, int startIndex)
    {
      for (var index = Math.Min(startIndex, text.Length - 1); index >= 0; --index)
      {
        if (text[index] == value)
          return index;
      }
      return -1;
    }

    private static ArgumentAttribute GetAttribute(FieldInfo field)
    {
      var customAttributes = field.GetCustomAttributes(typeof (ArgumentAttribute), false);
      if (customAttributes.Length == 1)
        return (ArgumentAttribute) customAttributes[0];
        return null;
    }

    private void ReportUnrecognizedArgument(string argument)
    {
      _reporter(string.Format("Unrecognized command line argument '{0}'", argument));
    }

    private bool ParseArgumentList(string[] args, object destination)
    {
      var flag = false;
      if (args != null)
      {
        for (var index = 0; index < args.Length; ++index)
        {
          var str1 = args[index];
          if (str1.Length > 0)
          {
            switch (str1[0])
            {
              case '-':
              case '/':
                var num = str1.IndexOfAny(new char[3]
                {
                  ':',
                  '+',
                  '-'
                }, 1);
                var str2 = str1.Substring(1, num == -1 ? str1.Length - 1 : num - 1).ToLowerInvariant();
                var str3 = str2.Length + 1 != str1.Length ? (str1.Length <= 1 + str2.Length || (int) str1[1 + str2.Length] != 58 ? str1.Substring(str2.Length + 1) : str1.Substring(str2.Length + 2)) : null;
                var obj = (Argument) _argumentMap[str2];
                if (obj == null)
                {
                  ReportUnrecognizedArgument(str1);
                  flag = true;
                  continue;
                }
                    if (obj.RequiresValue && string.IsNullOrWhiteSpace(str3) && index + 1 < args.Length)
                    {
                        if (args[index + 1][0] != 45 && args[index + 1][0] != 47 && args[index + 1][0] != 64)
                        {
                            str3 = args[index + 1];
                            ++index;
                        }
                        else
                            flag = true;
                    }
                    else if (obj.IsImpliedDefaultValue && string.IsNullOrWhiteSpace(str3))
                        str3 = (string) obj.ImplicitDefaultValue;
                    flag = flag | !obj.SetValue(str3, destination);
                    continue;
                case '@':
                string[] arguments;
                flag = flag | LexFileArguments(str1.Substring(1), out arguments) | ParseArgumentList(arguments, destination);
                continue;
              default:
                if (_defaultArgument != null)
                {
                  flag = flag | !_defaultArgument.SetValue(str1, destination);
                  continue;
                }
                    ReportUnrecognizedArgument(str1);
                    flag = true;
                    continue;
            }
          }
        }
      }
      return flag;
    }

    public bool Parse(string[] args, object destination)
    {
      var flag = ParseArgumentList(args, destination);
      foreach (Argument obj in _arguments)
        flag = flag | obj.Finish(destination);
      if (_defaultArgument != null)
        flag = flag | _defaultArgument.Finish(destination);
      return !flag;
    }

    public string GetUsageString(int screenWidth)
    {
      var allHelpStrings = GetAllHelpStrings();
      var val1 = 0;
      foreach (var argumentHelpStrings in allHelpStrings)
        val1 = Math.Max(val1, argumentHelpStrings.Syntax.Length);
      var num1 = val1 + 2;
      screenWidth = Math.Max(screenWidth, 15);
      var num2 = screenWidth >= num1 + 10 ? num1 : 5;
      var builder = new StringBuilder();
      foreach (var argumentHelpStrings in allHelpStrings)
      {
        var length = argumentHelpStrings.Syntax.Length;
        builder.Append(argumentHelpStrings.Syntax);
        var currentColumn = length;
        if (length >= num2)
        {
          builder.Append("\n");
          currentColumn = 0;
        }
        var val2 = screenWidth - num2;
        var startIndex = 0;
label_14:
        while (startIndex < argumentHelpStrings.Help.Length)
        {
          builder.Append(' ', num2 - currentColumn);
          currentColumn = num2;
          var num3 = startIndex + val2;
          int num4;
          if (num3 >= argumentHelpStrings.Help.Length)
          {
            num4 = argumentHelpStrings.Help.Length;
          }
          else
          {
            num4 = argumentHelpStrings.Help.LastIndexOf(' ', num3 - 1, Math.Min(num3 - startIndex, val2));
            if (num4 <= startIndex)
              num4 = startIndex + val2;
          }
          builder.Append(argumentHelpStrings.Help, startIndex, num4 - startIndex);
          startIndex = num4;
          AddNewLine("\n", builder, ref currentColumn);
          while (true)
          {
            if (startIndex < argumentHelpStrings.Help.Length && argumentHelpStrings.Help[startIndex] == 32)
              ++startIndex;
            else
              goto label_14;
          }
        }
        if (argumentHelpStrings.Help.Length == 0)
          builder.Append("\n");
      }
      return builder.ToString();
    }

    private static void AddNewLine(string newLine, StringBuilder builder, ref int currentColumn)
    {
      builder.Append(newLine);
      currentColumn = 0;
    }

    private ArgumentHelpStrings[] GetAllHelpStrings()
    {
      var argumentHelpStringsArray1 = new ArgumentHelpStrings[NumberOfParametersToDisplay()];
      var index1 = 0;
      foreach (Argument obj in _arguments)
      {
        argumentHelpStringsArray1[index1] = GetHelpStrings(obj);
        ++index1;
      }
      var argumentHelpStringsArray2 = argumentHelpStringsArray1;
      var index2 = index1;
      var num1 = 1;
      var num2 = index2 + num1;
      argumentHelpStringsArray2[index2] = new ArgumentHelpStrings("@<file>", "Read response file for more options");
      if (_defaultArgument != null)
      {
        var argumentHelpStringsArray3 = argumentHelpStringsArray1;
        var index3 = num2;
        var num3 = 1;
        var num4 = index3 + num3;
        argumentHelpStringsArray3[index3] = GetHelpStrings(_defaultArgument);
      }
      return argumentHelpStringsArray1;
    }

    private static ArgumentHelpStrings GetHelpStrings(Argument arg)
    {
        if (arg.IsHidden)
        return new ArgumentHelpStrings(string.Empty, string.Empty);
        return new ArgumentHelpStrings(arg.SyntaxHelp, arg.FullHelpText);
    }

      private int NumberOfParametersToDisplay()
    {
      var num = _arguments.Count + 1;
      if (HasDefaultArgument)
        ++num;
      return num;
    }

    private bool LexFileArguments(string fileName, out string[] arguments)
    {
      string str = null;
      try
      {
        using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
          str = new StreamReader(fileStream).ReadToEnd();
      }
      catch (Exception ex)
      {
        _reporter(string.Format("Error: Can't open command line argument file '{0}' : '{1}'", fileName, ex.Message));
        arguments = null;
        return false;
      }
      var flag1 = false;
      var arrayList = new ArrayList();
      var stringBuilder = new StringBuilder();
      var flag2 = false;
      var index = 0;
      while (true)
      {
        while (index >= str.Length || !char.IsWhiteSpace(str[index]))
        {
          if (index < str.Length)
          {
            if (str[index] == 35)
            {
              ++index;
              while (str[index] != 10)
                ++index;
            }
            else
            {
              do
              {
                if (str[index] == 92)
                {
                  var repeatCount = 1;
                  ++index;
                  while (index == str.Length && str[index] == 92)
                    ++repeatCount;
                  if (index == str.Length || str[index] != 34)
                  {
                    stringBuilder.Append('\\', repeatCount);
                  }
                  else
                  {
                    stringBuilder.Append('\\', repeatCount >> 1);
                    if ((repeatCount & 1) != 0)
                      stringBuilder.Append('"');
                    else
                      flag2 = !flag2;
                  }
                }
                else if (str[index] == 34)
                {
                  flag2 = !flag2;
                  ++index;
                }
                else
                {
                  stringBuilder.Append(str[index]);
                  ++index;
                }
              }
              while (index < str.Length && !char.IsWhiteSpace(str[index]) || flag2);
              arrayList.Add(stringBuilder.ToString());
              stringBuilder.Length = 0;
            }
          }
          else
          {
            if (flag2)
            {
              _reporter(string.Format("Error: Unbalanced '\"' in command line argument file '{0}'", fileName));
              flag1 = true;
            }
            else if (stringBuilder.Length > 0)
              arrayList.Add(stringBuilder.ToString());
            arguments = (string[]) arrayList.ToArray(typeof (string));
            return flag1;
          }
        }
        ++index;
      }
    }

    private static string LongName(ArgumentAttribute attribute, FieldInfo field)
    {
        if (attribute != null && !attribute.DefaultLongName)
        return attribute.LongName;
        return field.Name;
    }

      private static string ShortName(ArgumentAttribute attribute, FieldInfo field)
    {
      if (attribute is DefaultArgumentAttribute)
        return null;
      if (!ExplicitShortName(attribute))
        return LongName(attribute, field).Substring(0, 1);
          return attribute.ShortName;
    }

    private static string HelpText(ArgumentAttribute attribute, FieldInfo field)
    {
        if (attribute == null)
        return null;
        return attribute.HelpText;
    }

      private static bool HasHelpText(ArgumentAttribute attribute)
      {
          if (attribute != null)
        return attribute.HasHelpText;
          return false;
      }

      private static bool ExplicitShortName(ArgumentAttribute attribute)
      {
          if (attribute != null)
        return !attribute.DefaultShortName;
          return false;
      }

      private static object DefaultValue(ArgumentAttribute attribute, FieldInfo field)
      {
          if (attribute != null && attribute.HasDefaultValue)
        return attribute.DefaultValue;
          return null;
      }

      private static Type ElementType(FieldInfo field)
      {
          if (IsCollectionType(field.FieldType))
        return field.FieldType.GetElementType();
          return null;
      }

      private static ArgumentType Flags(ArgumentAttribute attribute, FieldInfo field)
    {
      if (attribute != null)
        return attribute.Type;
      return IsCollectionType(field.FieldType) ? ArgumentType.MultipleUnique : ArgumentType.AtMostOnce;
    }

    private static bool IsCollectionType(Type type)
    {
      return type.IsArray;
    }

    private static bool IsValidElementType(Type type)
    {
      if (!(type != null))
        return false;
      if (!(type == typeof (int)) && !(type == typeof (uint)) && (!(type == typeof (string)) && !(type == typeof (bool))))
        return type.IsEnum;
        return true;
    }

    private class HelpArgument
    {
        [Argument(ArgumentType.AtMostOnce, ShortName = "?")] 
        public bool Help = false;
    }

    private struct ArgumentHelpStrings
    {
      public readonly string Syntax;
      public readonly string Help;

      public ArgumentHelpStrings(string syntax, string help)
      {
        Syntax = string.Format(CultureInfo.InvariantCulture, "  {0}", syntax);
        Help = help;
      }
    }

    private class Argument
    {
      private readonly string _longName;
        private readonly string _helpText;
      private readonly bool _hasHelpText;
      private readonly bool _explicitShortName;
      private readonly object _defaultValue;
        private readonly FieldInfo _field;
      private readonly Type _elementType;
      private readonly ArgumentType _flags;
      private readonly ArrayList _collectionValues;
      private readonly ErrorReporter _reporter;
      private readonly bool _isDefault;

      public Type ValueType
      {
        get
        {
            if (!IsCollection)
            return Type;
            return _elementType;
        }
      }

      public string LongName
      {
        get
        {
          return _longName;
        }
      }

      public bool ExplicitShortName
      {
        get
        {
          return _explicitShortName;
        }
      }

      public string ShortName { get; private set; }

        public bool HasShortName
      {
        get
        {
          return ShortName != null;
        }
      }

      public bool HasHelpText
      {
        get
        {
          return _hasHelpText;
        }
      }

      public string HelpText
      {
        get
        {
          return _helpText;
        }
      }

      public object DefaultValue
      {
        get
        {
          return _defaultValue;
        }
      }

      public object ImplicitDefaultValue { get; set; }

      public bool HasDefaultValue
      {
        get
        {
            if (_defaultValue != null)
            return !IsBasic;
            return false;
        }
      }

      public string FullHelpText
      {
        get
        {
          var builder = new StringBuilder();
          if (HasHelpText)
            builder.Append(HelpText);
          if (HasDefaultValue)
          {
            if (builder.Length > 0)
              builder.Append(" ");
            builder.Append("Default value:'");
            AppendValue(builder, DefaultValue);
            builder.Append('\'');
          }
          if (HasShortName)
          {
            if (builder.Length > 0)
              builder.Append(" ");
            builder.Append("(short form /");
            builder.Append(ShortName);
            builder.Append(")");
          }
          return builder.ToString();
        }
      }

      public string SyntaxHelp
      {
        get
        {
          var stringBuilder = new StringBuilder();
          if (IsDefault)
          {
            stringBuilder.Append("<");
            stringBuilder.Append(LongName);
            stringBuilder.Append(">");
          }
          else
          {
            stringBuilder.Append("/");
            stringBuilder.Append(LongName);
            var valueType = ValueType;
            if (valueType == typeof (int))
              stringBuilder.Append(":<int>");
            else if (valueType == typeof (uint))
              stringBuilder.Append(":<uint>");
            else if (!IsBasic)
            {
              if (valueType == typeof (bool))
                stringBuilder.Append("[+|-]");
              else if (valueType == typeof (string))
              {
                stringBuilder.Append(":<string>");
              }
              else
              {
                stringBuilder.Append(":{");
                var flag = true;
                foreach (var fieldInfo in valueType.GetFields())
                {
                  if (fieldInfo.IsStatic && !fieldInfo.Name.EndsWith("__", StringComparison.OrdinalIgnoreCase))
                  {
                    if (flag)
                      flag = false;
                    else
                      stringBuilder.Append('|');
                    stringBuilder.Append(fieldInfo.Name);
                  }
                }
                stringBuilder.Append('}');
              }
            }
          }
          return stringBuilder.ToString();
        }
      }

      public bool IsRequired
      {
        get
        {
          return ArgumentType.AtMostOnce != (_flags & ArgumentType.Required);
        }
      }

      public bool SeenValue { get; private set; }

        public bool AllowMultiple
      {
        get
        {
          return ArgumentType.AtMostOnce != (_flags & ArgumentType.Multiple);
        }
      }

      public bool Unique
      {
        get
        {
          return ArgumentType.AtMostOnce != (_flags & ArgumentType.Unique);
        }
      }

      public Type Type
      {
        get
        {
          return _field.FieldType;
        }
      }

      public bool IsCollection
      {
        get
        {
          return IsCollectionType(Type);
        }
      }

      public bool IsDefault
      {
        get
        {
          return _isDefault;
        }
      }

      public bool RequiresValue
      {
        get
        {
          return ArgumentType.AtMostOnce != (_flags & ArgumentType.RequiresValue);
        }
      }

      public bool IsHidden
      {
        get
        {
          return ArgumentType.AtMostOnce != (_flags & ArgumentType.Hidden);
        }
      }

      public bool IsBasic
      {
        get
        {
          return ArgumentType.AtMostOnce != (_flags & ArgumentType.Basic);
        }
      }

      public bool IsImpliedDefaultValue
      {
        get
        {
          return ArgumentType.AtMostOnce != (_flags & ArgumentType.ImpliedDefaultValue);
        }
      }

      public Argument(ArgumentAttribute attribute, FieldInfo field, ErrorReporter reporter)
      {
        _longName = LongName(attribute, field);
        _explicitShortName = ExplicitShortName(attribute);
        ShortName = Parser.ShortName(attribute, field);
        _hasHelpText = HasHelpText(attribute);
        _helpText = HelpText(attribute, field);
        _defaultValue = DefaultValue(attribute, field);
        _elementType = ElementType(field);
        _flags = Flags(attribute, field);
        _field = field;
        SeenValue = false;
        _reporter = reporter;
        _isDefault = attribute != null && attribute is DefaultArgumentAttribute;
        ImplicitDefaultValue = attribute.ImplicitDefaultValue;
        if (!IsCollection)
          return;
        _collectionValues = new ArrayList();
      }

      public bool Finish(object destination)
      {
        if (!SeenValue && HasDefaultValue)
          _field.SetValue(destination, DefaultValue);
        if (IsCollection)
          _field.SetValue(destination, _collectionValues.ToArray(_elementType));
        return ReportMissingRequirements();
      }

      private bool ReportMissingRequirements()
      {
        if (!IsRequired || SeenValue)
          return false;
        if (IsDefault)
          _reporter(string.Format("Missing required argument '<{0}>'.", LongName));
        else
          _reporter(string.Format("Missing required argument '/{0}'.", LongName));
        return true;
      }

      private void ReportDuplicateArgumentValue(string value)
      {
        _reporter(string.Format("Duplicate '{0}' argument '{1}'", LongName, value));
      }

      public bool SetValue(string value, object destination)
      {
        if (SeenValue && !AllowMultiple)
        {
          _reporter(string.Format("Duplicate '{0}' argument", LongName));
          return false;
        }
          SeenValue = true;
          object obj;
          if (!ParseValue(ValueType, value, out obj))
              return false;
          if (IsCollection)
          {
              if (Unique && _collectionValues.Contains(obj))
              {
                  ReportDuplicateArgumentValue(value);
                  return false;
              }
              _collectionValues.Add(obj);
          }
          else
              _field.SetValue(destination, obj);
          return true;
      }

      private void ReportBadArgumentValue(string value)
      {
        _reporter(string.Format("'{0}' is not a valid value for the '{1}' command line option", value, LongName));
      }

      private bool ParseValue(Type type, string stringData, out object value)
      {
        if (stringData != null || type == typeof (bool))
        {
          if (stringData != null)
          {
            if (stringData.Length <= 0)
              goto label_16;
          }
          try
          {
              if (type == typeof (string))
            {
              value = stringData;
              return true;
            }
              if (type == typeof (bool))
              {
                  if (stringData == null || stringData == "+")
                  {
                      value = true;
                      return true;
                  }
                  if (stringData == "-")
                  {
                      value = false;
                      return true;
                  }
              }
              else if (type == typeof (int))
              {
                  value = int.Parse(stringData);
                  return true;
              }
              else if (type == typeof (uint))
              {
                  value = int.Parse(stringData);
                  return true;
              }
              else
              {
                  value = Enum.Parse(type, stringData, true);
                  return true;
              }
          }
          catch
          {
          }
        }
label_16:
        ReportBadArgumentValue(stringData);
        value = null;
        return false;
      }

      private void AppendValue(StringBuilder builder, object value)
      {
        if (value is string || value is int || (value is uint || value.GetType().IsEnum))
          builder.Append(value);
        else if (value is bool)
        {
          builder.Append((bool) value ? "+" : "-");
        }
        else
        {
          var flag = true;
          foreach (var obj in (Array) value)
          {
            if (!flag)
              builder.Append(", ");
            AppendValue(builder, obj);
            flag = false;
          }
        }
      }

      public void ClearShortName()
      {
        ShortName = null;
      }
    }
  }
}
