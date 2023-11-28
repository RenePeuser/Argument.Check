using System.Diagnostics;
using System.Text;
using Extensions.Pack;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Argument.Check.Test.SolutionAndProjects
{
    [TestClass]
    public class DebbugerHiddenTest : SolutionTestBase
    {
        [TestMethod]
        public void All_Methods_Must_Be_Decorated_With_The_DebuggerHidden_Attribute()
        {
            var missingHiddenAttribute = from syntaxTree in SyntaxTrees
                                         from @class in syntaxTree.Classes
                                         where @class.Name.Contains("Throw")
                                         from method in @class.Methods
                                         where method.Attributes.All(a => a.Name.DoesNotContain("DebuggerHidden"))
                                         select new AnalyzeResult(syntaxTree.FileName, method.Name);

            Assert.IsFalse(missingHiddenAttribute.Any(), ToMessage(missingHiddenAttribute));
        }

        private string ToMessage(IEnumerable<AnalyzeResult> analyzeResults)
        {
            var groups = analyzeResults.GroupBy(result => result.FileName);
            var stringBuilder = new StringBuilder();

            _ = stringBuilder.AppendLine($"Missing {nameof(DebuggerHiddenAttribute)} detected:");
            _ = stringBuilder.AppendLine();
            foreach (var group in groups)
            {
                _ = stringBuilder.AppendLine(group.Key);
                foreach (var analyzeResult in group)
                {
                    _ = stringBuilder.AppendLine($"- {analyzeResult.Method}");
                }

                _ = stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}
