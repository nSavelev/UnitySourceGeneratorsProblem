# Unity Source generation problemd demo project

A basic Unity project in structure with setted up SourceGeneration Library
Generation source and test located in **CodeGenCsProject** folder

## Problem
Unity does not compile generated file if there are using some namespaces from other source files in Assembly-CShapr
**No Rider errors**
**No dotnet build errors**

If I copy generated code to other project it works as planed.

You can check CodeGenCsProject/CodeGenCsProject.sln to see generator and it's pure .Net test sources


## Sources



````
// Test Class source
namespace TestNamesapce
{
    public class TestClass
    {
        public string GetData()
        {
            return "It works!";
        }
    }
}


// ====================================

// Generator source
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
