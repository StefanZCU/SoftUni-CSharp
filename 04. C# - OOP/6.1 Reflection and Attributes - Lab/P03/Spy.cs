namespace Stealer
{
    using System.Text;
    using System.Reflection;

    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            var classType = Type.GetType(className);

            var fields = classType
                .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(x => fieldNames.Contains(x.Name));

            var classInstance = Activator.CreateInstance(classType);

            var sb = new StringBuilder();

            sb.AppendLine($"Class under investigation: {className}");

            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            var classType = Type.GetType(className);

            FieldInfo[] nonPublicFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            var nonPublicGetters = classType
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(x => x.Name.StartsWith("get"));

            var publicSetters = classType
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => x.Name.StartsWith("set"));

            var sb = new StringBuilder();

            foreach (var field in nonPublicFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var getter in nonPublicGetters)
            {
                sb.AppendLine($"{getter.Name} have to be public!");
            }

            foreach (var setter in publicSetters)
            {
                sb.AppendLine($"{setter.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            var sb = new StringBuilder();

            Type classType = Type.GetType(className);
            var classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            sb
                .AppendLine($"All Private Methods of Class: {className}")
                .AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var classMethod in classMethods)
            {
                sb.AppendLine(classMethod.Name);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
