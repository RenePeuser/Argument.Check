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
                                         where !attributeListSyntaxes.Any() || !attributeListSyntaxes.First().Attributes.Any() || !attributeListSyntaxes.First().Attributes.Any(a => a.Name.ToString().Contains("DebuggerHidden"))
                                         select new AnalyzeResult(cSharpFileInfo.FileInfo, method.Identifier.ToString());

            Assert.IsFalse(missingHiddenAttribute.Any(), ToMessage(missingHiddenAttribute));
        }

        private string ToMessage(IEnumerable<AnalyzeResult> analyzeResults)
        {
            var groups = analyzeResults.GroupBy(result => result.CSharpFileInfo.FullName);
            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Missing {nameof(DebuggerHiddenAttribute)} detected:");
            stringBuilder.AppendLine();
            foreach (var group in groups)
            {
                stringBuilder.AppendLine(group.Key);
                foreach (var analyzeResult in group)
                {
                    stringBuilder.AppendLine($"- {analyzeResult.MethodName}");
                }
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}
