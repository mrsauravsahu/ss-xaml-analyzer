using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Diagnostics;

namespace SS.Xaml.Analyzers;

[DiagnosticAnalyzer("XAML")]
public class FirstAnalyzerCSAnalyzer : DiagnosticAnalyzer
{
  public const string DiagnosticId = "MakeConstCS";
  private const string Title = "Variable can be made constant";
  private const string MessageFormat = "Can be made constant";
  private const string Description = "Make Constant.";
  private const string Category = "Usage";

  private static DiagnosticDescriptor rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

  public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics
  {
    get { return ImmutableArray.Create(rule); }
  }

  public override void Initialize(AnalysisContext context)
  {
    context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
    context.EnableConcurrentExecution();
    context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.LocalDeclarationStatement);
  }

  private static void AnalyzeNode(SyntaxNodeAnalysisContext context)
  {
    throw new NotImplementedException();
  }
}