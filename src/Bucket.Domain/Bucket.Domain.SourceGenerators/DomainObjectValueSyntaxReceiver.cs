using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Bucket.Domain.SourceGenerators;

public class DomainObjectValueSyntaxReceiver : ISyntaxReceiver
{
    private const string ReceiverEntityName = "IDomainObjectValue";

    public List<RecordDeclarationSyntax> DomainObjectValues { get; } = new();
    
    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        if (syntaxNode is not RecordDeclarationSyntax structDeclaration) 
            return;
        
        if (HasObjectValueInterface(structDeclaration, ReceiverEntityName))
        {
            DomainObjectValues.Add(structDeclaration);
        }
    }

    private bool HasObjectValueInterface(RecordDeclarationSyntax syntaxNode, string interfaceName)
    {
        var baseTypes = syntaxNode.BaseList?.Types.Select(baseType => baseType);

        return baseTypes.Any(baseType => baseType.ToString() == interfaceName);
    }
}