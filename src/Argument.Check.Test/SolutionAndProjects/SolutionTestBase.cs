using System.Collections.Immutable;
using Solution.Parser.CSharp;
using Solution.Parser.Solution;

namespace Argument.Check.Test.SolutionAndProjects
{
    [TestClass]
    public abstract class SolutionTestBase
    {
        internal static IImmutableList<CSharpSyntaxTree> SyntaxTrees { get; private set; } = ImmutableList<CSharpSyntaxTree>.Empty;

        internal static IImmutableList<CSharpSyntaxTree> ThrowHelperCSharpFileInfos { get; private set; } = ImmutableList<CSharpSyntaxTree>.Empty;

        [AssemblyInitialize]
        public static void ClassInit(TestContext _)
        {
            var sSolutionFileInfo = new SolutionFileName("Argument.Check.sln").FindSolutionFileReverseFrom(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory));
            Throw.IfNull(sSolutionFileInfo);

            var parsedSolution = sSolutionFileInfo.Parse();
            SyntaxTrees = parsedSolution.ProductiveProjects.Where(p => p.ProjectFileInfo.FileNameWithoutExtenion == "Argument.Check")
                                                .SelectMany(p => p.CSharpFileInfos)
                                                .Select(c => c.Parse())
                                                .ToImmutableList();


            ThrowHelperCSharpFileInfos = SyntaxTrees.Where(file => file.FileName.Contains("ThrowHelper")).ToImmutableList();
        }

    }
}
