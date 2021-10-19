using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.SolutionAndProjects
{
    [TestClass]
    public class DebbugerHiddenTest : SolutionTestBase
    {
        [TestMethod]
        public void All_Methods_Must_Be_Decorated_With_The_DebuggerHidden_Attribute()
        {
            var missingHiddenAttribute = from cSharpFileInfo in CSharpFileInfos
                                         from @class in cSharpFileInfo.SyntaxTree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>()
                                         from method in @class.DescendantNodes().OfType<MethodDeclarationSyntax>()
                                         let attributeListSyntaxes = method.AttributeLists
                                         where !attributeListSyntaxes.Any() || !attributeListSyntaxes.Any(a => a.Attributes.Any(a => a.Name.ToString().Contains("DebuggerHidden")))
                                         select new AnalyzeResult(cSharpFileInfo.FileInfo, method.Identifier.ToString());

            Assert.IsFalse(missingHiddenAttribute.Any(), ToMessage(missingHiddenAttribute));
        }

        private string ToMessage(IEnumerable<AnalyzeResult> analyzeResults)
        {
            var groups = analyzeResults.GroupBy(result => result.CSharpFileInfo.FullName);
            var stringBuilder = new StringBuilder();

            _ = stringBuilder.AppendLine($"Missing {nameof(DebuggerHiddenAttribute)} detected:");
            _ = stringBuilder.AppendLine();
            foreach (var group in groups)
            {
                _ = stringBuilder.AppendLine(group.Key);
                foreach (var analyzeResult in group)
                {
                    _ = stringBuilder.AppendLine($"- {analyzeResult.MethodName}");
                }

                _ = stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }

    [TestClass]
    public class AllLegacyMethodsMustHaveObsoleteAttribute : SolutionTestBase
    {
        [TestMethod]
        public void All_Legacy_Argument_Check_Methods_Should_Be_Declarated_With_Obsolete_Attribute()
        {
            var missingHiddenAttribute = from cSharpFileInfo in ThrowHelperCSharpFileInfos
                                         from @class in cSharpFileInfo.SyntaxTree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>()
                                         from method in @class.DescendantNodes().OfType<MethodDeclarationSyntax>()
                                         where method.ParameterList.Parameters.Any() && method.ParameterList.Parameters.FirstOrDefault().Identifier.ValueText.Contains("Func")
                                         let attributeListSyntaxes = method.AttributeLists
                                         where !attributeListSyntaxes.Any() || !attributeListSyntaxes.Any(a => a.Attributes.Any(a => a.Name.ToString().Contains("Obsolete")))
                                         select new AnalyzeResult(cSharpFileInfo.FileInfo, $"{method.Identifier} - {method.ParameterList.ToFullString()}");


            Assert.IsFalse(missingHiddenAttribute.Any(), ToMessage(missingHiddenAttribute));
        }

        private string ToMessage(IEnumerable<AnalyzeResult> analyzeResults)
        {
            var groups = analyzeResults.GroupBy(result => result.CSharpFileInfo.FullName);
            var stringBuilder = new StringBuilder();

            _ = stringBuilder.AppendLine($"Missing {nameof(ObsoleteAttribute)} detected:");
            _ = stringBuilder.AppendLine();
            foreach (var group in groups)
            {
                _ = stringBuilder.AppendLine(group.Key);
                foreach (var analyzeResult in group)
                {
                    _ = stringBuilder.AppendLine($"- {analyzeResult.MethodName}");
                }

                _ = stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}