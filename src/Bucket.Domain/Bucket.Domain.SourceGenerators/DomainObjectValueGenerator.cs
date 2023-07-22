using Microsoft.CodeAnalysis;

namespace Bucket.Domain.SourceGenerators;

[Generator]
public class DomainObjectValueGenerator : ISourceGenerator 
{
    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForSyntaxNotifications(() => new DomainObjectValueSyntaxReceiver());
    }

    public void Execute(GeneratorExecutionContext context)
    {
        if (context.SyntaxReceiver is not DomainObjectValueSyntaxReceiver syntaxReceiver) 
            return;
        
        foreach (var objectValue in syntaxReceiver.DomainObjectValues)
        {
            var rawSourceCode = string.Format(@"
public partial readonly record struct {0} : IComparable<{0}>
{{
    public int CompareTo({0} other) => Value.CompareTo(other.Value);
                    
    public bool Equals({0} other) => Value == other.Value;
                      
    public bool Equals({0}? other) => other != null && Equals(other.Value);
                        
    public override int GetHashCode() => Value.GetHashCode();
                    
    public override string ToString() => Value.ToString();
                    
    public static explicit operator {0}(int value) => new(value);
    public static explicit operator int({0} value) => value.Value;
                        
    public static bool operator < ({0} left, {0} right) => left.Value < right.Value;
    public static bool operator > ({0}  left, {0}  right) => left.Value > right.Value;
    public static bool operator <= ({0}  left, {0} right) => left.Value <= right.Value;
    public static bool operator >= ({0}  left, {0} right) => left.Value >= right.Value;
                    
    public static {0} Empty => default;
}}", objectValue.Identifier.Text);  
            
            context.AddSource($"{objectValue.Identifier.Text}.g.cs", rawSourceCode);
        }
    }
}