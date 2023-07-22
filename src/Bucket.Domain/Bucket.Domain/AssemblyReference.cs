using System.Reflection;

namespace Bucket.Domain;

public static class AssemblyReference
{
    public static Assembly Assembly => typeof(AssemblyReference).Assembly;
}