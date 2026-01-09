using System.Collections.Immutable;
using System.Text;
using ConsoleTables;
using Extensions.Pack;
using Solution.Parser.CSharp;

namespace Argument.Check.Test.SolutionAndProjects
{
    [TestClass]
    public class VisibilityConstrainstTest : SolutionTestBase
    {
        [TestMethod]
        public void All_Not_Throw_Helpers_Must_Not_Be_Public()
        {
            var publicMethods = (from syntaxTree in SyntaxTrees
                                 from @class in syntaxTree.Classes
                                 from method in @class.Methods
                                 where method.Modifiers.Contains(Modifier.Public) && @class.FullQualifiedName.DoesNotContain("Throw")
                                 select new AnalyzeResult(syntaxTree.FileName, method.Name)).ToImmutableList();

            Assert.IsFalse(publicMethods.Any(), $"Not allowed public methods detected, only Throw.xxx helpers must be public.{Environment.NewLine}{Environment.NewLine}{ConsoleTable.From(publicMethods)}");
        }

        [TestMethod]
        public void All_Throw_Helpers_Must_Be_Public()
        {
            var publicMethods = from syntaxTree in SyntaxTrees
                                from @class in syntaxTree.Classes
                                where @class.Name == "Throw"
                                from method in @class.Methods
                                where method.Modifiers.All(m => m.NotEqualsTo(Modifier.Public))
                                select new AnalyzeResult(syntaxTree.FileName, method.Name);

            Assert.IsFalse(publicMethods.Any(), ToMessage("Throw.xxx helpers must be public", publicMethods));
        }

        private string ToMessage(string title, IEnumerable<AnalyzeResult> analyzeResults)
        {
            var groups = analyzeResults.GroupBy(result => result.FileName);
            var stringBuilder = new StringBuilder();

            _ = stringBuilder.AppendLine(title);
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

    public record AnalyzeResult(string FileName, string Method);
}
