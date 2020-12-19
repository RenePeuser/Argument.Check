using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.SolutionAndProjects
{
    [TestClass]
    public class VisibilityConstrainstTest : SolutionTestBase
    {
        [TestMethod]
        public void All_Not_Throw_Helpers_Must_Not_Be_Public()
        {
            var publicMethods = from cSharpFileInfo in CSharpFileInfos
                where !cSharpFileInfo.FileInfo.FullName.Contains("Throw.")
                from @class in cSharpFileInfo.SyntaxTree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>()
                from method in @class.DescendantNodes().OfType<MethodDeclarationSyntax>()
                where method.Modifiers.Any(m => m.Text.Contains("public"))
                select new AnalyzeResult(cSharpFileInfo.FileInfo, method.Identifier.ToString());

            Assert.IsFalse(publicMethods.Any(), ToMessage("Not allowed public methods detected, only Throw.xxx helpers must be public", publicMethods));
        }

        [TestMethod]
        public void All_Throw_Helpers_Must_Be_Public()
        {
            var publicMethods = from cSharpFileInfo in CSharpFileInfos
                where cSharpFileInfo.FileInfo.FullName.Contains("Throw.")
                from @class in cSharpFileInfo.SyntaxTree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>()
                from method in @class.DescendantNodes().OfType<MethodDeclarationSyntax>()
                where method.Modifiers.All(m => !m.Text.Contains("public"))
                select new AnalyzeResult(cSharpFileInfo.FileInfo, method.Identifier.ToString());

            Assert.IsFalse(publicMethods.Any(), ToMessage("Throw.xxx helpers must be public", publicMethods));
        }

        private string ToMessage(string title, IEnumerable<AnalyzeResult> analyzeResults)
        {
            var groups = analyzeResults.GroupBy(result => result.CSharpFileInfo.FullName);
            var stringBuilder = new StringBuilder();

            _ = stringBuilder.AppendLine(title);
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