using System.Text;
using Microsoft.CodeAnalysis;

namespace TestCodeGen
{
    [Generator]
    public class TestGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
        }

        public void Execute(GeneratorExecutionContext context)
        {
            var builder = new StringBuilder();
            builder.AppendLine("using TestNamesapce;");
            builder.AppendLine("public static class TestGenClass {");

            builder.AppendLine("    public static string GeneratedTestMethod(){return new TestClass().GetData(); }");
            
            builder.AppendLine("}");
            context.AddSource("gen.TestFile.cs", builder.ToString());
        }
    }
}